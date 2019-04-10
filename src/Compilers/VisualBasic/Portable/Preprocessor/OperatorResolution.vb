﻿' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.CodeAnalysis.VisualBasic.Symbols
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

' TODO: this is not in Preprocessor namespace as it may be generally useful.
Namespace Microsoft.CodeAnalysis.VisualBasic.Syntax.InternalSyntax
    Friend Module OperatorResolution

        Private Enum TableKind
            Addition
            SubtractionMultiplicationModulo
            Division
            Power
            IntegerDivision
            Shift
            Logical
            Bitwise
            Relational
            ConcatenationLike
        End Enum

        ' TODO: need to fix the tables and remove the mapping. 
        ' It only exists because tables and enum have different order
        Private Function TypeCodeToIndex(specialType As SpecialType) As Integer
            Select Case specialType
                Case SpecialType.None
                    Return 0
                Case SpecialType.System_Boolean
                    Return 1
                Case SpecialType.System_SByte
                    Return 2
                Case SpecialType.System_Byte
                    Return 3
                Case SpecialType.System_Int16
                    Return 4
                Case SpecialType.System_UInt16
                    Return 5
                Case SpecialType.System_Int32
                    Return 6
                Case SpecialType.System_UInt32
                    Return 7
                Case SpecialType.System_Int64
                    Return 8
                Case SpecialType.System_UInt64
                    Return 9
                Case SpecialType.System_Decimal
                    Return 10
                Case SpecialType.System_Single
                    Return 11
                Case SpecialType.System_Double
                    Return 12
                Case SpecialType.System_DateTime
                    Return 13
                Case SpecialType.System_Char
                    Return 14
                Case SpecialType.System_String
                    Return 15
                Case SpecialType.System_Object
                    Return 16
            End Select
            Throw ExceptionUtilities.UnexpectedValue(specialType)
        End Function

        ' PERF: Using Byte instead of SpecialType because we want the compiler to use array literal initialization.
        '       The most natural type choice, Enum arrays, are not blittable due to a CLR limitation.
        Private ReadOnly s_table(,,) As Byte

        Sub New()
            ' */
            ' /****************************************************************************************
            ' BEGIN intrinsic operator tables
            ' ****************************************************************************************/

            Const t___r4 As Byte = CType(SpecialType.System_Single, Byte)
            Const t___r8 As Byte = CType(SpecialType.System_Double, Byte)
            Const t__dec As Byte = CType(SpecialType.System_Decimal, Byte)
            Const t__str As Byte = CType(SpecialType.System_String, Byte)

            Const t__bad As Byte = CType(SpecialType.None, Byte)
            Const t___i1 As Byte = CType(SpecialType.System_SByte, Byte)
            Const t___i2 As Byte = CType(SpecialType.System_Int16, Byte)
            Const t___i4 As Byte = CType(SpecialType.System_Int32, Byte)
            Const t___i8 As Byte = CType(SpecialType.System_Int64, Byte)
            Const t__ui1 As Byte = CType(SpecialType.System_Byte, Byte)
            Const t__ui2 As Byte = CType(SpecialType.System_UInt16, Byte)
            Const t__ui4 As Byte = CType(SpecialType.System_UInt32, Byte)
            Const t__ui8 As Byte = CType(SpecialType.System_UInt64, Byte)

            Const t__ref As Byte = CType(SpecialType.System_Object, Byte)
            Const t_bool As Byte = CType(SpecialType.System_Boolean, Byte)
            Const t_date As Byte = CType(SpecialType.System_DateTime, Byte)
            Const t_char As Byte = CType(SpecialType.System_Char, Byte)

            Const TYPE_NUM As Integer = 17
            Const NUM_OPERATORS As Integer = 10

            '// RHS->    bad     bool    i1      ui1     i2      ui2     i4      ui4     i8      ui8     dec     r4      r8      date    char    str     ref
            s_table = New Byte(NUM_OPERATORS - 1, TYPE_NUM - 1, TYPE_NUM - 1) _
            {
                {  ' Addition
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t___i2, t___i1, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i1, t___i1, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i2, t___i2, t__ui1, t___i2, t__ui2, t___i4, t__ui4, t___i8, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i2, t___i2, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i4, t___i4, t__ui2, t___i4, t__ui2, t___i4, t__ui4, t___i8, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i8, t___i8, t__ui4, t___i8, t__ui4, t___i8, t__ui4, t___i8, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__dec, t__dec, t__ui8, t__dec, t__ui8, t__dec, t__ui8, t__dec, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__str, t__bad, t__str, t__ref},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__str, t__str, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__str, t__str, t__str, t__ref},
                   {t__bad, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref}
               },
               { ' Subtraction, Multiplication, and Modulo. Special Note:  Date - Date is actually TimeSpan, but that cannot be encoded in this table.
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t___i2, t___i1, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i1, t___i1, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i2, t___i2, t__ui1, t___i2, t__ui2, t___i4, t__ui4, t___i8, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i2, t___i2, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i4, t___i4, t__ui2, t___i4, t__ui2, t___i4, t__ui4, t___i8, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i8, t___i8, t__ui4, t___i8, t__ui4, t___i8, t__ui4, t___i8, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__dec, t__dec, t__ui8, t__dec, t__ui8, t__dec, t__ui8, t__dec, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__bad, t__bad, t__ref, t__ref}
               },
               { ' Division
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__bad, t__bad, t__ref, t__ref}
               },
               { ' Power
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__bad, t__bad, t__ref, t__ref}
               },
               { 'Integer Division
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t___i2, t___i1, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i1, t___i1, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i2, t___i2, t__ui1, t___i2, t__ui2, t___i4, t__ui4, t___i8, t__ui8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i2, t___i2, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i4, t___i4, t__ui2, t___i4, t__ui2, t___i4, t__ui4, t___i8, t__ui8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t__ui4, t___i8, t__ui4, t___i8, t__ui4, t___i8, t__ui8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t__ui8, t___i8, t__ui8, t___i8, t__ui8, t___i8, t__ui8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__bad, t__bad, t__ref, t__ref}
               },
               { ' Shift. Note: The right operand serves little purpose in this table, however a table is utilized nonetheless to make the most use of already existing code which analyzes binary operators.
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t__ref},
                   {t__bad, t___i1, t___i1, t___i1, t___i1, t___i1, t___i1, t___i1, t___i1, t___i1, t___i1, t___i1, t___i1, t___i1, t___i1, t___i1, t__ref},
                   {t__bad, t__ui1, t__ui1, t__ui1, t__ui1, t__ui1, t__ui1, t__ui1, t__ui1, t__ui1, t__ui1, t__ui1, t__ui1, t__ui1, t__ui1, t__ui1, t__ref},
                   {t__bad, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t___i2, t__ref},
                   {t__bad, t__ui2, t__ui2, t__ui2, t__ui2, t__ui2, t__ui2, t__ui2, t__ui2, t__ui2, t__ui2, t__ui2, t__ui2, t__ui2, t__ui2, t__ui2, t__ref},
                   {t__bad, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t__ref},
                   {t__bad, t__ui4, t__ui4, t__ui4, t__ui4, t__ui4, t__ui4, t__ui4, t__ui4, t__ui4, t__ui4, t__ui4, t__ui4, t__ui4, t__ui4, t__ui4, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__ref},
                   {t__bad, t__ui8, t__ui8, t__ui8, t__ui8, t__ui8, t__ui8, t__ui8, t__ui8, t__ui8, t__ui8, t__ui8, t__ui8, t__ui8, t__ui8, t__ui8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__ref},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__ref},
                   {t__bad, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref}
               },
               { 'Logical Operators
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t_bool, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__bad, t__bad, t__ref, t__ref}
               },
               { ' Bitwise Operators
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t_bool, t___i1, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t___i1, t___i1, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i2, t___i2, t__ui1, t___i2, t__ui2, t___i4, t__ui4, t___i8, t__ui8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i2, t___i2, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i4, t___i4, t__ui2, t___i4, t__ui2, t___i4, t__ui4, t___i8, t__ui8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t__ui4, t___i8, t__ui4, t___i8, t__ui4, t___i8, t__ui8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t__ui8, t___i8, t__ui8, t___i8, t__ui8, t___i8, t__ui8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t_bool, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__bad, t__bad, t___i8, t__ref},
                   {t__bad, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__bad, t__bad, t__ref, t__ref}
               },
               { ' Relational Operators -- This one is a little unusual because it lists the type of the relational operation, even though the result type is always Boolean
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t_bool, t___i1, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t_bool, t__ref},
                   {t__bad, t___i1, t___i1, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i2, t___i2, t__ui1, t___i2, t__ui2, t___i4, t__ui4, t___i8, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i2, t___i2, t___i2, t___i2, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i4, t___i4, t__ui2, t___i4, t__ui2, t___i4, t__ui4, t___i8, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i4, t___i4, t___i4, t___i4, t___i4, t___i4, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i8, t___i8, t__ui4, t___i8, t__ui4, t___i8, t__ui4, t___i8, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t___i8, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__dec, t__dec, t__ui8, t__dec, t__ui8, t__dec, t__ui8, t__dec, t__ui8, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t__dec, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r4, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t__bad, t__bad, t___r8, t__ref},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t_date, t__bad, t_date, t__ref},
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t_char, t__str, t__ref},
                   {t__bad, t_bool, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t___r8, t_date, t__str, t__str, t__ref},
                   {t__bad, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref}
               },
               { ' Concatenation and Like
                   {t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad, t__bad},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__str, t__ref},
                   {t__bad, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref, t__ref}
               }
            }

        End Sub

        Friend Function LookupInOperatorTables(opcode As SyntaxKind, left As SpecialType, right As SpecialType) As SpecialType
            Dim whichTable As TableKind

            Select Case (opcode)

                Case SyntaxKind.AddExpression
                    whichTable = TableKind.Addition

                Case SyntaxKind.SubtractExpression,
                     SyntaxKind.MultiplyExpression,
                     SyntaxKind.ModuloExpression
                    whichTable = TableKind.SubtractionMultiplicationModulo

                Case SyntaxKind.DivideExpression
                    whichTable = TableKind.Division

                Case SyntaxKind.IntegerDivideExpression
                    whichTable = TableKind.IntegerDivision

                Case SyntaxKind.ExponentiateExpression
                    whichTable = TableKind.Power

                Case SyntaxKind.LeftShiftExpression,
                     SyntaxKind.RightShiftExpression
                    whichTable = TableKind.Shift

                Case SyntaxKind.OrElseExpression,
                     SyntaxKind.AndAlsoExpression
                    whichTable = TableKind.Logical

                Case SyntaxKind.ConcatenateExpression,
                     SyntaxKind.LikeExpression
                    whichTable = TableKind.ConcatenationLike

                Case SyntaxKind.EqualsExpression,
                     SyntaxKind.NotEqualsExpression,
                     SyntaxKind.LessThanOrEqualExpression,
                     SyntaxKind.GreaterThanOrEqualExpression,
                     SyntaxKind.LessThanExpression,
                     SyntaxKind.GreaterThanExpression
                    whichTable = TableKind.Relational

                Case SyntaxKind.OrExpression,
                     SyntaxKind.ExclusiveOrExpression,
                     SyntaxKind.AndExpression
                    whichTable = TableKind.Bitwise

                Case Else
                    Throw ExceptionUtilities.UnexpectedValue(opcode)
            End Select

            Return CType(s_table(whichTable, TypeCodeToIndex(left), TypeCodeToIndex(right)), SpecialType)
        End Function
    End Module

End Namespace
