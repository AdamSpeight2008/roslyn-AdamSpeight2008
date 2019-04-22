﻿' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.CodeAnalysis.VisualBasic.Symbols
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
'-----------------------------------------------------------------------------
' Contains the definition of the BlockContext
'-----------------------------------------------------------------------------

Namespace Microsoft.CodeAnalysis.VisualBasic.Syntax.InternalSyntax

    Friend NotInheritable Class ConstDeclarationBlockContext
        Inherits DeclarationContext

        Friend Sub New(statement As StatementSyntax, prevContext As BlockContext)
            MyBase.New(SyntaxKind.ConstBlock, statement, prevContext)
        End Sub

        Friend Overrides Function CreateBlockSyntax(endStmt As StatementSyntax) As VisualBasicSyntaxNode
            Debug.Assert(BeginStatement IsNot Nothing)
            Dim beginBlock As ConstBlockStatementSyntax = Nothing
            Dim endBlock As EndBlockStatementSyntax = DirectCast(endStmt, EndBlockStatementSyntax)
            GetBeginEndStatements(beginBlock, endBlock)

            Dim result = SyntaxFactory.ConstBlock(beginBlock, Body(), endBlock)

            FreeStatements()

            Return result
        End Function

        Friend Overrides Function ProcessSyntax(node As VisualBasicSyntaxNode) As BlockContext
            Select Case node.Kind
                Case SyntaxKind.ConstBlockMemberDeclaration
                    Add(node)

                Case Else
                     If IsExecutableStatementOrItsPart(node) Then
                        ' do not end the block - an executable statement can't be handled outside of a method
                        Add(Parser.ReportSyntaxError(node, ERRID.ERR_InvInsideConstBlock))
                    Else
                        ' End the current block and add the block to the context above which should be able to handle this kind of statement.
                        Dim outerContext = EndBlock(Nothing)
                        Return outerContext.ProcessSyntax(Parser.ReportSyntaxError(node, ERRID.ERR_InvInsideEndsConst))
                    End If
            End Select

            Return Me
        End Function

        Friend Overrides Function TryLinkSyntax(node As VisualBasicSyntaxNode, ByRef newContext As BlockContext) As LinkResult
            newContext = Nothing
            Select Case node.Kind

                Case SyntaxKind.ConstBlockMemberDeclaration
                    Return UseSyntax(node, newContext)

                Case SyntaxKind.NamespaceBlock,
                    SyntaxKind.ModuleBlock,
                    SyntaxKind.EnumBlock,
                    SyntaxKind.ClassBlock,
                    SyntaxKind.StructureBlock,
                    SyntaxKind.InterfaceBlock,
                    SyntaxKind.SubBlock,
                    SyntaxKind.ConstructorBlock,
                    SyntaxKind.FunctionBlock,
                    SyntaxKind.OperatorBlock,
                    SyntaxKind.PropertyBlock,
                    SyntaxKind.EventBlock,
                    SyntaxKind.ConstBlock

                    ' These blocks need to be crumbled so that the error is correctly reported on
                    ' the statement that begins the block. If they aren't crumbled the block is added and
                    ' the error will be on the block. This list must be kept in sync with the blocks
                    ' handled by the declaration context.
                    newContext = Me
                    Return LinkResult.Crumble

                Case Else
                    Return MyBase.TryLinkSyntax(node, newContext)
            End Select
        End Function

    End Class

End Namespace
