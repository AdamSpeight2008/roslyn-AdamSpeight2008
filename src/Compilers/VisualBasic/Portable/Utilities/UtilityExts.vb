' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.CodeAnalysis.VisualBasic.Symbols
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

'TODO - This is copied from C# and should be moved to common assemble.
Namespace Microsoft.CodeAnalysis.VisualBasic

  Friend Module UtilityExts
    #Region "Comparision"
    <Extension>
    Friend Function InRange(value As SByte, x As SByte, y As SByte) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Friend Function InRange(value As Int16, x As Int16, y As Int16) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Friend Function InRange(value As Int32, x As Int32, y As Int32) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Friend Function InRange(value As Int64, x As Int64, y As Int64) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Friend Function InRange(value As Byte, x As Byte, y As Byte) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Friend Function InRange(value As UInt16, x As UInt16, y As UInt16) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Friend Function InRange(value As UInt32, x As UInt32, y As UInt32) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Friend Function InRange(value As UInt64, x As UInt64, y As UInt64) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Friend Function InRange(value As Decimal, x As Decimal, y As Decimal) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Friend Function InRange(value As Single, x As Single, y As Single) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Friend Function InRange(value As Double, x As Double, y As Double) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Friend Function InRange(value As String, x As String, y As String) As Boolean
      Return (x <= value) AndAlso (value <= y)
    End Function
    <Extension>
    Public Function InRange(of T As IComparable(of T))(value As T, x As T, y As T) As Boolean
      Return (x.CompareTo(value)<=0 AndAlso value.CompareTo(y)<=0)
    End Function
#End Region

    <Extension>
    Friend Sub SwapWith(Of T)(ByRef x As T,ByRef y As T)
      Dim tmp = x
      x = y
      y = tmp
    End Sub

  End Module

End Namespace
