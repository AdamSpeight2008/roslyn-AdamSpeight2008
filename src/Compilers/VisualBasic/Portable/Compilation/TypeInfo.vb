' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports Microsoft.CodeAnalysis.VisualBasic.Symbols
Imports Roslyn.Utilities

Namespace Microsoft.CodeAnalysis.VisualBasic
    Friend Structure VisualBasicTypeInfo
        Implements IEquatable(Of VisualBasicTypeInfo)

        Friend Shared None As New VisualBasicTypeInfo(Nothing, Nothing, New Conversion(Conversions.Identity))

        ''' <summary>
        ''' The type of the expression represented by the syntax node. For expressions that do not
        ''' have a type, null is returned. If the type could not be determined due to an error, than
        ''' an object derived from ErrorTypeSymbol is returned.
        ''' </summary>
        Public ReadOnly Property Type As TypeSymbol

        ''' <summary>
        ''' The type of the expression after it has undergone an implicit conversion. If the type
        ''' did not undergo an implicit conversion, returns the same as Type.
        ''' </summary>
        Public ReadOnly Property ConvertedType As TypeSymbol

        ''' <summary>
        ''' If the expression underwent an implicit conversion, return information about that
        ''' conversion. Otherwise, returns an identity conversion.
        ''' </summary>
        Public ReadOnly Property ImplicitConversion As Conversion

        Public Shared Widening Operator CType(info As VisualBasicTypeInfo) As TypeInfo
            Return New TypeInfo(info.Type, info.ConvertedType, nullability:=Nothing, convertedNullability:=Nothing)
        End Operator

        Friend Sub New(type As TypeSymbol, convertedType As TypeSymbol, implicitConversion As Conversion)
            Me.Type = GetPossibleGuessForErrorType(type)
            Me.ConvertedType = GetPossibleGuessForErrorType(convertedType)
            Me.ImplicitConversion = implicitConversion
        End Sub

        Public Overloads Function Equals(other As VisualBasicTypeInfo) As Boolean Implements IEquatable(Of VisualBasicTypeInfo).Equals
            Return _implicitConversion.Equals(other._implicitConversion) AndAlso
                TypeSymbol.Equals(Type, other.Type, TypeCompareKind.ConsiderEverything) AndAlso
                TypeSymbol.Equals(_convertedType, other._convertedType, TypeCompareKind.ConsiderEverything)
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            Return TypeOf obj Is VisualBasicTypeInfo AndAlso
                Equals(DirectCast(obj, VisualBasicTypeInfo))
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return Hash.Combine(_convertedType, Hash.Combine(Type, _implicitConversion.GetHashCode()))
        End Function

        ''' <summary>
        ''' Guess the non-error type that the given type was intended to represent, or return
        ''' the type itself. If a single, non-ambiguous type is a guess-type inside the type symbol,
        ''' return that; otherwise return the type itself (even if it is an error type).
        ''' </summary>
        Private Shared Function GetPossibleGuessForErrorType(type As TypeSymbol) As TypeSymbol
            Dim errorSymbol As ErrorTypeSymbol = TryCast(type, ErrorTypeSymbol)
            If errorSymbol Is Nothing Then
                Return type
            End If

            Dim nonErrorGuess = errorSymbol.NonErrorGuessType
            If nonErrorGuess Is Nothing Then
                Return type
            Else
                Return nonErrorGuess
            End If
        End Function

    End Structure
End Namespace
