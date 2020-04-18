' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports System.Collections.Immutable
Imports System.Collections.ObjectModel
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Microsoft.CodeAnalysis.Operations
Imports Microsoft.CodeAnalysis.Syntax
Imports Microsoft.CodeAnalysis.VisualBasic
Imports Microsoft.CodeAnalysis.VisualBasic.Symbols
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Namespace Microsoft.CodeAnalysis.VisualBasic

    Public Partial Module VisualBasicExtensions

        ''' <summary> Determines if the given raw kind value belongs to the Visual Basic <see cref="SyntaxKind"/> enumeration. </summary>
        ''' <param name="rawKind">The raw value to test.</param>
        ''' <returns><see langword="true"/> when the raw value belongs to the Visual Basic syntax kind; otherwise, <see langword="false"/>.</returns>
        Friend Function IsVisualBasicKind(rawKind As Integer) As Boolean
            Const LastPossibleVisualBasicKind As Integer = 8192

            Return rawKind <= LastPossibleVisualBasicKind
        End Function

        ''' <summary> Returns <see cref="SyntaxKind"/> for <see cref="SyntaxTrivia"/> from <see cref="SyntaxTrivia.RawKind"/> property. </summary>
        <Extension>
        Public Function Kind(trivia As SyntaxTrivia) As SyntaxKind
            Dim rawKind = trivia.RawKind
            Return If(IsVisualBasicKind(rawKind), CType(rawKind, SyntaxKind), SyntaxKind.None)
        End Function

        ''' <summary> Returns <see cref="SyntaxKind"/> for <see cref="SyntaxToken"/> from <see cref="SyntaxToken.RawKind"/> property. </summary>
        <Extension>
        Public Function Kind(token As SyntaxToken) As SyntaxKind
            Dim rawKind = token.RawKind
            Return If(IsVisualBasicKind(rawKind), CType(rawKind, SyntaxKind), SyntaxKind.None)
        End Function

        ''' <summary> Returns <see cref="SyntaxKind"/> for <see cref="SyntaxNode"/> from <see cref="SyntaxNode.RawKind"/> property. </summary>
        <Extension>
        Public Function Kind(node As SyntaxNode) As SyntaxKind
            Dim rawKind = node.RawKind
            Return If(IsVisualBasicKind(rawKind), CType(rawKind, SyntaxKind), SyntaxKind.None)
        End Function

        ''' <summary> Returns <see cref="SyntaxKind"/> for <see cref="SyntaxNodeOrToken"/> from <see cref="SyntaxNodeOrToken.RawKind"/> property. </summary>
        <Extension>
        Public Function Kind(nodeOrToken As SyntaxNodeOrToken) As SyntaxKind
            Dim rawKind = nodeOrToken.RawKind
            Return If(IsVisualBasicKind(rawKind), CType(rawKind, SyntaxKind), SyntaxKind.None)
        End Function

        <Extension>
        Friend Function GetLocation(syntaxReference As SyntaxReference) As Location
            Dim tree = TryCast(syntaxReference.SyntaxTree, VisualBasicSyntaxTree)
            If syntaxReference.SyntaxTree IsNot Nothing Then
                If tree.IsEmbeddedSyntaxTree Then
                    Return New EmbeddedTreeLocation(tree.GetEmbeddedKind, syntaxReference.Span)
                ElseIf tree.IsMyTemplate Then
                    Return New MyTemplateLocation(tree, syntaxReference.Span)
                End If
            End If
            Return New SourceLocation(syntaxReference)
        End Function

        <Extension>
        Friend Function IsMyTemplate(syntaxTree As SyntaxTree) As Boolean
            Dim vbTree = TryCast(syntaxTree, VisualBasicSyntaxTree)
            Return vbTree IsNot Nothing AndAlso vbTree.IsMyTemplate
        End Function

        <Extension>
        Friend Function HasReferenceDirectives(syntaxTree As SyntaxTree) As Boolean
            Dim vbTree = TryCast(syntaxTree, VisualBasicSyntaxTree)
            Return vbTree IsNot Nothing AndAlso vbTree.HasReferenceDirectives
        End Function

        <Extension>
        Friend Function IsAnyPreprocessorSymbolDefined(syntaxTree As SyntaxTree, conditionalSymbolNames As IEnumerable(Of String), atNode As SyntaxNodeOrToken) As Boolean
            Dim vbTree = TryCast(syntaxTree, VisualBasicSyntaxTree)
            Return vbTree IsNot Nothing AndAlso vbTree.IsAnyPreprocessorSymbolDefined(conditionalSymbolNames, atNode)
        End Function

        <Extension>
        Friend Function GetVisualBasicSyntax(syntaxReference As SyntaxReference, Optional cancellationToken As CancellationToken = Nothing) As VisualBasicSyntaxNode
            Return DirectCast(syntaxReference.GetSyntax(cancellationToken), VisualBasicSyntaxNode)
        End Function

        <Extension>
        Friend Function GetVisualBasicRoot(syntaxTree As SyntaxTree, Optional cancellationToken As CancellationToken = Nothing) As VisualBasicSyntaxNode
            Return DirectCast(syntaxTree.GetRoot(cancellationToken), VisualBasicSyntaxNode)
        End Function

        <Extension>
        Friend Function GetPreprocessingSymbolInfo(syntaxTree As SyntaxTree, identifierNode As IdentifierNameSyntax) As VisualBasicPreprocessingSymbolInfo
            Dim vbTree = DirectCast(syntaxTree, VisualBasicSyntaxTree)
            Return vbTree.GetPreprocessingSymbolInfo(identifierNode)
        End Function

        <Extension>
        Friend Function Errors(trivia As SyntaxTrivia) As InternalSyntax.SyntaxDiagnosticInfoList
            Return New InternalSyntax.SyntaxDiagnosticInfoList(DirectCast(trivia.UnderlyingNode, InternalSyntax.VisualBasicSyntaxNode))
        End Function

        <Extension>
        Friend Function Errors(token As SyntaxToken) As InternalSyntax.SyntaxDiagnosticInfoList
            Return New InternalSyntax.SyntaxDiagnosticInfoList(DirectCast(token.Node, InternalSyntax.VisualBasicSyntaxNode))
        End Function

        <Extension>
        Friend Function GetSyntaxErrors(token As SyntaxToken, tree As SyntaxTree) As ReadOnlyCollection(Of Diagnostic)
            Return VisualBasicSyntaxNode.DoGetSyntaxErrors(tree, token)
        End Function

        ''' <summary> Checks to see if SyntaxToken is a bracketed identifier. </summary>
        ''' <param name="token">The source SyntaxToken.</param>
        ''' <returns>A boolean value, True if token represents a bracketed Identifier.</returns>
        <Extension>
        Public Function IsBracketed(token As SyntaxToken) As Boolean
            Return token.IsKind(SyntaxKind.IdentifierToken) AndAlso DirectCast(token.Node, InternalSyntax.IdentifierTokenSyntax).IsBracketed
        End Function

        ''' <summary>
        ''' Returns the Type character for a given syntax token.  This returns type character for Identifiers or Integer, Floating Point or Decimal Literals.
        ''' Examples: Dim a$   or Dim l1 = 1L
        ''' </summary>
        ''' <param name="token">The source SyntaxToken.</param>
        ''' <returns>A type character used for the specific Internal Syntax Token Types.</returns>
        <Extension>
        Public Function GetTypeCharacter(token As SyntaxToken) As TypeCharacter
            Select Case token.Kind()
                   Case SyntaxKind.IdentifierToken
                        Dim id = DirectCast(token.Node, InternalSyntax.IdentifierTokenSyntax)
                        Return id.TypeCharacter

                   Case SyntaxKind.IntegerLiteralToken
                        Dim literal = DirectCast(token.Node, InternalSyntax.IntegerLiteralTokenSyntax)
                        Return literal.TypeSuffix

                   Case SyntaxKind.FloatingLiteralToken
                        Dim literal = DirectCast(token.Node, InternalSyntax.FloatingLiteralTokenSyntax)
                        Return literal.TypeSuffix

                   Case SyntaxKind.DecimalLiteralToken
                        Dim literal = DirectCast(token.Node, InternalSyntax.DecimalLiteralTokenSyntax)
                        Return literal.TypeSuffix
            End Select

            Return Nothing
        End Function

        ''' <summary> The source token base for Integer literals.  Base can be Decimal, Hex or Octal. </summary>
        ''' <param name="token">The source SyntaxToken.</param>
        ''' <returns>An instance representing the integer literal base.</returns>
        <Extension>
        Public Function GetBase(token As SyntaxToken) As LiteralBase?
            If Not token.IsKind(SyntaxKind.IntegerLiteralToken) Then Return Nothing
            Dim tk = DirectCast(token.Node, InternalSyntax.IntegerLiteralTokenSyntax)
            Return tk.Base
        End Function

        ''' <summary> Determines if the token represents a reserved or contextual keyword </summary>
        ''' <param name="token">The source SyntaxToken.</param>
        ''' <returns>A boolean value True if token is a keyword.</returns>
        <Extension>
        Public Function IsKeyword(token As SyntaxToken) As Boolean
            Return SyntaxFacts.IsKeywordKind(token.Kind())
        End Function

        ''' <summary> Determines if the token represents a reserved keyword </summary>
        ''' <param name="token">The source SyntaxToken.</param>
        ''' <returns>A boolean value True if token is a reserved keyword.</returns>
        <Extension>
        Public Function IsReservedKeyword(token As SyntaxToken) As Boolean
            Return SyntaxFacts.IsReservedKeyword(token.Kind())
        End Function

        ''' <summary> Determines if the token represents a contextual keyword </summary>
        ''' <returns>A boolean value True if token is a contextual keyword.</returns>
        <Extension>
        Public Function IsContextualKeyword(token As SyntaxToken) As Boolean
            Return SyntaxFacts.IsContextualKeyword(token.Kind())
        End Function

        ''' <summary> Determines if the token  represents a preprocessor keyword </summary>
        ''' <param name="token">The source SyntaxToken.</param>
        ''' <returns> A boolean value True if token is a pre processor keyword.</returns>
        <Extension>
        Public Function IsPreprocessorKeyword(token As SyntaxToken) As Boolean
            Return SyntaxFacts.IsPreprocessorKeyword(token.Kind())
        End Function

        ''' <summary> Returns the Identifiertext for a specified SyntaxToken. </summary>
        <Extension>
        Public Function GetIdentifierText(token As SyntaxToken) As String
            Return If(token.Node IsNot Nothing,
                        If(token.IsKind(SyntaxKind.IdentifierToken),
                            DirectCast(token.Node, InternalSyntax.IdentifierTokenSyntax).IdentifierText,
                            token.ToString()),
                        String.Empty)
        End Function

        <Extension>
        Friend Function IsBetween(value As Int32, lower As Int32, upper As Int32) As Boolean
            Return (lower <= value) AndAlso (value <= upper)
        End Function

        ''' <summary> Insert one or more tokens in the list at the specified index. </summary>
        ''' <returns>A new list with the tokens inserted.</returns>
        <Extension>
        Public Function Insert(list As SyntaxTokenList, index As Integer, ParamArray items As SyntaxToken()) As SyntaxTokenList
            If Not index.IsBetween(0, list.Count) Then Throw New ArgumentOutOfRangeException(NameOf(index))
 
            If items Is Nothing Then Throw New ArgumentNullException(NameOf(items))

            If list.Count = 0 Then Return SyntaxFactory.TokenList(items)

            Dim builder As New SyntaxTokenListBuilder(list.Count + items.Length)
            If index > 0 Then builder.Add(list, 0, index)

            builder.Add(items)
            If index < list.Count Then builder.Add(list, index, list.Count - index)

            Return builder.ToList()
        End Function

        ''' <summary> Add one or more tokens to the end of the list. </summary>
        ''' <returns>A new list with the tokens added.</returns>
        <Extension>
        Public Function Add(list As SyntaxTokenList, ParamArray items As SyntaxToken()) As SyntaxTokenList
            Return Insert(list, list.Count, items)
        End Function

        ''' <summary> Replaces trivia on a specified SyntaxToken. </summary>
        ''' <param name="token">The source SyntaxToken to change trivia on.</param>
        ''' <param name="oldTrivia">The original Trivia.</param>
        ''' <param name="newTrivia">The updated Trivia.</param>
        ''' <returns>The updated SyntaxToken with replaced trivia.</returns>
        <Extension>
        Public Function ReplaceTrivia(token As SyntaxToken, oldTrivia As SyntaxTrivia, newTrivia As SyntaxTrivia) As SyntaxToken
            Return SyntaxReplacer.Replace(token, trivia:={oldTrivia}, computeReplacementTrivia:=Function(o, r) newTrivia)
        End Function

        ''' <summary> Replaces trivia on a specified SyntaxToken. </summary>
        <Extension>
        Public Function ReplaceTrivia(token As SyntaxToken, trivia As IEnumerable(Of SyntaxTrivia), computeReplacementTrivia As Func(Of SyntaxTrivia, SyntaxTrivia, SyntaxTrivia)) As SyntaxToken
            Return SyntaxReplacer.Replace(token, trivia:=trivia, computeReplacementTrivia:=computeReplacementTrivia)
        End Function

        <Extension>
        Friend Function AsSeparatedList(Of TOther As SyntaxNode)(list As SyntaxNodeOrTokenList) As SeparatedSyntaxList(Of TOther)
            Dim builder = SeparatedSyntaxListBuilder(Of TOther).Create
            For Each i In list
                Dim node = i.AsNode
                If node IsNot Nothing Then
                    builder.Add(DirectCast(DirectCast(node, SyntaxNode), TOther))
                Else
                    builder.AddSeparator(i.AsToken)
                End If
            Next
            Return builder.ToList
        End Function

        ''' <summary> Gets the DirectiveTriviaSyntax items for a specified SyntaxNode with optional filtering. </summary>
        ''' <param name="node">The source SyntaxNode.</param>
        ''' <param name="filter">The optional DirectiveTrivia Syntax filter predicate.</param>
        ''' <returns>A list of DirectiveTriviaSyntax items</returns>
        <Extension>
        Public Function GetDirectives(node As SyntaxNode, Optional filter As Func(Of DirectiveTriviaSyntax, Boolean) = Nothing) As IList(Of DirectiveTriviaSyntax)
            Return DirectCast(node, VisualBasicSyntaxNode).GetDirectives(filter)
        End Function


        ''' <summary> Gets the first DirectiveTriviaSyntax item for a specified SyntaxNode. </summary>
        ''' <param name="node">The source SyntaxNode.</param>
        ''' <param name="predicate">The optional DirectiveTriviaSyntax filter predicate.</param>
        ''' <returns>The first DirectiveSyntaxTrivia item.</returns>
        <Extension> Public Function GetFirstDirective(node As SyntaxNode, Optional predicate As Func(Of DirectiveTriviaSyntax, Boolean) = Nothing) As DirectiveTriviaSyntax
            Return DirectCast(node, VisualBasicSyntaxNode).GetFirstDirective(predicate)
        End Function

        ''' <summary> Gets the last DirectiveTriviaSyntax item for a specified SyntaxNode. </summary>
        ''' <param name="node">The source node</param>
        ''' <param name="predicate">The optional DirectiveTriviaSyntax filter predicate.</param>
        ''' <returns>The last DirectiveSyntaxTrivia item.</returns>
        <Extension>
        Public Function GetLastDirective(node As SyntaxNode, Optional predicate As Func(Of DirectiveTriviaSyntax, Boolean) = Nothing) As DirectiveTriviaSyntax
            Return DirectCast(node, VisualBasicSyntaxNode).GetLastDirective(predicate)
        End Function

        ''' <summary> Gets the root CompilationUnitSyntax for a specified SyntaxTree. </summary>
        ''' <param name="tree">The source SyntaxTree.</param>
        ''' <returns>A CompilationUnitSyntax.</returns>
        <Extension>
        Public Function GetCompilationUnitRoot(tree As SyntaxTree) As CompilationUnitSyntax
            Return DirectCast(tree.GetRoot(), CompilationUnitSyntax)
        End Function

        ''' <summary> Gets the reporting state for a warning at a given source location based on warning directives. </summary>
        <Extension>
        Friend Function GetWarningState(tree As SyntaxTree, id As String, position As Integer) As ReportDiagnostic
            Return DirectCast(tree, VisualBasicSyntaxTree).GetWarningState(id, position)
        End Function

    End Module

End Namespace
