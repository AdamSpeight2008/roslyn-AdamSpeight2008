' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports System.Runtime.CompilerServices
Imports Microsoft.CodeAnalysis.Syntax.InternalSyntax
Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.CodeAnalysis.VisualBasic.Symbols
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports InternalSyntaxFactory = Microsoft.CodeAnalysis.VisualBasic.Syntax.InternalSyntax.SyntaxFactory

Namespace Microsoft.CodeAnalysis.VisualBasic.Syntax.InternalSyntax

    Friend Module SyntaxListExtensions

        <Extension>
        Friend Function ToListAndFree(Of T As VisualBasicSyntaxNode)(builder As SyntaxListBuilder(Of T), pool As SyntaxListPool) As CodeAnalysis.Syntax.InternalSyntax.SyntaxList(Of T)
            Dim results = builder.ToList()
            pool.Free(builder)
            Return results
        End Function

        <Extension>
        Friend Function ToListAndFree(Of T As VisualBasicSyntaxNode)(builder As SeparatedSyntaxListBuilder(Of T), pool As SyntaxListPool) As CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList(Of T)
            Dim results = builder.ToList()
            pool.Free(builder)
            Return results
        End Function
        <Extension>
        Friend Function ToListAndFree(builder As SeparatedSyntaxListBuilder(Of GreenNode), pool As SyntaxListPool) As CodeAnalysis.Syntax.InternalSyntax.SeparatedSyntaxList(Of GreenNode)
            Dim results = builder.ToList()
            pool.Free(builder)
            Return results
        End Function

        <Extension>
        Friend Function ToListAndFree(builder As SyntaxListBuilder(Of GreenNode), pool As SyntaxListPool) As CodeAnalysis.Syntax.InternalSyntax.SyntaxList(Of GreenNode)
            Dim results = builder.ToList()
            pool.Free(builder)
            Return results
        End Function

    End Module

End Namespace
