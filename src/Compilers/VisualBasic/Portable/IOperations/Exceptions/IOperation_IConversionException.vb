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
Imports Microsoft.CodeAnalysis.VisualBasic.SemanticModel_Extensions
Imports Microsoft.CodeAnalysis.VisualBasic.SemanticModel_Validation

Namespace Microsoft.CodeAnalysis.VisualBasic
    Namespace IOperations.Exceptions

        Friend Class IOperation_IConversionAssignmentExeception
            Inherits Microsoft.CodeAnalysis.IOperationArgumentException

            Public Sub New(IOperationName As String, ArgumentName As String, argumentValue As String)
                MyBase.New(VBResources.IConversionExpressionIsNotVisualBasicConversion, IOperationName, ArgumentName, argumentValue)
            End Sub
        End Class

    End Namespace
End Namespace
