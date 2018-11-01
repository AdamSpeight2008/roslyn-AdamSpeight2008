Imports System.Runtime.CompilerServices

Namespace Microsoft.CodeAnalysis.VisualBasic

    Public Module Extensions
        <Extension>
        Public Function IsAnyOf(value As SymbolKind, ParamArray values As SymbolKind()) As Boolean
            For i = 0 To values.Count - 1
                If value = values(i) Then Return True
            Next
            Return False
        End Function
        <Extension>
        Public Function IsAnyOf(Of T As IComparable(Of T))(value As T, ParamArray values As T()) As Boolean
            Dim i = 0
            While i < values.Count
                Dim cmp = value.CompareTo(values(i))
                If cmp = 0 Then Return True
            End While
            Return False
        End Function

    End Module

End Namespace
