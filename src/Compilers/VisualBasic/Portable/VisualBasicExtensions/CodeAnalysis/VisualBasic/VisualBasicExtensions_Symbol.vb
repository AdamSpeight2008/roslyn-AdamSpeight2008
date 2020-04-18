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

        ''' <summary> Determines if symbol is Shared. </summary>
        ''' <param name="symbol">The source symbol.</param>
        ''' <returns>A boolean value, True if symbol is Shared; otherwise False.</returns>
        <Extension>
        Public Function IsShared(symbol As ISymbol) As Boolean
            Return symbol.IsStatic
        End Function

        ''' <summary> Determines if symbol is Overrides. </summary>
        ''' <param name="symbol">The source symbol.</param>
        ''' <returns>A boolean value, True if symbol is Overrides; otherwise False.</returns>
        <Extension>
        Public Function IsOverrides(symbol As ISymbol) As Boolean
            Return symbol.IsOverride
        End Function

        ''' <summary> Determines if symbol is Overridable. </summary>
        ''' <param name="symbol">The source symbol.</param>
        ''' <returns>A boolean value, True if symbol is Overridable; otherwise False.</returns>
        <Extension>
        Public Function IsOverridable(symbol As ISymbol) As Boolean
            Return symbol.IsVirtual
        End Function

        ''' <summary> Determines if symbol is NotOverridable. </summary>
        ''' <param name="symbol">The source symbol.</param>
        ''' <returns>A boolean value, True if symbol is NotOverridable; otherwise False.</returns>
        <Extension>
        Public Function IsNotOverridable(symbol As ISymbol) As Boolean
            Return symbol.IsSealed
        End Function

        ''' <summary> Determines if symbol is MustOverride. </summary>
        ''' <param name="symbol">The source symbol.</param>
        ''' <returns>A boolean value, True if symbol is MustOverride; otherwise False.</returns>
        <Extension>
        Public Function IsMustOverride(symbol As ISymbol) As Boolean
            Return symbol.IsAbstract
        End Function

        ''' <summary> Determines if parameter symbol is Me. </summary>
        ''' <param name="parameterSymbol">The parameter symbol.</param>
        ''' <returns>A boolean value, True if parameter symbol is Me; otherwise False.</returns>
        <Extension>
        Public Function IsMe(parameterSymbol As IParameterSymbol) As Boolean
            Return parameterSymbol.IsThis
        End Function

        ''' <summary> Determines if method symbol is Overloads. </summary>
        ''' <param name="methodSymbol">The method symbol.</param>
        ''' <returns>A boolean value, True if method symbol is Overloads; otherwise False.</returns> 
        <Extension>
        Public Function IsOverloads(methodSymbol As IMethodSymbol) As Boolean
            Dim vbmethod = TryCast(methodSymbol, MethodSymbol)
            Return vbmethod IsNot Nothing AndAlso vbmethod.IsOverloads
        End Function

        ''' <summary> Determines if property symbol is Overloads. </summary>
        ''' <param name="propertySymbol">The property symbol.</param>
        ''' <returns>A boolean value, True if property symbol is Overloads; otherwise False.</returns> 
        <Extension>
        Public Function IsOverloads(propertySymbol As IPropertySymbol) As Boolean
            Dim vbprop = TryCast(propertySymbol, PropertySymbol)
            Return vbprop IsNot Nothing AndAlso vbprop.IsOverloads
        End Function

        ''' <summary> Determines if parameter symbol is Overloads. </summary>
        ''' <param name="propertySymbol">The property symbol.</param>
        ''' <returns>A boolean value, True if property symbol is Overloads; otherwise False.</returns> 
        <Extension>
        Public Function IsDefault(propertySymbol As IPropertySymbol) As Boolean
            Dim vbprop = TryCast(propertySymbol, PropertySymbol)
            Return vbprop IsNot Nothing AndAlso vbprop.IsDefault
        End Function

        ''' <summary> Determines if method symbol is HandlesEvent. </summary>
        ''' <param name="methodSymbol">The method symbol.</param>
        ''' <returns>A boolean value, True if method symbol is HandlesEvents; otherwise False.</returns> 
        <Extension>
        Public Function HandledEvents(methodSymbol As IMethodSymbol) As ImmutableArray(Of HandledEvent)
            Dim vbmethod = TryCast(methodSymbol, MethodSymbol)
            Return If(vbmethod IsNot Nothing, vbmethod.HandledEvents,
                                              ImmutableArray(Of HandledEvent).Empty)
        End Function

        ''' <summary> Determines if local symbol is For. </summary>
        ''' <param name="localSymbol">The local symbol.</param>
        ''' <returns>A boolean value, True if method symbol is For; otherwise False.</returns> 
        <Extension>
        Public Function IsFor(localSymbol As ILocalSymbol) As Boolean
            Dim vblocal = TryCast(localSymbol, LocalSymbol)
            Return vblocal IsNot Nothing AndAlso vblocal.IsFor
        End Function

        ''' <summary> Determines if local symbol is ForEach. </summary>
        ''' <param name="localSymbol">The local symbol.</param>
        ''' <returns>A boolean value, True if method symbol is ForEach; otherwise False.</returns>
        <Extension>
        Public Function IsForEach(localSymbol As ILocalSymbol) As Boolean
            Dim vblocal = TryCast(localSymbol, LocalSymbol)
            Return vblocal IsNot Nothing AndAlso vblocal.IsForEach
        End Function

        ''' <summary> Determines if local symbol is Catch. </summary>
        ''' <param name="localSymbol">The local symbol.</param>
        ''' <returns>A boolean value, True if method symbol is Catch; otherwise False.</returns>
        <Extension>
        Public Function IsCatch(localSymbol As ILocalSymbol) As Boolean
            Dim vblocal = TryCast(localSymbol, LocalSymbol)
            Return vblocal IsNot Nothing AndAlso vblocal.IsCatch
        End Function

        ''' <summary>Get the associated field symbol. </summary>
        ''' <param name="eventSymbol">The event symbol.</param>
        ''' <returns>Return an <see cref="IFieldSymbol"/> object, otherwise Nothing.</returns>
        <Extension>
        Public Function AssociatedField(eventSymbol As IEventSymbol) As IFieldSymbol
            Dim vbevent = TryCast(eventSymbol, EventSymbol)
            Return vbevent?.AssociatedField
        End Function

        ''' <summary> Determines if event symbol has an Associated Field. </summary>
        ''' <param name="eventSymbol">The event symbol.</param>
        ''' <returns>A boolean value, True if event symbol has an associated field; otherwise False.</returns>
        <Extension>
        Public Function HasAssociatedField(eventSymbol As IEventSymbol) As Boolean
            Dim vbevent = TryCast(eventSymbol, EventSymbol)
            Return vbevent IsNot Nothing AndAlso vbevent.HasAssociatedField
        End Function

        ''' <summary>
        ''' Get the field's attributes.
        ''' </summary>
        ''' <param name="eventSymbol">The event symbol.</param>
        ''' <returns>Returns an <see cref="ImmutableArray(Of AttributeData)"/> contain the field's attributes;
        ''' Otherwise <see cref="ImmutableArray(Of AttibuteData).Empty"/>.</returns>
        <Extension>
        Public Function GetFieldAttributes(eventSymbol As IEventSymbol) As ImmutableArray(Of AttributeData)
            Dim vbevent = TryCast(eventSymbol, EventSymbol)
            Return If(vbevent IsNot Nothing, StaticCast(Of AttributeData).From(vbevent.GetFieldAttributes()),
                                             ImmutableArray(Of AttributeData).Empty)
       End Function


        ''' <summary> Determines if event symbol is implicitly declared. </summary>
        ''' <param name="eventSymbol">The event symbol.</param>
        ''' <returns>A boolean value, True if event symbol is implicitly declared; otherwise False.</returns>
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
            Return If( symbol IsNot Nothing, StaticCast(Of INamedTypeSymbol).From(symbol.GetModuleMembers()),
                                             ImmutableArray.Create(Of INamedTypeSymbol)())
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
            Return If(symbol IsNot Nothing, StaticCast(Of INamedTypeSymbol).From(symbol.GetModuleMembers(name)),
                                            ImmutableArray.Create(Of INamedTypeSymbol)())
        End Function

    End Module

End Namespace
