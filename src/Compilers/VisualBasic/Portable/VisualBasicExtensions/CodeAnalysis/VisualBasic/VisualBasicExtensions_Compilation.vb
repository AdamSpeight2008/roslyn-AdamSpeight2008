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

#Region "Compilation"
        ''' <summary>
        ''' Gets the Semantic Model OptionStrict property.
        ''' </summary>
        ''' <param name="semanticModel">A source Semantic model object.</param>
        ''' <returns>The OptionStrict object for the semantic model instance OptionStrict property, otherwise Null if semantic model is Null. </returns>
        <Extension>
        Public Function OptionStrict(semanticModel As SemanticModel) As OptionStrict
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.OptionStrict
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the Semantic Model OptionInfer property.
        ''' </summary>
        ''' <param name="semanticModel">A source Semantic model object.</param>
        ''' <returns>A boolean values, for the semantic model instance OptionInfer property. otherwise Null if semantic model is Null. </returns>
        <Extension>
        Public Function OptionInfer(semanticModel As SemanticModel) As Boolean
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.OptionInfer
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the Semantic Model OptionExplicit property.
        ''' </summary>
        ''' <param name="semanticModel">A source Semantic model object.</param>
        ''' <returns>A boolean values, for the semantic model instance OptionExplicit property. otherwise Null if semantic model is Null. </returns>
        <Extension>
        Public Function OptionExplicit(semanticModel As SemanticModel) As Boolean
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.OptionExplicit
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the Semantic Model OptionCompareText property.
        ''' </summary>
        ''' <param name="semanticModel">A source Semantic model object.</param>
        ''' <returns>A boolean values, for the semantic model instance OptionCompareText property. otherwise Null if semantic model is Null. </returns>
        <Extension>
        Public Function OptionCompareText(semanticModel As SemanticModel) As Boolean
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.OptionCompareText
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the compilation RootNamespace property.
        ''' </summary>
        ''' <param name="compilation">A source Compilation object.</param>
        ''' <returns>A NamespaceSymbol instance, for the compilation instance RootNamespace property. otherwise Null if compilation instance is Null. </returns>
        <Extension>
        Public Function RootNamespace(compilation As Compilation) As INamespaceSymbol
            Dim vbcomp = TryCast(compilation, VisualBasicCompilation)
            If vbcomp IsNot Nothing Then
                Return vbcomp.RootNamespace
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the compilation AliasImports property.
        ''' </summary>
        ''' <param name="compilation">A source Compilation object.</param>
        ''' <returns>An ImmutableArray of AliasSymbol, from the compilation instance AliasImports property; otherwise an empty ImmutableArray if compilation instance is Null.</returns>
        <Extension>
        Public Function AliasImports(compilation As Compilation) As ImmutableArray(Of IAliasSymbol)
            Dim vbcomp = TryCast(compilation, VisualBasicCompilation)
            If vbcomp IsNot Nothing Then
                Return StaticCast(Of IAliasSymbol).From(vbcomp.AliasImports)
            Else
                Return ImmutableArray.Create(Of IAliasSymbol)()
            End If
        End Function

        ''' <summary>
        '''  Gets the compilation MemberImports property.
        ''' </summary>
        ''' <param name="compilation">A source Compilation object.</param>
        ''' <returns>An ImmutableArray of NamespaceOrTypeSymbol, from the compilation instance MemberImports property; otherwise an empty ImmutableArray if compilation instance is Null.</returns>
        <Extension>
        Public Function MemberImports(compilation As Compilation) As ImmutableArray(Of INamespaceOrTypeSymbol)
            Dim vbcomp = TryCast(compilation, VisualBasicCompilation)
            If vbcomp IsNot Nothing Then
                Return StaticCast(Of INamespaceOrTypeSymbol).From(vbcomp.MemberImports)
            Else
                Return ImmutableArray.Create(Of INamespaceOrTypeSymbol)()
            End If
        End Function

        ''' <summary>
        ''' Determines what kind of conversion there is between the specified types.
        ''' </summary>
        ''' <param name="compilation">A source Compilation object.</param>
        ''' <param name="source">A source Typesymbol</param>
        ''' <param name="destination">A destination Typesymbol</param>
        ''' <returns>A Conversion instance, representing the kind of conversion between the two type symbols; otherwise Null if compilation instance is Null.</returns>
        <Extension>
        Public Function ClassifyConversion(compilation As Compilation, source As ITypeSymbol, destination As ITypeSymbol) As Conversion
            Dim vbcomp = TryCast(compilation, VisualBasicCompilation)
            If vbcomp IsNot Nothing Then
                Return vbcomp.ClassifyConversion(DirectCast(source, TypeSymbol), DirectCast(destination, TypeSymbol))
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the special type symbol in current compilation.
        ''' </summary>
        ''' <param name="compilation">A source Compilation object.</param>
        ''' <param name="typeId">The SpecialType to get.</param>
        ''' <returns>A NamedTypeSymbol for the specified type in compilation; Null if compilation is Null.</returns>
        <Extension>
        Public Function GetSpecialType(compilation As Compilation, typeId As SpecialType) As INamedTypeSymbol
            Dim vbcomp = TryCast(compilation, VisualBasicCompilation)
            If vbcomp IsNot Nothing Then
                Return vbcomp.GetSpecialType(typeId)
            Else
                Return Nothing
            End If
        End Function
#End Region

    End Module

End Namespace
