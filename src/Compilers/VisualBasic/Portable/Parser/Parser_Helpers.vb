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

        Private Function TryParseKeyword(
                                          ofKind As SyntaxKind,
                              <Out> ByRef keyword As KeywordSyntax,
                                 Optional reportMissing As Boolean = False
                                        ) As Boolean
            keyword = Nothing
            Dim valid As Boolean = SyntaxFacts.IsKeywordKind(ofKind)
            If valid Then
                valid = TryGetToken(Of KeywordSyntax)(ofKind, keyword)
                If Not valid Then
                    If reportMissing Then
                        keyword = HandleUnexpectedKeyword(ofKind)
                    Else
                        keyword = Nothing
                    End If
                End If
            End If
            Return valid
        End Function

        Private Function TryParseContextualKeyword(ofKind As SyntaxKind, <Out> ByRef keyword As KeywordSyntax) As Boolean
            Return TryTokenAsContextualKeyword(CurrentToken, ofKind, keyword)
        End Function

        Private Function TryParseAsType(<Out> ByRef asType As SimpleAsClauseSyntax, Optional includeAttributes As Boolean = False) As Boolean
            Dim asKeyword As KeywordSyntax = Nothing
            If Not TryParseKeyword(SyntaxKind.AsKeyword, asKeyword, reportMissing:=False) Then
                asType = Nothing
                Return False
            End If
            Dim typeName = ParseGeneralType()
            Dim attributes As CoreInternalSyntax.SyntaxList(Of AttributeListSyntax) = Nothing
            If includeAttributes Then attributes = ParseAttributeLists(False)
            asType = SyntaxFactory.SimpleAsClause(asKeyword, attributes, typeName)
            Return True
        End Function

        Private Function TryParseComma(<Out> ByRef comma As PunctuationSyntax) As Boolean
            Return TryGetTokenAndEatNewLine(SyntaxKind.CommaToken, comma)
        End Function

        <Conditional("DEBUG")>
        Friend Sub DebugAssert_CalledOnCorrectToken(
                                                    kind As SyntaxKind,
                        <CallerMemberName> Optional callerName As String = Nothing)
            Debug.Assert(CurrentToken.Kind = kind, $"{callerName} called on wrond token.")
        End Sub
        <Conditional("DEBUG")>
        Friend Sub DebugAssert_CalledOnCorrectToken(
                                                    kinds() As SyntaxKind,
                        <CallerMemberName> Optional callerName As String = Nothing)
            Debug.Assert(kinds IsNot Nothing, $"{NameOf(kinds)} can not be null.")
            Debug.Assert(kinds.Length >= 1, $"{NameOf(kinds)} must contain at least one {NameOf(SyntaxKind)}.")
            Debug.Assert(kinds.Contains(CurrentToken.Kind), $"{callerName} called on wrond token.")
        End Sub
    End Class

End Namespace
