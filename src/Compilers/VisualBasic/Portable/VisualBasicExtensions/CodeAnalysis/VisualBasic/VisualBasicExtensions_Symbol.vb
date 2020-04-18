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

Namespace Microsoft.CodeAnalysis.VisualBasic

    Public Partial Module VisualBasicExtensions

#Region "Symbols"
        ''' <summary>
        ''' Determines if symbol is Shared.
        ''' </summary>
        ''' <param name="symbol">The source symbol.</param>
        ''' <returns>A boolean value, True if symbol is Shared; otherwise False.</returns>
        <Extension>
        Public Function IsShared(symbol As ISymbol) As Boolean
            Return symbol.IsStatic
        End Function

        <Extension>
        Public Function IsOverrides(symbol As ISymbol) As Boolean
            Return symbol.IsOverride
        End Function

        <Extension>
        Public Function IsOverridable(symbol As ISymbol) As Boolean
            Return symbol.IsVirtual
        End Function

        <Extension>
        Public Function IsNotOverridable(symbol As ISymbol) As Boolean
            Return symbol.IsSealed
        End Function

        <Extension>
        Public Function IsMustOverride(symbol As ISymbol) As Boolean
            Return symbol.IsAbstract
        End Function

        <Extension>
        Public Function IsMe(parameterSymbol As IParameterSymbol) As Boolean
            Return parameterSymbol.IsThis
        End Function

        <Extension>
        Public Function IsOverloads(methodSymbol As IMethodSymbol) As Boolean
            Dim vbmethod = TryCast(methodSymbol, MethodSymbol)
            Return vbmethod IsNot Nothing AndAlso vbmethod.IsOverloads
        End Function

        <Extension>
        Public Function IsOverloads(propertySymbol As IPropertySymbol) As Boolean
            Dim vbprop = TryCast(propertySymbol, PropertySymbol)
            Return vbprop IsNot Nothing AndAlso vbprop.IsOverloads
        End Function

        <Extension>
        Public Function IsDefault(propertySymbol As IPropertySymbol) As Boolean
            Dim vbprop = TryCast(propertySymbol, PropertySymbol)
            Return vbprop IsNot Nothing AndAlso vbprop.IsDefault
        End Function

        <Extension>
        Public Function HandledEvents(methodSymbol As IMethodSymbol) As ImmutableArray(Of HandledEvent)
            Dim vbmethod = TryCast(methodSymbol, MethodSymbol)
            If vbmethod IsNot Nothing Then
                Return vbmethod.HandledEvents
            Else
                Return ImmutableArray(Of HandledEvent).Empty
            End If
        End Function

        <Extension>
        Public Function IsFor(localSymbol As ILocalSymbol) As Boolean
            Dim vblocal = TryCast(localSymbol, LocalSymbol)
            Return vblocal IsNot Nothing AndAlso vblocal.IsFor
        End Function

        <Extension>
        Public Function IsForEach(localSymbol As ILocalSymbol) As Boolean
            Dim vblocal = TryCast(localSymbol, LocalSymbol)
            Return vblocal IsNot Nothing AndAlso vblocal.IsForEach
        End Function

        <Extension>
        Public Function IsCatch(localSymbol As ILocalSymbol) As Boolean
            Dim vblocal = TryCast(localSymbol, LocalSymbol)
            Return vblocal IsNot Nothing AndAlso vblocal.IsCatch
        End Function

        <Extension>
        Public Function AssociatedField(eventSymbol As IEventSymbol) As IFieldSymbol
            Dim vbevent = TryCast(eventSymbol, EventSymbol)
            Return If(vbevent IsNot Nothing, vbevent.AssociatedField, Nothing)
        End Function

        <Extension>
        Public Function HasAssociatedField(eventSymbol As IEventSymbol) As Boolean
            Dim vbevent = TryCast(eventSymbol, EventSymbol)
            Return vbevent IsNot Nothing AndAlso vbevent.HasAssociatedField
        End Function

        <Extension>
        Public Function GetFieldAttributes(eventSymbol As IEventSymbol) As ImmutableArray(Of AttributeData)
            Dim vbevent = TryCast(eventSymbol, EventSymbol)
            If vbevent IsNot Nothing Then
                Return StaticCast(Of AttributeData).From(vbevent.GetFieldAttributes())
            Else
                Return ImmutableArray(Of AttributeData).Empty
            End If
        End Function

        <Extension>
        Public Function IsImplicitlyDeclared(eventSymbol As IEventSymbol) As Boolean
            Dim vbevent = TryCast(eventSymbol, EventSymbol)
            Return vbevent IsNot Nothing AndAlso vbevent.IsImplicitlyDeclared
        End Function

        ''' <summary>
        ''' Gets all module members in a namespace.
        ''' </summary>
        ''' <param name="[namespace]">The source namespace symbol.</param>
        ''' <returns>An ImmutableArray of NamedTypeSymbol for all module members in namespace.</returns>
        <Extension>
        Public Function GetModuleMembers([namespace] As INamespaceSymbol) As ImmutableArray(Of INamedTypeSymbol)
            Dim symbol = TryCast([namespace], NamespaceSymbol)
            If symbol IsNot Nothing Then
                Return StaticCast(Of INamedTypeSymbol).From(symbol.GetModuleMembers())
            Else
                Return ImmutableArray.Create(Of INamedTypeSymbol)()
            End If
        End Function

        ''' <summary>
        ''' Gets all module members in a specified namespace.
        ''' </summary>
        ''' <param name="[namespace]">The source namespace symbol.</param>
        ''' <param name="name">The name of the namespace.</param>
        ''' <returns>An ImmutableArray of NamedTypeSymbol for all module members in namespace.</returns>
        <Extension>
        Public Function GetModuleMembers([namespace] As INamespaceSymbol, name As String) As ImmutableArray(Of INamedTypeSymbol)
            Dim symbol = TryCast([namespace], NamespaceSymbol)
            If symbol IsNot Nothing Then
                Return StaticCast(Of INamedTypeSymbol).From(symbol.GetModuleMembers(name))
            Else
                Return ImmutableArray.Create(Of INamedTypeSymbol)()
            End If
        End Function
#End Region

    End Module

End Namespace
