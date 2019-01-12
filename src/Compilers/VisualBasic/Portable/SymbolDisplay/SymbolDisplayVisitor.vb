' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports Microsoft.CodeAnalysis.PooledObjects
Imports Microsoft.CodeAnalysis.SymbolDisplay
Imports Microsoft.CodeAnalysis.VisualBasic.Symbols

'Imports SemanticModel = Microsoft.CodeAnalysis.VisualBasic.Semantics.SemanticModel

Namespace Microsoft.CodeAnalysis.VisualBasic
  Partial Friend Class SymbolDisplayVisitor
    Inherits AbstractSymbolDisplayVisitor

    Private ReadOnly _escapeKeywordIdentifiers As Boolean

    ' A Symbol in VB might be a PENamedSymbolWithEmittedNamespaceName and in that case the 
    ' casing of the contained types and namespaces might differ because of merged classes/namespaces.
    ' To maintain the original spelling an emittedNamespaceName with the correct spelling is passed to 
    ' this visitor. 

    Friend Sub New(
                    builder As ArrayBuilder(Of SymbolDisplayPart),
                    format As SymbolDisplayFormat,
                    semanticModelOpt As SemanticModel,
                    positionOpt As Integer
                  )
      MyBase.New(builder, format, True, semanticModelOpt, positionOpt)
      Debug.Assert(format IsNot Nothing, "Format must not be null")
      _escapeKeywordIdentifiers = format.MiscellaneousOptions.IncludesOption(SymbolDisplayMiscellaneousOptions.EscapeKeywordIdentifiers)
    End Sub

    Private Sub New(
                     builder As ArrayBuilder(Of SymbolDisplayPart),
                     format As SymbolDisplayFormat,
                     semanticModelOpt As SemanticModel, 
                     positionOpt As Integer,
                     escapeKeywordIdentifiers As Boolean,
                     isFirstSymbolVisited As Boolean,
            Optional inNamespaceOrType As Boolean = False)
      MyBase.New(builder, format, isFirstSymbolVisited, semanticModelOpt, positionOpt, inNamespaceOrType)
      _escapeKeywordIdentifiers = escapeKeywordIdentifiers
    End Sub

    ' in case the display of a symbol is different for a type that acts as a container, use this visitor
    Protected Overrides Function MakeNotFirstVisitor(Optional inNamespaceOrType As Boolean = False) As AbstractSymbolDisplayVisitor
      Return New SymbolDisplayVisitor(builder, format, semanticModelOpt, positionOpt, _escapeKeywordIdentifiers, isFirstSymbolVisited:=False, inNamespaceOrType:=inNamespaceOrType)
    End Function

    Friend Function CreatePart(kind As SymbolDisplayPartKind,
                               symbol As ISymbol,
                               text As String,
                               noEscaping As Boolean) As SymbolDisplayPart
      Dim escape = (AlwaysEscape(kind, text) OrElse Not noEscaping) AndAlso _escapeKeywordIdentifiers AndAlso IsEscapable(kind)
      Return New SymbolDisplayPart(kind, symbol, If(escape, EscapeIdentifier(text), text))
    End Function

    Private Shared Function AlwaysEscape(kind As SymbolDisplayPartKind, text As String) As Boolean
      If kind = SymbolDisplayPartKind.Keyword Then Return False
      ' We must always escape "Rem" and "New" when they are being used in an identifier context.
      ' For constructors, (say C.New) we emit New as a Keyword kind if it's a constructor, or
      ' as an appropriate name kind if it's an identifier.
      If CaseInsensitiveComparison.Equals(SyntaxFacts.GetText(SyntaxKind.REMKeyword), text) OrElse
         CaseInsensitiveComparison.Equals(SyntaxFacts.GetText(SyntaxKind.NewKeyword), text) Then
         Return True
      End If
      Return False
    End Function

    Private Shared Function IsEscapable(kind As SymbolDisplayPartKind) As Boolean
      Select Case kind
             Case SymbolDisplayPartKind.ModuleName,         SymbolDisplayPartKind.ClassName,
                  SymbolDisplayPartKind.StructName,         SymbolDisplayPartKind.InterfaceName,
                  SymbolDisplayPartKind.EnumName,           SymbolDisplayPartKind.DelegateName,
                  SymbolDisplayPartKind.TypeParameterName,  SymbolDisplayPartKind.MethodName,
                  SymbolDisplayPartKind.PropertyName,       SymbolDisplayPartKind.FieldName,
                  SymbolDisplayPartKind.LocalName,          SymbolDisplayPartKind.NamespaceName,
                  SymbolDisplayPartKind.ParameterName,      SymbolDisplayPartKind.AliasName,
                  SymbolDisplayPartKind.ErrorTypeName,      SymbolDisplayPartKind.LabelName,
                  SymbolDisplayPartKind.EventName,          SymbolDisplayPartKind.RangeVariableName
                  Return True
        End Select
        Return False
    End Function

    Private Function EscapeIdentifier(identifier As String) As String
      ' always escape keywords, 
      If SyntaxFacts.GetKeywordKind(identifier) <> SyntaxKind.None Then Return String.Format("[{0}]", identifier)
      ' The minimal flag is e.g. used by the service layer when generating code (example: simplify name).
      ' Unfortunately we do not know in what context the identifier is used and we need to assume the worst case here
      ' to avoid ambiguities while parsing the resulting code.
      If IsMinimizing Then
         Dim contextualKeywordKind As SyntaxKind = SyntaxFacts.GetContextualKeywordKind(identifier)

         ' Leading implicit line continuation is allowed before query operators (Aggregate, Distinct, From, Group By, 
        ' Group Join, Join, Let, Order By, Select, Skip, Skip While, Take, Take While, Where, In, Into, On, Ascending, 
        ' and Descending).
        ' If the current identifier is one of these keywords, we need to escape them to avoid parsing issues if the
        ' previous line was a query expression.
        '
        ' In addition to the query operators, we need to escape the identifier "preserve" to avoid ambiguities 
        ' inside of a dim statement (dim [preserve].ArrayName(1))
        Select Case contextualKeywordKind
               Case SyntaxKind.AggregateKeyword,    SyntaxKind.DistinctKeyword,
                    SyntaxKind.FromKeyword,         SyntaxKind.GroupKeyword,
                    SyntaxKind.JoinKeyword,         SyntaxKind.LetKeyword,
                    SyntaxKind.OrderKeyword,        SyntaxKind.SelectKeyword,
                    SyntaxKind.SkipKeyword,         SyntaxKind.TakeKeyword,
                    SyntaxKind.WhereKeyword,        SyntaxKind.InKeyword,
                    SyntaxKind.IntoKeyword,         SyntaxKind.OnKeyword,
                    SyntaxKind.AscendingKeyword,    SyntaxKind.DescendingKeyword,
                    SyntaxKind.PreserveKeyword
                 Return $"[{identifier}]"
        End Select
      End If
      Return identifier
    End Function

    Public Overrides Sub VisitAssembly(symbol As IAssemblySymbol)
      Dim text = If((format.TypeQualificationStyle = SymbolDisplayTypeQualificationStyle.NameOnly), symbol.Identity.Name, symbol.Identity.GetDisplayName())
      builder.Add(CreatePart(SymbolDisplayPartKind.AssemblyName, symbol, text, False))
    End Sub

    Public Overrides Sub VisitLabel(symbol As ILabelSymbol)
      builder.Add(CreatePart(SymbolDisplayPartKind.LabelName, symbol, symbol.Name, False))
    End Sub

    Public Overrides Sub VisitAlias(symbol As IAliasSymbol)
      builder.Add(CreatePart(SymbolDisplayPartKind.LocalName, symbol, symbol.Name, False))

      If format.LocalOptions.IncludesOption(SymbolDisplayLocalOptions.IncludeType) Then
        AddPunctuation(SyntaxKind.EqualsToken, False)
        symbol.Target.Accept(Me)
      End If
    End Sub

    Public Overrides Sub VisitModule(symbol As IModuleSymbol)
      builder.Add(CreatePart(SymbolDisplayPartKind.ModuleName, symbol, symbol.Name, False))
    End Sub

    Public Overloads Overrides Sub VisitNamespace(symbol As INamespaceSymbol)
      If isFirstSymbolVisited AndAlso format.KindOptions.IncludesOption(SymbolDisplayKindOptions.IncludeNamespaceKeyword) Then AddKeyword(SyntaxKind.NamespaceKeyword, false, true)
      VisitNamespace(symbol, String.Empty)
    End Sub

    Private Overloads Sub VisitNamespace(symbol As INamespaceSymbol, emittedName As String)
      Dim myCaseCorrectedNSName As String = symbol.Name
      Dim myCaseCorrectedParentNSName As String = String.Empty

      If Not emittedName.IsEmpty Then
        Dim nsIdx = emittedName.LastIndexOf("."c)
        If nsIdx > -1 Then
           myCaseCorrectedNSName = emittedName.Substring(nsIdx + 1)
           myCaseCorrectedParentNSName = emittedName.Substring(0, nsIdx)
        Else
           myCaseCorrectedNSName = emittedName
        End If
      End If

      If IsMinimizing Then
         If TryAddAlias(symbol, builder) Then Return
         MinimallyQualify(symbol, myCaseCorrectedNSName, myCaseCorrectedParentNSName)
         Return
      End If

      Dim visitedParents As Boolean = False
      If format.TypeQualificationStyle = SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces Then
         Dim containingNamespace = symbol.ContainingNamespace
         ' add "Namespace " if SymbolDisplayKindOptions.IncludeKind is set
         ' this is not handled in AddTypeKind in AddTypeKind()
         If containingNamespace Is Nothing AndAlso format.KindOptions.IncludesOption(SymbolDisplayKindOptions.IncludeNamespaceKeyword) Then
            AddKeyword(SyntaxKind.NamespaceKeyword, false,true)
         End If
         If ShouldVisitNamespace(containingNamespace) Then
            VisitNamespace(containingNamespace, myCaseCorrectedParentNSName)
            AddOperator(SyntaxKind.DotToken)
            visitedParents = True
         End If
      End If
      If symbol.IsGlobalNamespace Then
         AddGlobalNamespace(symbol)
      Else
        builder.Add(CreatePart(SymbolDisplayPartKind.NamespaceName, symbol, myCaseCorrectedNSName, visitedParents))
      End If
    End Sub

    Private Sub AddGlobalNamespace(symbol As INamespaceSymbol)
      Select Case format.GlobalNamespaceStyle
             Case SymbolDisplayGlobalNamespaceStyle.Omitted
             Case SymbolDisplayGlobalNamespaceStyle.Included
                  builder.Add(CreatePart(SymbolDisplayPartKind.Keyword, symbol, SyntaxFacts.GetText(SyntaxKind.GlobalKeyword), True))
             Case SymbolDisplayGlobalNamespaceStyle.OmittedAsContaining
                  Debug.Assert(isFirstSymbolVisited, "Don't call with IsFirstSymbolVisited = false if OmittedAsContaining")
                  builder.Add(CreatePart(SymbolDisplayPartKind.Keyword, symbol, SyntaxFacts.GetText(SyntaxKind.GlobalKeyword), True))
      End Select
      Throw ExceptionUtilities.UnexpectedValue(format.GlobalNamespaceStyle)
    End Sub

    Public Overrides Sub VisitLocal(symbol As ILocalSymbol)
      ' Locals can be synthesized by the compiler in many cases (for example the implicit 
      ' local in a function that has the same name as the containing function).  In some 
      ' cases the locals are anonymous (for example, a similar local in an operator).  
      '
      ' These anonymous locals should not be exposed through public APIs.  However, for
      ' testing purposes we occasionally may print them out.  In this case, give them 
      ' a reasonable name so that tests can clearly describe what these are.
      Dim name = If(symbol.Name, "<anonymous local>")
      builder.Add(CreatePart(SymbolDisplayPartKind.LocalName, symbol, name, noEscaping:=False))

      If format.LocalOptions.IncludesOption(SymbolDisplayLocalOptions.IncludeType) Then
        AddKeyword(SyntaxKind.AsKeyword, true,true)
        symbol.Type.Accept(Me)
      End If
      If symbol.IsConst AndAlso symbol.HasConstantValue AndAlso format.LocalOptions.IncludesOption(SymbolDisplayLocalOptions.IncludeConstantValue) Then
         AddSpace()
         AddPunctuation(SyntaxKind.EqualsToken, True)
         AddConstantValue(symbol.Type, symbol.ConstantValue)
      End If
    End Sub

    Public Overrides Sub VisitRangeVariable(symbol As IRangeVariableSymbol)
      builder.Add(CreatePart(SymbolDisplayPartKind.RangeVariableName, symbol, symbol.Name, False))
      If Not format.LocalOptions.IncludesOption(SymbolDisplayLocalOptions.IncludeType) Then Return
      Dim vbRangeVariable = TryCast(symbol, RangeVariableSymbol)
      If vbRangeVariable Is Nothing Then Return 
      AddKeyword(SyntaxKind.AsKeyword, true, true)
      DirectCast(vbRangeVariable.Type, ITypeSymbol).Accept(Me)         
    End Sub

    Protected Overrides Sub AddSpace()
      builder.Add(CreatePart(SymbolDisplayPartKind.Space, Nothing, " ", False))
    End Sub

    Private Sub AddOperator(operatorKind As SyntaxKind)
      builder.Add(CreatePart(SymbolDisplayPartKind.Operator, Nothing, SyntaxFacts.GetText(operatorKind), False))
    End Sub

    Private Sub AddPunctuation(punctuationKind As SyntaxKind, thenSPC As Boolean)
      builder.Add(CreatePart(SymbolDisplayPartKind.Punctuation, Nothing, SyntaxFacts.GetText(punctuationKind), False))
      if thenSPC Then AddSpace()
    End Sub

    Private Sub AddPseudoPunctuation(text As String)
      builder.Add(CreatePart(SymbolDisplayPartKind.Punctuation, Nothing, text, False))
    End Sub

    Private Sub AddKeyword(keywordKind As SyntaxKind, afterSPC As Boolean, thenSPC As Boolean)
      if afterSPC Then AddSpace()
      builder.Add(CreatePart(SymbolDisplayPartKind.Keyword, Nothing, SyntaxFacts.GetText(keywordKind), False))
      if thenSPC Then AddSpace()
    End Sub

    Private Sub AddAccessibilityIfRequired(symbol As ISymbol)
      AssertContainingSymbol(symbol)
      Dim containingType = symbol.ContainingType
      If format.MemberOptions.IncludesOption(SymbolDisplayMemberOptions.IncludeAccessibility) AndAlso
         (containingType Is Nothing OrElse
         (containingType.TypeKind <> TypeKind.Interface AndAlso Not IsEnumMember(symbol))) Then

         Select Case symbol.DeclaredAccessibility
                Case Accessibility.Private      : AddKeyword(SyntaxKind.PrivateKeyword, False, false)
                Case Accessibility.Internal     : AddKeyword(SyntaxKind.FriendKeyword, False, false)
                Case Accessibility.Protected    : AddKeyword(SyntaxKind.ProtectedKeyword, False, false)
                Case Accessibility.ProtectedAndInternal
                     AddKeyword(SyntaxKind.PrivateKeyword, false, true)
                     AddKeyword(SyntaxKind.ProtectedKeyword, False, false)
                Case Accessibility.ProtectedOrInternal
                     AddKeyword(SyntaxKind.ProtectedKeyword, False, true)
                     AddKeyword(SyntaxKind.FriendKeyword, False, false)
                Case Accessibility.Public       : AddKeyword(SyntaxKind.PublicKeyword, False, false)
                Case Else
                     Throw ExceptionUtilities.UnexpectedValue(symbol.DeclaredAccessibility)
         End Select
         AddSpace()
      End If
    End Sub

    Private Function ShouldVisitNamespace(containingSymbol As ISymbol) As Boolean
      Return containingSymbol IsNot Nothing AndAlso
             containingSymbol.Kind = SymbolKind.Namespace AndAlso
             format.TypeQualificationStyle = SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces AndAlso
             (Not (DirectCast(containingSymbol, INamespaceSymbol)).IsGlobalNamespace OrElse
             format.GlobalNamespaceStyle = SymbolDisplayGlobalNamespaceStyle.Included)
    End Function

    Private Function IncludeNamedType(namedType As INamedTypeSymbol) As Boolean
      Return namedType IsNot Nothing AndAlso (Not namedType.IsScriptClass OrElse format.CompilerInternalOptions.IncludesOption(SymbolDisplayCompilerInternalOptions.IncludeScriptType))
    End Function

    Private Shared Function IsEnumMember(symbol As ISymbol) As Boolean
      Return symbol IsNot Nothing AndAlso
             symbol.Kind = SymbolKind.Field AndAlso
             symbol.ContainingType IsNot Nothing AndAlso
             symbol.ContainingType.TypeKind = TypeKind.Enum AndAlso
             symbol.Name <> WellKnownMemberNames.EnumBackingFieldName
    End Function

  End Class

End Namespace
