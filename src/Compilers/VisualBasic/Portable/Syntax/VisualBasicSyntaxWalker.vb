' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Namespace Microsoft.CodeAnalysis.VisualBasic

  ''' <summary>
  ''' Represents a <see cref="VisualBasicSyntaxVisitor"/> that descends an entire <see cref="SyntaxNode"/> tree
  ''' visiting each SyntaxNode and its child <see cref="SyntaxNode"/>s and <see cref="SyntaxToken"/>s in depth-first order.
  ''' </summary>
  Public MustInherit Class VisualBasicSyntaxWalker
    Inherits VisualBasicSyntaxVisitor

    Protected ReadOnly Property Depth As SyntaxWalkerDepth

    Protected Sub New(Optional depth As SyntaxWalkerDepth = SyntaxWalkerDepth.Node)
      Me.Depth = depth
    End Sub

    Private _recursionDepth As Integer

    Public Overrides Sub Visit(node As SyntaxNode)
      If node Is Nothing Then Exit Sub
      _recursionDepth += 1

      StackGuard.EnsureSufficientExecutionStack(_recursionDepth)
      DirectCast(node, VisualBasicSyntaxNode).Accept(Me)
      _recursionDepth -= 1
    End Sub

    Public Overrides Sub DefaultVisit(node As SyntaxNode)
      Dim list = node.ChildNodesAndTokens()
      Dim childCnt = list.Count
      Dim i As Integer = 0

      Do
        Dim child = list(i)
        i = i + 1
        Dim asNode = child.AsNode()
        If asNode IsNot Nothing Then
          If Depth >= SyntaxWalkerDepth.Node Then Me.Visit(asNode)
        Else
          If Depth >= SyntaxWalkerDepth.Token Then Me.VisitToken(child.AsToken())
        End If
        Loop While i < childCnt
      End Sub

      Public Overridable Sub VisitToken(token As SyntaxToken)
        If Depth < SyntaxWalkerDepth.Trivia Then Exit Sub
        Me.VisitLeadingTrivia(token)
        Me.VisitTrailingTrivia(token)
      End Sub

      Public Overridable Sub VisitLeadingTrivia(token As SyntaxToken)
        If Not token.HasLeadingTrivia Then Exit Sub
        For Each tr In token.LeadingTrivia
          VisitTrivia(tr)
        Next
      End Sub

      Public Overridable Sub VisitTrailingTrivia(token As SyntaxToken)
        If Not token.HasTrailingTrivia Then Return
        For Each tr In token.TrailingTrivia
          VisitTrivia(tr)
        Next
      End Sub

      Public Overridable Sub VisitTrivia(trivia As SyntaxTrivia)
        If Depth >= SyntaxWalkerDepth.StructuredTrivia AndAlso trivia.HasStructure Then
          Visit(DirectCast(trivia.GetStructure(), VisualBasicSyntaxNode))
        End If
      End Sub

    End Class

End Namespace
