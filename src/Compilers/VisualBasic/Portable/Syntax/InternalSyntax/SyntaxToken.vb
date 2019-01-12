' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports Microsoft.CodeAnalysis.Syntax.InternalSyntax
Imports CoreInternalSyntax = Microsoft.CodeAnalysis.Syntax.InternalSyntax

Namespace Microsoft.CodeAnalysis.VisualBasic.Syntax.InternalSyntax
  Partial Friend Class SyntaxToken
    Inherits VisualBasicSyntaxNode

    Private ReadOnly _text As String
    Private ReadOnly _trailingTriviaOrTriviaInfo As Object

    Friend Class TriviaInfo
      Implements IObjectWritable

      Shared Sub New()
        ObjectBinder.RegisterTypeReader(GetType(TriviaInfo), Function(r) New TriviaInfo(r))
      End Sub

      Private Sub New(leadingTrivia As GreenNode, trailingTrivia As GreenNode)
        _leadingTrivia = leadingTrivia
        _trailingTrivia = trailingTrivia
      End Sub

      Private Const s_maximumCachedTriviaWidth As Integer = 40
      Private Const s_triviaInfoCacheSize      As Integer = 64

      Private Shared ReadOnly s_triviaKeyHasher As Func(Of GreenNode, Integer) =
        Function(key) Hash.Combine(key.ToFullString(), CShort(key.RawKind))

      Private Shared ReadOnly s_triviaKeyEquality As Func(Of GreenNode, TriviaInfo, Boolean) =
        Function(key, value) (key Is value._leadingTrivia) OrElse ((key.RawKind = value._leadingTrivia.RawKind) AndAlso (key.FullWidth = value._leadingTrivia.FullWidth) AndAlso (key.ToFullString() = value._leadingTrivia.ToFullString()))

      Private Shared ReadOnly s_triviaInfoCache As New CachingFactory(Of GreenNode, TriviaInfo)(s_triviaInfoCacheSize, Nothing, s_triviaKeyHasher, s_triviaKeyEquality)

      Private Shared Function ShouldCacheTriviaInfo(leadingTrivia As GreenNode, trailingTrivia As GreenNode) As Boolean
        Debug.Assert(leadingTrivia IsNot Nothing)
        If trailingTrivia Is Nothing Then
          ' Leading doc comment (which may include whitespace). No trailing trivia.
          Return leadingTrivia.RawKind = SyntaxKind.DocumentationCommentExteriorTrivia AndAlso leadingTrivia.Flags = NodeFlags.IsNotMissing AndAlso
                 leadingTrivia.FullWidth <= s_maximumCachedTriviaWidth

        Else
          ' Leading whitespace and a trailing single space.
          Return leadingTrivia.RawKind = SyntaxKind.WhitespaceTrivia AndAlso leadingTrivia.Flags = NodeFlags.IsNotMissing AndAlso
                 trailingTrivia.RawKind = SyntaxKind.WhitespaceTrivia AndAlso trailingTrivia.Flags = NodeFlags.IsNotMissing AndAlso
                 trailingTrivia.FullWidth = 1 AndAlso trailingTrivia.ToFullString() = " " AndAlso
                 leadingTrivia.FullWidth <= s_maximumCachedTriviaWidth
        End If
      End Function

      Public Shared Function Create(leadingTrivia As GreenNode, trailingTrivia As GreenNode) As TriviaInfo
        Debug.Assert(leadingTrivia IsNot Nothing)
        ' PERF: Cache common kinds of TriviaInfo
        If ShouldCacheTriviaInfo(leadingTrivia, trailingTrivia) Then
          Dim retVal As TriviaInfo = Nothing
          SyncLock s_triviaInfoCache
            ' Note: Only the leading trivia is considered as a key into the cache. That works because
            ' we cache only a couple of different cases. In one case, the trailing trivia is Nothing
            ' and in the other it's a single space, and the two cases can be distinguished just by
            ' examining the Kind on the leading trivia. If we ever decide to cache more kinds of trivia
            ' this may have to be revisited.
            If s_triviaInfoCache.TryGetValue(leadingTrivia, retVal) Then
              Debug.Assert(trailingTrivia Is Nothing OrElse retVal._trailingTrivia.IsEquivalentTo(trailingTrivia))
              Debug.Assert(retVal._leadingTrivia.IsEquivalentTo(leadingTrivia))
            Else
              retVal = New TriviaInfo(leadingTrivia, trailingTrivia)
              s_triviaInfoCache.Add(leadingTrivia, retVal)
            End If
          End SyncLock
          Return retVal
        End If
        Return New TriviaInfo(leadingTrivia, trailingTrivia)
      End Function

      Public _leadingTrivia As GreenNode
      Public _trailingTrivia As GreenNode

      Public Sub New(reader As ObjectReader)
        _leadingTrivia = DirectCast(reader.ReadValue(), GreenNode)
        _trailingTrivia = DirectCast(reader.ReadValue(), GreenNode)
      End Sub

      Private ReadOnly Property IObjectWritable_ShouldReuseInSerialization As Boolean Implements IObjectWritable.ShouldReuseInSerialization
        Get
          Return ShouldCacheTriviaInfo(_leadingTrivia, _trailingTrivia)
        End Get
      End Property

      Public Sub WriteTo(writer As ObjectWriter) Implements IObjectWritable.WriteTo
        writer.WriteValue(_leadingTrivia)
        writer.WriteValue(_trailingTrivia)
      End Sub

    End Class

    Protected Sub New(kind As SyntaxKind, text As String, precedingTrivia As GreenNode, followingTrivia As GreenNode)
      MyBase.New(kind, text.Length)
      SetFlags(NodeFlags.IsNotMissing)
      _text = text
      If followingTrivia IsNot Nothing Then
        ' Don't propagate NoMissing in Init
        AdjustFlagsAndWidth(followingTrivia)
        _trailingTriviaOrTriviaInfo = followingTrivia
      End If

      If precedingTrivia IsNot Nothing Then
       ' Don't propagate NoMissing in Init
        AdjustFlagsAndWidth(precedingTrivia)
        _trailingTriviaOrTriviaInfo = TriviaInfo.Create(precedingTrivia, DirectCast(_trailingTriviaOrTriviaInfo, GreenNode))
      End If

      ClearFlagIfMissing()
    End Sub

    Protected Sub New(kind As SyntaxKind, errors As DiagnosticInfo(), text As String, precedingTrivia As GreenNode, followingTrivia As GreenNode)
      MyBase.New(kind, errors, text.Length)
      SetFlags(NodeFlags.IsNotMissing)
      _text = text
      If followingTrivia IsNot Nothing Then
        ' Don't propagate NoMissing in Init
        AdjustFlagsAndWidth(followingTrivia)
        _trailingTriviaOrTriviaInfo = followingTrivia
      End If
      If precedingTrivia IsNot Nothing Then
        ' Don't propagate NoMissing in Init
        AdjustFlagsAndWidth(precedingTrivia)
        _trailingTriviaOrTriviaInfo = TriviaInfo.Create(precedingTrivia, DirectCast(_trailingTriviaOrTriviaInfo, GreenNode))
      End If

      ClearFlagIfMissing()
    End Sub

    Protected Sub New(kind As SyntaxKind, errors As DiagnosticInfo(), annotations As SyntaxAnnotation(), text As String, precedingTrivia As GreenNode, followingTrivia As GreenNode)
      MyBase.New(kind, errors, annotations, text.Length)
      SetFlags(NodeFlags.IsNotMissing)
      _text = text
      If followingTrivia IsNot Nothing Then
        ' Don't propagate NoMissing in Init
        AdjustFlagsAndWidth(followingTrivia)
        _trailingTriviaOrTriviaInfo = followingTrivia
      End If
      If precedingTrivia IsNot Nothing Then
        ' Don't propagate NoMissing in Init
        AdjustFlagsAndWidth(precedingTrivia)
        _trailingTriviaOrTriviaInfo = TriviaInfo.Create(precedingTrivia, DirectCast(_trailingTriviaOrTriviaInfo, GreenNode))
      End If
      ClearFlagIfMissing()
    End Sub

    Friend Sub New(reader As ObjectReader)
      MyBase.New(reader)
      SetFlags(NodeFlags.IsNotMissing)
      _text = reader.ReadString()
      FullWidth = _text.Length
      _trailingTriviaOrTriviaInfo = reader.ReadValue()
      Dim info = TryCast(_trailingTriviaOrTriviaInfo, TriviaInfo)
      Dim followingTrivia = If(info IsNot Nothing, info._trailingTrivia, TryCast(_trailingTriviaOrTriviaInfo, GreenNode))
      Dim precedingTrivia = If(info IsNot Nothing, info._leadingTrivia, Nothing)
      If followingTrivia IsNot Nothing Then
        ' Don't propagate NoMissing in Init
        AdjustFlagsAndWidth(followingTrivia)
      End If
      If precedingTrivia IsNot Nothing Then
        ' Don't propagate NoMissing in Init
        AdjustFlagsAndWidth(precedingTrivia)
      End If

      ClearFlagIfMissing()
    End Sub

    Private Sub ClearFlagIfMissing()
       If Text.Length = 0 AndAlso Kind <> SyntaxKind.EndOfFileToken AndAlso Kind <> SyntaxKind.EmptyToken Then
         ' If a token has text then it is not missing.  The only 0 length tokens that are not considered missing are the end of file token because no text exists for this token 
         ' and the empty token which exists solely so that the empty statement has a token.
         ClearFlags(NodeFlags.IsNotMissing)
       End If
    End Sub

    Friend Overrides ReadOnly Property ShouldReuseInSerialization As Boolean
      Get
        Return MyBase.ShouldReuseInSerialization AndAlso FullWidth < Scanner.MAX_CACHED_TOKENSIZE
      End Get
    End Property

    Friend Overrides Sub WriteTo(writer As ObjectWriter)
      MyBase.WriteTo(writer)
      writer.WriteString(_text)
      writer.WriteValue(_trailingTriviaOrTriviaInfo)
    End Sub

    Friend ReadOnly Property Text As String
      Get
        Return _text
      End Get
    End Property

    Friend NotOverridable Overrides Function GetSlot(index As Integer) As GreenNode
      Throw ExceptionUtilities.Unreachable
    End Function

    ' Get the leading trivia as GreenNode array.
    Friend NotOverridable Overrides Function GetLeadingTrivia() As GreenNode
       Dim t = TryCast(_trailingTriviaOrTriviaInfo, TriviaInfo)
       If t IsNot Nothing Then Return t._leadingTrivia
       Return Nothing
    End Function

    Private ReadOnly Property _leadingTriviaWidth() As Integer
      Get
         Dim t = TryCast(_trailingTriviaOrTriviaInfo, TriviaInfo)
         If t IsNot Nothing Then Return t._leadingTrivia.FullWidth
         Return 0
      End Get
    End Property

        ' Get the width of the leading trivia
    Public NotOverridable Overrides Function GetLeadingTriviaWidth() As Integer
      Return _leadingTriviaWidth()
    End Function

        ' Get the following trivia as GreenNode array.
    Friend NotOverridable Overrides Function GetTrailingTrivia() As GreenNode
      Dim arr = TryCast(_trailingTriviaOrTriviaInfo, GreenNode)
      If arr IsNot Nothing Then Return arr
      Dim t = TryCast(_trailingTriviaOrTriviaInfo, TriviaInfo)
      If t IsNot Nothing Then Return t._trailingTrivia
      Return Nothing
    End Function

    ' Get the width of the following trivia
    Public NotOverridable Overrides Function GetTrailingTriviaWidth() As Integer
      Return FullWidth - _text.Length - _leadingTriviaWidth()
    End Function

    Friend NotOverridable Overrides Sub AddSyntaxErrors(accumulatedErrors As List(Of DiagnosticInfo))
      If GetDiagnostics IsNot Nothing Then  accumulatedErrors.AddRange(GetDiagnostics)
      Dim leadingTrivia = GetLeadingTrivia()
      If leadingTrivia IsNot Nothing Then
        Dim triviaList = New CoreInternalSyntax.SyntaxList(Of VisualBasicSyntaxNode)(leadingTrivia)
        For i = 0 To triviaList.Count - 1
          DirectCast(triviaList.ItemUntyped(i), VisualBasicSyntaxNode).AddSyntaxErrors(accumulatedErrors)
        Next
      End If
      Dim trailingTrivia = GetTrailingTrivia()
      If trailingTrivia IsNot Nothing Then
        Dim triviaList = New CoreInternalSyntax.SyntaxList(Of VisualBasicSyntaxNode)(trailingTrivia)
        For i = 0 To triviaList.Count - 1
          DirectCast(triviaList.ItemUntyped(i), VisualBasicSyntaxNode).AddSyntaxErrors(accumulatedErrors)
        Next
      End If
    End Sub

    Protected Overrides Sub WriteTokenTo(writer As System.IO.TextWriter, leading As Boolean, trailing As Boolean)
      If leading Then
        Dim leadingTrivia = GetLeadingTrivia()
        If leadingTrivia IsNot Nothing Then leadingTrivia.WriteTo(writer, True, True) 'Append leading trivia
      End If

      writer.Write(Text) 'Append text of token itself

      If trailing Then
        Dim trailingTrivia = GetTrailingTrivia()
        If trailingTrivia IsNot Nothing Then trailingTrivia.WriteTo(writer, True, True) ' Append trailing trivia
      End If
    End Sub

    Public NotOverridable Overrides Function Accept(visitor As VisualBasicSyntaxVisitor) As VisualBasicSyntaxNode
      Return visitor.VisitSyntaxToken(Me)
    End Function

    Public Overrides Function ToString() As String
      Return _text
    End Function

    Public NotOverridable Overrides ReadOnly Property IsToken As Boolean
      Get
        Return True
      End Get
    End Property

    ''' <summary> Helper to check whether the token is a keyword. </summary>
    Friend Overridable ReadOnly Property IsKeyword As Boolean
      Get
         Return False
      End Get
    End Property

    Friend Overridable ReadOnly Property ObjectValue As Object
      Get
        Return ValueText
      End Get
    End Property

    Public Overrides Function GetValue() As Object
      Return ObjectValue
    End Function

    Friend Overridable ReadOnly Property ValueText As String
      Get
        Return Text
      End Get
    End Property

    Public Overrides Function GetValueText() As String
      Return ValueText
    End Function

    ''' <summary> Helpers to check whether the token is a binary operator. </summary>
    ''' <returns>True if it is a binary operator</returns>
    Public Function IsBinaryOperator() As Boolean
      Select Case Kind
             Case SyntaxKind.MinusToken,
                  SyntaxKind.PlusToken,
                  SyntaxKind.AsteriskToken,
                  SyntaxKind.SlashToken,
                  SyntaxKind.BackslashToken,
                  SyntaxKind.CaretToken,
                  SyntaxKind.AmpersandToken,
                  SyntaxKind.LessThanLessThanToken,
                  SyntaxKind.GreaterThanGreaterThanToken,
                  SyntaxKind.ModKeyword,
                  SyntaxKind.OrKeyword,
                  SyntaxKind.OrElseKeyword,
                  SyntaxKind.XorKeyword,
                  SyntaxKind.AndKeyword,
                  SyntaxKind.AndAlsoKeyword,
                  SyntaxKind.LikeKeyword,
                  SyntaxKind.EqualsToken,
                  SyntaxKind.LessThanGreaterThanToken,
                  SyntaxKind.LessThanToken,
                  SyntaxKind.LessThanEqualsToken,
                  SyntaxKind.GreaterThanToken,
                  SyntaxKind.GreaterThanEqualsToken,
                  SyntaxKind.IsKeyword,
                  SyntaxKind.IsNotKeyword
                  Return True
      End Select
      Return False
    End Function

    ''' <summary> Check whether the token is a statement terminator. </summary>
    ''' <returns>True if it is statement terminator</returns>
    Friend ReadOnly Property IsEndOfLine As Boolean
      Get
        Return Kind = SyntaxKind.StatementTerminatorToken OrElse Kind = SyntaxKind.EndOfFileToken
      End Get
    End Property

    ''' <summary> Check whether token is end of text. </summary>
    Friend ReadOnly Property IsEndOfParse As Boolean
      Get
        Return Kind = SyntaxKind.EndOfFileToken
      End Get
    End Property

    ''' <summary> Create a new token with the trivia prepended to the existing preceding trivia. </summary>
    Public Shared Function AddLeadingTrivia(Of T As SyntaxToken)(token As T, newTrivia As CoreInternalSyntax.SyntaxList(Of GreenNode)) As T
      Debug.Assert(token IsNot Nothing)
      If newTrivia.Node Is Nothing Then Return token
      Dim oldTrivia = New CoreInternalSyntax.SyntaxList(Of VisualBasicSyntaxNode)(token.GetLeadingTrivia())
      Dim leadingTrivia As GreenNode
      If oldTrivia.Node Is Nothing Then
        leadingTrivia = newTrivia.Node
      Else
        Dim leadingTriviaBuilder = SyntaxListBuilder(Of VisualBasicSyntaxNode).Create()
        leadingTriviaBuilder.AddRange(newTrivia)
        leadingTriviaBuilder.AddRange(oldTrivia)
        leadingTrivia = leadingTriviaBuilder.ToList.Node
      End If
      Return DirectCast(token.WithLeadingTrivia(leadingTrivia), T)
    End Function

    ''' <summary> Create a new token with the trivia appended to the existing following trivia </summary>
    Public Shared Function AddTrailingTrivia(Of T As SyntaxToken)(token As T, newTrivia As CoreInternalSyntax.SyntaxList(Of GreenNode)) As T
      Debug.Assert(token IsNot Nothing)
      If newTrivia.Node Is Nothing Then Return token
      Dim oldTrivia = New CoreInternalSyntax.SyntaxList(Of VisualBasicSyntaxNode)(token.GetTrailingTrivia())
      Dim trailingTrivia As GreenNode
      If oldTrivia.Node Is Nothing Then
        trailingTrivia = newTrivia.Node
      Else
        Dim trailingTriviaBuilder = SyntaxListBuilder(Of VisualBasicSyntaxNode).Create()
        trailingTriviaBuilder.AddRange(oldTrivia)
        trailingTriviaBuilder.AddRange(newTrivia)
        trailingTrivia = trailingTriviaBuilder.ToList.Node
      End If
      Return DirectCast(token.WithTrailingTrivia(trailingTrivia), T)
    End Function

    Friend Shared Function Create(kind As SyntaxKind, Optional leading As GreenNode = Nothing, Optional trailing As GreenNode = Nothing, Optional text As String = Nothing) As SyntaxToken
      ' use default token text if text is nothing. If it's empty or anything else, use the given one
      Dim tokenText = If(text Is Nothing, SyntaxFacts.GetText(kind), text)
      If CInt(kind) >= SyntaxKind.AddHandlerKeyword Then
        If CInt(kind) <= SyntaxKind.YieldKeyword OrElse kind = SyntaxKind.NameOfKeyword Then
          Return New KeywordSyntax(kind, tokenText, leading, trailing)
        ElseIf CInt(kind) <= SyntaxKind.EndOfXmlToken OrElse
                    kind = SyntaxKind.EndOfInterpolatedStringToken OrElse
                    kind = SyntaxKind.DollarSignDoubleQuoteToken Then
          Return New PunctuationSyntax(kind, tokenText, leading, trailing)
        End If
      End If

      Throw ExceptionUtilities.UnexpectedValue(kind)
    End Function

    Public Shared Narrowing Operator CType(token As SyntaxToken) As Microsoft.CodeAnalysis.SyntaxToken
      Return New CodeAnalysis.SyntaxToken(Nothing, token, position:=0, index:=0)
    End Operator

    Public Overrides Function IsEquivalentTo(other As GreenNode) As Boolean
      If Not MyBase.IsEquivalentTo(other) Then Return False
      Dim otherToken = DirectCast(other, SyntaxToken)
      If Not String.Equals(Text, otherToken.Text, StringComparison.Ordinal) Then Return False
      If HasLeadingTrivia <> otherToken.HasLeadingTrivia OrElse HasTrailingTrivia <> otherToken.HasTrailingTrivia Then Return False
      If HasLeadingTrivia AndAlso Not GetLeadingTrivia().IsEquivalentTo(otherToken.GetLeadingTrivia()) Then Return False
      If HasTrailingTrivia AndAlso Not GetTrailingTrivia().IsEquivalentTo(otherToken.GetTrailingTrivia()) Then Return False
      Return True
    End Function

    Friend Overrides Function CreateRed(parent As SyntaxNode, position As Integer) As SyntaxNode
      Throw ExceptionUtilities.Unreachable
    End Function

  End Class

  Friend Partial Class XmlTextTokenSyntax

    Friend NotOverridable Overrides ReadOnly Property ValueText As String
      Get
        Return Value
      End Get
    End Property
  End Class

  Friend Partial Class InterpolatedStringTextTokenSyntax

    Friend NotOverridable Overrides ReadOnly Property ValueText As String
      Get
        Return Value
      End Get
    End Property

  End Class

  Friend Partial Class KeywordSyntax

    Friend NotOverridable Overrides ReadOnly Property ObjectValue As Object
      Get
        Select Case MyBase.Kind
               Case SyntaxKind.NothingKeyword   : Return Nothing
               Case SyntaxKind.TrueKeyword      : Return Boxes.BoxedTrue
               Case SyntaxKind.FalseKeyword     : Return Boxes.BoxedFalse
               Case Else                        : Return Text
        End Select
      End Get
    End Property

    Friend NotOverridable Overrides ReadOnly Property IsKeyword As Boolean
      Get
        Return True
      End Get
    End Property

  End Class

End Namespace
