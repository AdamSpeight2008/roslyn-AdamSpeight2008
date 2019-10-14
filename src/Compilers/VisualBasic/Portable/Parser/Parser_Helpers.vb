' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

'-----------------------------------------------------------------------------
' Contains the definition of the Scanner, which produces tokens from text 
'-----------------------------------------------------------------------------

Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Microsoft.CodeAnalysis.PooledObjects
Imports Microsoft.CodeAnalysis.Syntax.InternalSyntax
Imports Microsoft.CodeAnalysis.Text
Imports CoreInternalSyntax = Microsoft.CodeAnalysis.Syntax.InternalSyntax
Imports InternalSyntaxFactory = Microsoft.CodeAnalysis.VisualBasic.Syntax.InternalSyntax.SyntaxFactory

Namespace Microsoft.CodeAnalysis.VisualBasic.Syntax.InternalSyntax

    Partial Friend Class Parser

        Private Function TryParseKeywordAndExpression(
                                                        ofKind As SyntaxKind,
                                            <Out> ByRef output As KeywordSyntax,
                                            <Out> ByRef expr As ExpressionSyntax,
                                               Optional isOptionalKeyword As Boolean = False,
                                               Optional operatorPrecedence As OperatorPrecedence = OperatorPrecedence.PrecedenceNone,
                                               Optional bailIfFirstTokenRejected As Boolean = False,
                                               Optional resyncTokens() As SyntaxKind = Nothing
                                                      ) As Boolean
            Dim hasToken = TryParseKeyword(ofKind, output, ,Not isOptionalKeyword)
            If hasToken = False AndAlso not isOptionalKeyword Then Return false
            Return AndExpression(expr, operatorPrecedence, bailIfFirstTokenRejected,  resyncTokens)
        End Function

        Private Function TryParseTokenAndExpression(OF T As SyntaxToken)(
                                                    ofKind As SyntaxKind,
                                        <Out> ByRef output As T,
                                        <Out> ByRef expr As ExpressionSyntax,
                                           Optional operatorPrecedence As OperatorPrecedence = OperatorPrecedence.PrecedenceNone,
                                           Optional bailIfFirstTokenRejected As Boolean = False,
                                           Optional resyncTokens() As SyntaxKind = Nothing
                                                  ) As Boolean
            Dim hasToken = TryGetTokenAndEatNewLine(ofKind, output)
            If hasToken Then Return AndExpression(expr, operatorPrecedence, bailIfFirstTokenRejected, resyncTokens)
            Return false
        End Function

        Private Function AndExpression(
                            <Out> ByRef expr As ExpressionSyntax,
                                        operatorPrecedence As OperatorPrecedence,
                                        bailIfFirstTokenRejected As Boolean,
                                        resyncTokens() As SyntaxKind
                                      ) As Boolean

            expr = ParseExpressionCore(operatorPrecedence, bailIfFirstTokenRejected)
            If expr Is Nothing Then Return false
            If expr.ContainsDiagnostics Then
                If resyncTokens Is Nothing Then
                    expr = ResyncAt(expr)
                Elseif resyncTokens.Length = 0 Then
                    expr = ResyncAt(expr)
                Else
                    expr = ResyncAt(expr, resyncTokens)
                End If
            End If
            Return True
        End Function

        Private Function ParseKeyword(
                                       ofKind As SyntaxKind,
                              Optional consume As Boolean = True
                                     ) As KeywordSyntax
            Dim keyword = If(SyntaxFacts.IsKeywordKind(ofKind) AndAlso CurrentToken.Kind = ofKind, DirectCast(CurrentToken, KeywordSyntax), Nothing)
            If keyword IsNot Nothing AndAlso consume Then GetNextToken
            Return keyword
        End Function

        Private Function TryParseKeyword(
                                          ofKind As SyntaxKind,
                              <Out> ByRef keyword As KeywordSyntax,
                                 Optional consume As Boolean = True,
                                 Optional reportMissing As Boolean = False
                                        ) As Boolean
            keyword = ParseKeyword(ofkind, consume)
            If keyword IsNot Nothing Then Return True
            If reportMissing Then keyword = InternalSyntaxFactory.MissingKeyword(ofKind)
            Return False
        End Function

        Private Function TryParseContextualKeyword(
                                                    ofKind As SyntaxKind,
                                        <Out> ByRef keyword As KeywordSyntax
                                                  ) As Boolean
            Return TryTokenAsContextualKeyword(CurrentToken, ofKind, keyword)
        End Function

        Private Function TryParseAsType(
                             <Out> ByRef asType As SimpleAsClauseSyntax,
                                Optional includeAttributes As Boolean = False,
                                Optional resyncOnType As Boolean = False,
                                Optional resyncTokens As SyntaxKind() = Nothing
                             ) As Boolean
            Dim asKeyword As KeywordSyntax = Nothing
            If Not TryParseKeyword(SyntaxKind.AsKeyword, asKeyword, reportMissing:=False) Then
                asType = Nothing
                Return False
            End If

            Dim attributes As CoreInternalSyntax.SyntaxList(Of AttributeListSyntax) = Nothing
            If includeAttributes Then
                If CurrentToken.Kind = SyntaxKind.LessThanToken Then
                    attributes = ParseAttributeLists(False)
                End If
            End If

            Dim typeName = ParseGeneralType()
            If typeName.ContainsDiagnostics AndAlso resyncOnType Then
                If resyncTokens IsNot Nothing Andalso resyncTokens.Length > 0 Then
                    typeName = ResyncAt(typeName, resyncTokens)
                Else
                    typeName = ResyncAt(typeName)
                End If
            End If

            asType = SyntaxFactory.SimpleAsClause(asKeyword, attributes, typeName)
            Return True
        End Function

        Private Function TryParseEqualsExpression(
                                       <Out> ByRef equalsExpr As EqualsValueSyntax,
                                          Optional doResync As Boolean = True,
                                          Optional resyncTokens As SyntaxKind() = Nothing
                                                 ) As Boolean
            Dim equalsToken As PunctuationSyntax = Nothing
            If TryParseEquals(equalsToken) Then
                Dim expr = ParseExpressionCore()
                If doResync AndAlso expr.ContainsDiagnostics Then
                    ' Resync at EOS so we don't get any more errors.
                    If resyncTokens Is Nothing Then
                        expr = ResyncAt(expr)
                    Else
                        expr = ResyncAt(expr, resyncTokens)
                    End if
                End If

                equalsExpr = SyntaxFactory.EqualsValue(equalsToken, expr)
                Return true
            End If
            Return False
        End Function
  
        Private Function TryParseEquals(<Out> ByRef equalsToken As PunctuationSyntax) As Boolean
            Return TryGetTokenAndEatNewLine(SyntaxKind.equalsToken, equalsToken)
        End Function

        Private Function TryParseDotAndNewLine(<Out> ByRef dotToken As PunctuationSyntax) As Boolean
            Return TryGetTokenAndEatNewLine(SyntaxKind.DotToken, dotToken)
        End Function

        Private Function TryParseDot(<Out> ByRef dotToken As PunctuationSyntax) As Boolean
            Return TryGetToken(SyntaxKind.DotToken, dotToken)
        End Function
        Private Function TryParseComma(<Out> ByRef comma As PunctuationSyntax) As Boolean
            Return TryGetTokenAndEatNewLine(SyntaxKind.CommaToken, comma)
        End Function

        Private Function TryParseMinus(<Out> ByRef minus As PunctuationSyntax) As Boolean
            Return TryGetToken(SyntaxKind.MinusToken, minus)
        End Function

        Private Function TryParseCloseParen(ByRef closeParen As PunctuationSyntax) As Boolean
            Return TryEatNewLineAndGetToken(SyntaxKind.CloseParenToken, closeParen, createIfMissing:=True)
        End Function

        Private Function TryParseOpenParen(ByRef openParen As PunctuationSyntax) As Boolean
            Return TryGetTokenAndEatNewLine(SyntaxKind.OpenParenToken, openParen)
        End Function

        <Conditional("DEBUG")>
        Friend Sub DebugAssert_CalledOnCorrectToken(
                                                    kind As SyntaxKind,
                        <CallerMemberName> Optional callerName As String = Nothing)
            Debug.Assert(CurrentToken.Kind = kind, $"{callerName} called on wrond token.")
        End Sub

        <Conditional("DEBUG")>
        Friend Sub DebugAssert_CalledOnCorrectToken(
                                                    kind1 As SyntaxKind,
                                                    kind2 As SyntaxKind,
                        <CallerMemberName> Optional callerName As String = Nothing)
            Debug.Assert(CurrentToken.Kind = kind1 Or CurrentToken.Kind = kind2, $"{callerName} called on wrond token.")
        End Sub
        
        <Conditional("DEBUG")>
        Friend Sub DebugAssert_CalledOnCorrectToken(
                                                    kind1 As SyntaxKind,
                                                    kind2 As SyntaxKind,
                                                    kind3 As SyntaxKind,
                        <CallerMemberName> Optional callerName As String = Nothing)
            Debug.Assert(CurrentToken.Kind = kind1 Or CurrentToken.Kind = kind2 Or CurrentToken.Kind = kind3, $"{callerName} called on wrond token.")
        End Sub
        
        <Conditional("DEBUG")>
        Friend Sub DebugAssert_CalledOnCorrectToken(
                                                    kind1 As SyntaxKind, kind2 As SyntaxKind, kind3 As SyntaxKind, kind4 As SyntaxKind,
                        <CallerMemberName> Optional callerName As String = Nothing)
            Debug.Assert(CurrentToken.Kind = kind1 Or CurrentToken.Kind = kind2 Or
                         CurrentToken.Kind = kind3 Or CurrentToken.Kind = kind4, $"{callerName} called on wrond token.")
        End Sub

        <Conditional("DEBUG")>
        Friend Sub DebugAssert_CalledOnCorrectToken(
                                                    kind1 As SyntaxKind, kind2 As SyntaxKind, kind3 As SyntaxKind, kind4 As SyntaxKind, kind5 As SyntaxKind,
                        <CallerMemberName> Optional callerName As String = Nothing)
            Debug.Assert(CurrentToken.Kind = kind1 Or CurrentToken.Kind = kind2 Or 
                         CurrentToken.Kind = kind3 Or CurrentToken.Kind = kind4 Or
                         CurrentToken.Kind = kind5, $"{callerName} called on wrond token.")
        End Sub

        <Conditional("DEBUG")>
        Friend Sub DebugAssert_CalledOnCorrectToken(
                                                    kinds() As SyntaxKind,
                        <CallerMemberName> Optional callerName As String = Nothing)
            Debug.Assert(kinds IsNot Nothing, $"{NameOf(kinds)} can not be null.")
            Debug.Assert(kinds.Length >= 1, $"{NameOf(kinds)} must contain at least one {NameOf(SyntaxKind)}.")
            Debug.Assert(IsToken(CurrentToken, kinds), $"{callerName} called on wrond token.")
        End Sub

    End Class

End Namespace
