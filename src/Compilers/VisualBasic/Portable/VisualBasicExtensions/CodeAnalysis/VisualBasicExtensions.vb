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

Namespace Microsoft.CodeAnalysis

    ''' <summary> Addition Visual Basic syntax extension methods. </summary>
    Public Partial Module VisualBasicExtensions

        ''' <summary> Determines if <see cref="SyntaxTrivia"/> is of a specified kind. </summary>
        ''' <param name="trivia">The source trivia.</param>
        ''' <param name="kind">The syntax kind to test for.</param>
        ''' <returns><see langword="true"/> if the trivia is of the specified kind; otherwise, <see langword="false"/>.</returns>
        <Extension>
        Public Function IsKind(trivia As SyntaxTrivia, kind As SyntaxKind) As Boolean
            Return trivia.RawKind = kind
        End Function

        ''' <summary> Determines if <see cref="SyntaxToken"/> is of a specified kind. </summary>
        ''' <param name="token">The source token.</param>
        ''' <param name="kind">The syntax kind to test for.</param>
        ''' <returns><see langword="true"/> if the token is of the specified kind; otherwise, <see langword="false"/>.</returns>
        <Extension>
        Public Function IsKind(token As SyntaxToken, kind As SyntaxKind) As Boolean
            Return token.RawKind = kind
        End Function

        ''' <summary> Determines if <see cref="SyntaxNode"/> is of a specified kind. </summary>
        ''' <param name="node">The Source node.</param>
        ''' <param name="kind">The syntax kind  to test for.</param>
        ''' <returns><see langword="true"/> if the node is of the specified kind; otherwise, <see langword="false"/>.</returns>
        <Extension>
        Public Function IsKind(node As SyntaxNode, kind As SyntaxKind) As Boolean
            Return node IsNot Nothing AndAlso node.RawKind = kind
        End Function

        ''' <summary> Determines if <see cref="SyntaxNodeOrToken"/> is of a specified kind. </summary>
        ''' <param name="nodeOrToken">The source node or token.</param>
        ''' <param name="kind">The syntax kind to test for.</param>
        ''' <returns><see langword="true"/> if the node or token is of the specified kind; otherwise, <see langword="false"/>.</returns>
        <Extension>
        Public Function IsKind(nodeOrToken As SyntaxNodeOrToken, kind As SyntaxKind) As Boolean
            Return nodeOrToken.RawKind = kind
        End Function

        ''' <summary> Returns the index of the first node of a specified kind in the node list. </summary>
        ''' <param name="list">Node list.</param>
        ''' <param name="kind">The <see cref="SyntaxKind"/> to find.</param>
        ''' <returns>Returns non-negative index if the list contains a node which matches <paramref name="kind"/>, -1 otherwise.</returns>
        <Extension>
        Public Function IndexOf(Of TNode As SyntaxNode)(list As SyntaxList(Of TNode), kind As SyntaxKind) As Integer
            Return list.IndexOf(CType(kind, Integer))
        End Function

        ''' <summary> Tests whether a list contains node of a particular kind. </summary>
        ''' <param name="kind">The <see cref="SyntaxKind"/> to test for.</param>
        ''' <returns>Returns true if the list contains a token which matches <paramref name="kind"/></returns>
        <Extension>
        Public Function Any(Of TNode As SyntaxNode)(list As SyntaxList(Of TNode), kind As SyntaxKind) As Boolean
            Return list.IndexOf(kind) >= 0
        End Function

        ''' <summary> Returns the index of the first node of a specified kind in the node list. </summary>
        ''' <param name="list">Node list.</param>
        ''' <param name="kind">The <see cref="SyntaxKind"/> to find.</param>
        ''' <returns>Returns non-negative index if the list contains a node which matches <paramref name="kind"/>, -1 otherwise.</returns>
        <Extension>
        Public Function IndexOf(Of TNode As SyntaxNode)(list As SeparatedSyntaxList(Of TNode), kind As SyntaxKind) As Integer
            Return list.IndexOf(CType(kind, Integer))
        End Function

        ''' <summary> Tests whether a list contains node of a particular kind. </summary>
        ''' <param name="kind">The <see cref="SyntaxKind"/> to test for.</param>
        ''' <returns>Returns true if the list contains a token which matches <paramref name="kind"/></returns>
        <Extension>
        Public Function Any(Of TNode As SyntaxNode)(list As SeparatedSyntaxList(Of TNode), kind As SyntaxKind) As Boolean
            Return list.IndexOf(kind) >= 0
        End Function

        ''' <summary> Returns the index of the first trivia of a specified kind in the trivia list. </summary>
        ''' <param name="list">Trivia list.</param>
        ''' <param name="kind">The <see cref="SyntaxKind"/> to find.</param>
        ''' <returns>Returns non-negative index if the list contains a trivia which matches <paramref name="kind"/>, -1 otherwise.</returns>
        <Extension>
        Public Function IndexOf(list As SyntaxTriviaList, kind As SyntaxKind) As Integer
            Return list.IndexOf(CType(kind, Integer))
        End Function

        ''' <summary> Tests whether a list contains trivia of a particular kind. </summary>
        ''' <param name="kind">The <see cref="SyntaxKind"/> to test for.</param>
        ''' <returns>Returns true if the list contains a trivia which matches <paramref name="kind"/></returns>
        <Extension>
        Public Function Any(list As SyntaxTriviaList, kind As SyntaxKind) As Boolean
            Return list.IndexOf(kind) >= 0
        End Function

        ''' <summary> Returns the index of the first token of a specified kind in the token list. </summary>
        ''' <param name="list">Token list.</param>
        ''' <param name="kind">The <see cref="SyntaxKind"/> to find.</param>
        ''' <returns>Returns non-negative index if the list contains a token which matches <paramref name="kind"/>, -1 otherwise.</returns>
        <Extension>
        Public Function IndexOf(list As SyntaxTokenList, kind As SyntaxKind) As Integer
            Return list.IndexOf(CType(kind, Integer))
        End Function

        ''' <summary> Tests whether a list contains token of a particular kind. </summary>
        ''' <param name="kind">The <see cref="SyntaxKind"/> to test for.</param>
        ''' <returns>Returns true if the list contains a token which matches <paramref name="kind"/></returns>
        <Extension>
        Public Function Any(list As SyntaxTokenList, kind As SyntaxKind) As Boolean
            Return list.IndexOf(kind) >= 0
        End Function

        <Extension>
        Friend Function FirstOrDefault(list As SyntaxTokenList, kind As SyntaxKind) As SyntaxToken
            Dim index = list.IndexOf(kind)
            Return If(index >= 0, list(index), Nothing)
        End Function

        <Extension>
        Friend Function First(list As SyntaxTokenList, kind As SyntaxKind) As SyntaxToken
            Dim index = list.IndexOf(kind)
            If index < 0 Then
                Throw New InvalidOperationException()
            End If
            Return list(index)
        End Function

    End Module

End Namespace
