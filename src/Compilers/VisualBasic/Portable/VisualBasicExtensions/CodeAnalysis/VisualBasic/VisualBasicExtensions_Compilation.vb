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

        ''' <summary>Try and cast this <see cref="Compilation"/> as a <see cref="VisualBasicCompilation"/> </summary>
        ''' <param name="compilation">The <seealso cref="Compilation"/> to try./></param>
        ''' <param name="vbcomp">The <seealso cref="VisualBasicCompilation"/> object instance, or nothing./></param>
        ''' <returns><see langword="True"/> if <see cref="Compilation" /> is a <see cref="VisualBasicCompilation"/>, other false.</returns>
        <Extension>
        Private Function TryGetVBSemanticModel(compilation As Compilation,
                                   <Out> ByRef vbcomp      As VisualBasicCompilation
                                              ) As Boolean
            vbcomp = TryCast(compilation, VisualBasicCompilation)
            Return vbcomp IsNot Nothing
        End Function


        ''' <summary> Gets the compilation RootNamespace property. </summary>
        ''' <param name="compilation">A source Compilation object.</param>
        ''' <returns>
        ''' A <seealso cref="NamespaceSymbol"/> instance, for the compilation instance <seealso cref="RootNamespace"/> property.
        ''' otherwise Null if compilation instance is Null.
        ''' </returns>
        <Extension>
        Public Function RootNamespace(compilation As Compilation) As INamespaceSymbol
            Dim vbcomp As VisualBasicCompilation = Nothing
            Return If(compilation.TryGetVBSemanticModel(vbcomp), vbcomp.RootNamespace, Nothing)
        End Function

        ''' <summary> Gets the compilation AliasImports property. </summary>
        ''' <param name="compilation">A source Compilation object.</param>
        ''' <returns>
        ''' An ImmutableArray of AliasSymbol, from the compilation instance AliasImports property;
        ''' otherwise an empty ImmutableArray if compilation instance is Null.
        ''' </returns>
        <Extension>
        Public Function AliasImports(compilation As Compilation) As ImmutableArray(Of IAliasSymbol)
            Dim vbcomp As VisualBasicCompilation = Nothing
            Return If(compilation.TryGetVBSemanticModel(vbcomp),StaticCast(Of IAliasSymbol).From(vbcomp.AliasImports), ImmutableArray.Create(Of IAliasSymbol)())
        End Function

        ''' <summary> Gets the compilation MemberImports property. </summary>
        ''' <param name="compilation"> A source Compilation object. </param>
        ''' <returns>
        ''' An ImmutableArray of NamespaceOrTypeSymbol, from the compilation instance MemberImports property;
        ''' otherwise an empty ImmutableArray if compilation instance is Null.
        ''' </returns>
        <Extension>
        Public Function MemberImports(compilation As Compilation) As ImmutableArray(Of INamespaceOrTypeSymbol)
            Dim vbcomp As VisualBasicCompilation = Nothing
            Return If(compilation.TryGetVBSemanticModel(vbcomp), StaticCast(Of INamespaceOrTypeSymbol).From(vbcomp.MemberImports),
                                                                 ImmutableArray.Create(Of INamespaceOrTypeSymbol)())
        End Function

        ''' <summary> Determines what kind of conversion there is between the specified types. </summary>
        ''' <param name="compilation"> A source Compilation object. </param>
        ''' <param name="source"     > A source Typesymbol. </param>
        ''' <param name="destination"> A destination Typesymbol. </param>
        ''' <returns>A Conversion instance, representing the kind of conversion between the two type symbols; otherwise Null if compilation instance is Null.</returns>
        <Extension>
        Public Function ClassifyConversion(compilation As Compilation, source As ITypeSymbol, destination As ITypeSymbol) As Conversion
            Dim vbcomp As VisualBasicCompilation = Nothing
            Return If(compilation.TryGetVBSemanticModel(vbcomp), vbcomp.ClassifyConversion(DirectCast(source, TypeSymbol), DirectCast(destination, TypeSymbol)), Nothing)
        End Function

        ''' <summary> Gets the special type symbol in current compilation. </summary>
        ''' <param name="compilation"> A source Compilation object. </param>
        ''' <param name="typeId"     > The SpecialType to get. </param>
        ''' <returns> A <seealso cref="NamedTypeSymbol"/> for the specified type in compilation; Null if compilation is Null. </returns>
        <Extension>
        Public Function GetSpecialType(compilation As Compilation, typeId As SpecialType) As INamedTypeSymbol
            Dim vbcomp As VisualBasicCompilation = Nothing
            Return If(compilation.TryGetVBSemanticModel(vbcomp), vbcomp.GetSpecialType(typeId), Nothing)
        End Function

    End Module

End Namespace
