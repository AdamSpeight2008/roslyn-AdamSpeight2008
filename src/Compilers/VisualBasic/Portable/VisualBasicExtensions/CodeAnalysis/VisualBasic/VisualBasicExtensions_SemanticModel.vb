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

        ''' <summary>
        ''' Determines what kind of conversion there is between the expression syntax and a specified type.
        ''' </summary>
        ''' <param name="semanticModel">A source semantic model.</param>
        ''' <param name="expression">A source expression syntax.</param>
        ''' <param name="destination">A destination TypeSymbol.</param>
        ''' <returns>A Conversion instance, representing the kind of conversion between the expression and type symbol; otherwise Null if semantic model instance is Null.</returns>
        <Extension>
        Public Function ClassifyConversion(semanticModel As SemanticModel, expression As ExpressionSyntax, destination As ITypeSymbol) As Conversion
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.ClassifyConversion(expression, DirectCast(destination, TypeSymbol))
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Determines what kind of conversion there is between the expression syntax and a specified type.
        ''' </summary>
        ''' <param name="semanticModel">A source semantic model.</param>
        ''' <param name="position">A position within the expression syntax.</param>
        ''' <param name="expression">A source expression syntax.</param>
        ''' <param name="destination">A destination TypeSymbol.</param>
        ''' <returns>A Conversion instance, representing the kind of conversion between the expression and type symbol; otherwise Null if semantic model instance is Null.</returns>
        <Extension>
        Public Function ClassifyConversion(semanticModel As SemanticModel, position As Integer, expression As ExpressionSyntax, destination As ITypeSymbol) As Conversion
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.ClassifyConversion(position, expression, DirectCast(destination, TypeSymbol))
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding symbol for a specified identifier.
        ''' </summary>
        ''' <param name="semanticModel">A source semantic model.</param>
        ''' <param name="identifierSyntax">A IdentifierSyntax object.</param>
        ''' <param name="cancellationToken">A cancellation token.</param>
        ''' <returns>A symbol, for the specified identifier; otherwise Null if semantic model is Null. </returns>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, identifierSyntax As ModifiedIdentifierSyntax, Optional cancellationToken As CancellationToken = Nothing) As ISymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(identifierSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding symbol for a specified tuple element.
        ''' </summary>
        ''' <param name="semanticModel">A source semantic model.</param>
        ''' <param name="elementSyntax">A TupleElementSyntax object.</param>
        ''' <param name="cancellationToken">A cancellation token.</param>
        ''' <returns>A symbol, for the specified element; otherwise Nothing. </returns>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, elementSyntax As TupleElementSyntax, Optional cancellationToken As CancellationToken = Nothing) As ISymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(elementSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding PropertySymbol for a specified FieldInitializerSyntax.
        ''' </summary>
        ''' <param name="semanticModel">A source semantic model.</param>
        ''' <param name="fieldInitializerSyntax">A FieldInitializerSyntax object.</param>
        ''' <param name="cancellationToken">A cancellation token.</param>
        ''' <returns>A PropertySymbol. Null if semantic model is null.</returns>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, fieldInitializerSyntax As FieldInitializerSyntax, Optional cancellationToken As CancellationToken = Nothing) As IPropertySymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(fieldInitializerSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding  NamedTypeSymbol for a specified  AnonymousObjectCreationExpressionSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, anonymousObjectCreationExpressionSyntax As AnonymousObjectCreationExpressionSyntax, Optional cancellationToken As CancellationToken = Nothing) As INamedTypeSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(anonymousObjectCreationExpressionSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding RangeVariableSymbol for a specified ExpressionRangeVariableSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, rangeVariableSyntax As ExpressionRangeVariableSyntax, Optional cancellationToken As CancellationToken = Nothing) As IRangeVariableSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(rangeVariableSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding RangeVariableSymbol for a specified CollectionRangeVariableSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, rangeVariableSyntax As CollectionRangeVariableSyntax, Optional cancellationToken As CancellationToken = Nothing) As IRangeVariableSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(rangeVariableSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding RangeVariableSymbol for a specified AggregationRangeVariableSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, rangeVariableSyntax As AggregationRangeVariableSyntax, Optional cancellationToken As CancellationToken = Nothing) As IRangeVariableSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(rangeVariableSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding LabelSymbol for a specified LabelStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As LabelStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As ILabelSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding FieldSymbol for a specified EnumMemberDeclarationSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As EnumMemberDeclarationSyntax, Optional cancellationToken As CancellationToken = Nothing) As IFieldSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding NamedTypeSymbol for a specified TypeStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As TypeStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As INamedTypeSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding NamedTypeSymbol for a specified TypeBlockSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As TypeBlockSyntax, Optional cancellationToken As CancellationToken = Nothing) As INamedTypeSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding NamedTypeSymbol for a specified EnumStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As EnumStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As INamedTypeSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding NamedTypeSymbol for a specified EnumBlockSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As EnumBlockSyntax, Optional cancellationToken As CancellationToken = Nothing) As INamedTypeSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding NamespaceSymbol for a specified NamespaceStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As NamespaceStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As INamespaceSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding NamespaceSymbol for a specified NamespaceBlockSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As NamespaceBlockSyntax, Optional cancellationToken As CancellationToken = Nothing) As INamespaceSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding ParameterSymbol for a specified ParameterSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, parameter As ParameterSyntax, Optional cancellationToken As CancellationToken = Nothing) As IParameterSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(parameter, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding TypeParameterSymbol Symbol for a specified TypeParameterSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, typeParameter As TypeParameterSyntax, Optional cancellationToken As CancellationToken = Nothing) As ITypeParameterSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(typeParameter, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding NamedTypeSymbol for a specified DelegateStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As DelegateStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As INamedTypeSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding MethodSymbol for a specified SubNewStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As SubNewStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As IMethodSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding MethodSymbol for a specified MethodStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As MethodStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As IMethodSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding symbol for a specified  DeclareStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As DeclareStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As IMethodSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding MethodSymbol for a specified OperatorStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As OperatorStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As IMethodSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding MethodSymbol for a specified MethodBlockBaseSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As MethodBlockBaseSyntax, Optional cancellationToken As CancellationToken = Nothing) As IMethodSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding PropertySymbol for a specified PropertyStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As PropertyStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As IPropertySymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding EventSymbol for a specified EventStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As EventStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As IEventSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding PropertySymbol for a specified PropertyBlockSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As PropertyBlockSyntax, Optional cancellationToken As CancellationToken = Nothing) As IPropertySymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding EventSymbol for a specified EventBlockSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As EventBlockSyntax, Optional cancellationToken As CancellationToken = Nothing) As IEventSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding LocalSymbol for a specified CatchStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As CatchStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As ILocalSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding MethodSymbol for a specified AccessorStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As AccessorStatementSyntax, Optional cancellationToken As CancellationToken = Nothing) As IMethodSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding AliasSymbol for a specified AliasImportsClauseSyntax.
        ''' </summary>
        <Extension>
        Public Function GetDeclaredSymbol(semanticModel As SemanticModel, declarationSyntax As SimpleImportsClauseSyntax, Optional cancellationToken As CancellationToken = Nothing) As IAliasSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetDeclaredSymbol(declarationSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding ForEachStatementInfo containing semantic info for a specified ForEachStatementSyntax.
        ''' </summary>
        <Extension>
        Public Function GetForEachStatementInfo(semanticModel As SemanticModel, node As ForEachStatementSyntax) As ForEachStatementInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetForEachStatementInfo(node)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding ForEachStatementInfo containing semantic info for a specified ForBlockSyntax.
        ''' </summary>
        <Extension>
        Public Function GetForEachStatementInfo(semanticModel As SemanticModel, node As ForEachBlockSyntax) As ForEachStatementInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetForEachStatementInfo(node)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding AwaitExpressionInfo containing semantic info for a specified AwaitExpressionSyntax.
        ''' </summary>
        <Extension>
        Public Function GetAwaitExpressionInfo(semanticModel As SemanticModel, awaitExpression As AwaitExpressionSyntax, Optional cancellationToken As CancellationToken = Nothing) As AwaitExpressionInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetAwaitExpressionInfo(awaitExpression, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' If the given node is within a preprocessing directive, gets the preprocessing symbol info for it.
        ''' </summary>
        <Extension>
        Public Function GetPreprocessingSymbolInfo(semanticModel As SemanticModel, node As IdentifierNameSyntax) As PreprocessingSymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetPreprocessingSymbolInfo(node)
            Else
                Return PreprocessingSymbolInfo.None
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding SymbolInfo containing semantic info for a specified ExpressionSyntax.
        ''' </summary>
        <Extension>
        Public Function GetSymbolInfo(semanticModel As SemanticModel, expression As ExpressionSyntax, Optional cancellationToken As CancellationToken = Nothing) As SymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSymbolInfo(expression, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Returns what 'Add' method symbol(s), if any, corresponds to the given expression syntax
        ''' within <see cref="ObjectCollectionInitializerSyntax.Initializer"/>.
        ''' </summary>
        <Extension>
        Public Function GetCollectionInitializerSymbolInfo(semanticModel As SemanticModel, expression As ExpressionSyntax, Optional cancellationToken As CancellationToken = Nothing) As SymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetCollectionInitializerSymbolInfo(expression, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding SymbolInfo containing semantic info for a specified CrefReferenceSyntax.
        ''' </summary>
        <Extension>
        Public Function GetSymbolInfo(semanticModel As SemanticModel, crefReference As CrefReferenceSyntax, Optional cancellationToken As CancellationToken = Nothing) As SymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSymbolInfo(crefReference, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding SymbolInfo containing semantic info for a specified AttributeSyntax.
        ''' </summary>
        <Extension>
        Public Function GetSymbolInfo(semanticModel As SemanticModel, attribute As AttributeSyntax, Optional cancellationToken As CancellationToken = Nothing) As SymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSymbolInfo(attribute, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding SymbolInfo containing semantic info for a specified AttributeSyntax.
        ''' </summary>
        <Extension>
        Public Function GetSpeculativeSymbolInfo(semanticModel As SemanticModel, position As Integer, expression As ExpressionSyntax, bindingOption As SpeculativeBindingOption) As SymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSpeculativeSymbolInfo(position, expression, bindingOption)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding SymbolInfo containing semantic info for specified  AttributeSyntax at a given position, used in Semantic Info for items not appearing in source code.
        ''' </summary>
        <Extension>
        Public Function GetSpeculativeSymbolInfo(semanticModel As SemanticModel, position As Integer, attribute As AttributeSyntax) As SymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSpeculativeSymbolInfo(position, attribute)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding TypeInfo containing semantic info for a specified ExpressionSyntax.
        ''' </summary>
        <Extension>
        Public Function GetConversion(semanticModel As SemanticModel, expression As SyntaxNode, Optional cancellationToken As CancellationToken = Nothing) As Conversion
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetConversion(expression, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the underlying <see cref="Conversion"/> information from an <see cref="IConversionOperation"/> that was created from Visual Basic code.
        ''' </summary>
        ''' <param name="conversionExpression">The conversion expression to get original info from.</param>
        ''' <returns>The underlying <see cref="Conversion"/>.</returns>
        ''' <exception cref="InvalidCastException">If the <see cref="IConversionOperation"/> was not created from Visual Basic code.</exception>
        <Extension>
        Public Function GetConversion(conversionExpression As IConversionOperation) As Conversion
            If conversionExpression.Language = LanguageNames.VisualBasic Then
                Return DirectCast(DirectCast(conversionExpression, BaseConversionOperation).ConversionConvertible, Conversion)
            Else
                Throw New ArgumentException(String.Format(VBResources.IConversionExpressionIsNotVisualBasicConversion,
                                                          NameOf(IConversionOperation)),
                                            NameOf(conversionExpression))
            End If
        End Function

        ''' <summary>
        ''' Gets the underlying <see cref="Conversion"/> information for InConversion of <see cref="IArgumentOperation"/> that was created from Visual Basic code.
        ''' </summary>
        ''' <param name="argument">The argument to get original info from.</param>
        ''' <returns>The underlying <see cref="Conversion"/> of the InConversion.</returns>
        ''' <exception cref="ArgumentException">If the <see cref="IArgumentOperation"/> was not created from Visual Basic code.</exception>
        <Extension>
        Public Function GetInConversion(argument As IArgumentOperation) As Conversion
            If argument.Language = LanguageNames.VisualBasic Then
                Dim inConversionConvertible As IConvertibleConversion = DirectCast(argument, BaseArgumentOperation).InConversionConvertibleOpt
                Return If(inConversionConvertible IsNot Nothing, DirectCast(inConversionConvertible, Conversion), New Conversion(Conversions.Identity))
            Else
                Throw New ArgumentException(String.Format(VBResources.IArgumentIsNotVisualBasicArgument,
                                                          NameOf(IArgumentOperation)),
                                            NameOf(argument))
            End If
        End Function

        ''' <summary>
        ''' Gets the underlying <see cref="Conversion"/> information for OutConversion of <see cref="IArgumentOperation"/> that was created from Visual Basic code.
        ''' </summary>
        ''' <param name="argument">The argument to get original info from.</param>
        ''' <returns>The underlying <see cref="Conversion"/> of the OutConversion.</returns>
        ''' <exception cref="ArgumentException">If the <see cref="IArgumentOperation"/> was not created from Visual Basic code.</exception>
        <Extension>
        Public Function GetOutConversion(argument As IArgumentOperation) As Conversion
            If argument.Language = LanguageNames.VisualBasic Then
                Dim outConversionConvertible As IConvertibleConversion = DirectCast(argument, BaseArgumentOperation).OutConversionConvertibleOpt
                Return If(outConversionConvertible IsNot Nothing, DirectCast(outConversionConvertible, Conversion), New Conversion(Conversions.Identity))
            Else
                Throw New ArgumentException(String.Format(VBResources.IArgumentIsNotVisualBasicArgument,
                                                          NameOf(IArgumentOperation)),
                                            NameOf(argument))
            End If
        End Function

        ''' <summary>
        ''' Gets the underlying <see cref="Conversion"/> information from this <see cref="ICompoundAssignmentOperation"/>. This
        ''' conversion is applied before the operator is applied to the result of this conversion and <see cref="IAssignmentOperation.Value"/>.
        ''' </summary>
        ''' <remarks>
        ''' This compound assignment must have been created from Visual Basic code.
        ''' </remarks>
        <Extension>
        Public Function GetInConversion(compoundAssignment As ICompoundAssignmentOperation) As Conversion
            If compoundAssignment Is Nothing Then
                Throw New ArgumentNullException(NameOf(compoundAssignment))
            End If

            If compoundAssignment.Language = LanguageNames.VisualBasic Then
                Return DirectCast(DirectCast(compoundAssignment, BaseCompoundAssignmentOperation).InConversionConvertible, Conversion)
            Else
                Throw New ArgumentException(String.Format(VBResources.ICompoundAssignmentOperationIsNotVisualBasicCompoundAssignment,
                                                          NameOf(compoundAssignment)),
                                            NameOf(compoundAssignment))
            End If
        End Function

        ''' <summary>
        ''' Gets the underlying <see cref="Conversion"/> information from this <see cref="ICompoundAssignmentOperation"/>. This
        ''' conversion is applied after the operator is applied, before the result is assigned to <see cref="IAssignmentOperation.Target"/>.
        ''' </summary>
        ''' <remarks>
        ''' This compound assignment must have been created from Visual Basic code.
        ''' </remarks>
        <Extension>
        Public Function GetOutConversion(compoundAssignment As ICompoundAssignmentOperation) As Conversion
            If compoundAssignment Is Nothing Then
                Throw New ArgumentNullException(NameOf(compoundAssignment))
            End If

            If compoundAssignment.Language = LanguageNames.VisualBasic Then
                Return DirectCast(DirectCast(compoundAssignment, BaseCompoundAssignmentOperation).OutConversionConvertible, Conversion)
            Else
                Throw New ArgumentException(String.Format(VBResources.ICompoundAssignmentOperationIsNotVisualBasicCompoundAssignment,
                                                          NameOf(compoundAssignment)),
                                            NameOf(compoundAssignment))
            End If
        End Function

        <Extension>
        Public Function GetSpeculativeConversion(semanticModel As SemanticModel, position As Integer, expression As ExpressionSyntax, bindingOption As SpeculativeBindingOption) As Conversion
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSpeculativeConversion(position, expression, bindingOption)
            Else
                Return Nothing
            End If
        End Function

        <Extension>
        Public Function GetTypeInfo(semanticModel As SemanticModel, expression As ExpressionSyntax, Optional cancellationToken As CancellationToken = Nothing) As TypeInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetTypeInfo(expression, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding TypeInfo  containing semantic info for a speculating an ExpressionSyntax at a given position, used in Semantic Info for items not appearing in source code.
        ''' </summary>
        <Extension>
        Public Function GetSpeculativeTypeInfo(semanticModel As SemanticModel, position As Integer, expression As ExpressionSyntax, bindingOption As SpeculativeBindingOption) As TypeInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSpeculativeTypeInfo(position, expression, bindingOption)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding TypeInfo containing semantic info for a specified AttributeSyntax.
        ''' </summary>
        <Extension>
        Public Function GetTypeInfo(semanticModel As SemanticModel, attribute As AttributeSyntax, Optional cancellationToken As CancellationToken = Nothing) As TypeInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetTypeInfo(attribute, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding ImmutableArray of Symbols for a specified ExpressionSyntax.
        ''' </summary>
        <Extension>
        Public Function GetMemberGroup(semanticModel As SemanticModel, expression As ExpressionSyntax, Optional cancellationToken As CancellationToken = Nothing) As ImmutableArray(Of ISymbol)
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetMemberGroup(expression, cancellationToken)
            Else
                Return ImmutableArray.Create(Of ISymbol)
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding ImmutableArray of Symbols for a speculating an ExpressionSyntax at a given position, used in Semantic Info for items not appearing in source code.
        ''' </summary>
        <Extension>
        Public Function GetSpeculativeMemberGroup(semanticModel As SemanticModel, position As Integer, expression As ExpressionSyntax) As ImmutableArray(Of ISymbol)
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSpeculativeMemberGroup(position, expression)
            Else
                Return ImmutableArray.Create(Of ISymbol)
            End If
        End Function

        ''' <summary>
        ''' Gets the corresponding ImmutableArray of Symbols for a specified AttributeSyntax.
        ''' </summary>
        <Extension>
        Public Function GetMemberGroup(semanticModel As SemanticModel, attribute As AttributeSyntax, Optional cancellationToken As CancellationToken = Nothing) As ImmutableArray(Of ISymbol)
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetMemberGroup(attribute, cancellationToken)
            Else
                Return ImmutableArray.Create(Of ISymbol)
            End If
        End Function

        ''' <summary>
        ''' If "nameSyntax" resolves to an alias name, return the AliasSymbol corresponding
        ''' to A. Otherwise return null.
        ''' </summary>
        <Extension>
        Public Function GetAliasInfo(semanticModel As SemanticModel, nameSyntax As IdentifierNameSyntax, Optional cancellationToken As CancellationToken = Nothing) As IAliasSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetAliasInfo(nameSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Binds the name in the context of the specified location and sees if it resolves to an
        ''' alias name. If it does, return the AliasSymbol corresponding to it. Otherwise, return null.
        ''' </summary>
        <Extension>
        Public Function GetSpeculativeAliasInfo(semanticModel As SemanticModel, position As Integer, nameSyntax As IdentifierNameSyntax, bindingOption As SpeculativeBindingOption) As IAliasSymbol
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSpeculativeAliasInfo(position, nameSyntax, bindingOption)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Returns information about methods associated with CollectionRangeVariableSyntax.
        ''' </summary>
        <Extension>
        Public Function GetCollectionRangeVariableSymbolInfo(
            semanticModel As SemanticModel,
            variableSyntax As CollectionRangeVariableSyntax,
            Optional cancellationToken As CancellationToken = Nothing
        ) As CollectionRangeVariableSymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetCollectionRangeVariableSymbolInfo(variableSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Returns information about methods associated with AggregateClauseSyntax.
        ''' </summary>
        <Extension>
        Public Function GetAggregateClauseSymbolInfo(
            semanticModel As SemanticModel,
            aggregateSyntax As AggregateClauseSyntax,
            Optional cancellationToken As CancellationToken = Nothing
        ) As AggregateClauseSymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetAggregateClauseSymbolInfo(aggregateSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Returns symbol information for a query clause.
        ''' </summary>
        ''' <remarks>
        ''' <list type="table">
        ''' <listheader>
        '''     <term>Syntax node type</term>
        '''     <description>Symbol information returned</description>
        ''' </listheader>
        ''' <item>
        '''     <term><see cref="DistinctClauseSyntax"/></term>
        '''     <description>Returns Distinct method associated with <see cref="DistinctClauseSyntax"/>.</description>
        ''' </item>
        ''' <item>
        '''     <term><see cref="WhereClauseSyntax"/></term>
        '''     <description>Returns Where method associated with <see cref="WhereClauseSyntax"/>.</description>
        ''' </item>
        ''' <item>
        '''     <term><see cref="PartitionWhileClauseSyntax"/></term>
        '''     <description>Returns TakeWhile/SkipWhile method associated with <see cref="PartitionWhileClauseSyntax"/>.</description>
        ''' </item>
        ''' <item>
        '''     <term><see cref="PartitionClauseSyntax"/></term>
        '''     <description>Returns Take/Skip method associated with <see cref="PartitionClauseSyntax"/>.</description>
        ''' </item>
        ''' <item>
        '''     <term><see cref="GroupByClauseSyntax"/></term>
        '''     <description>Returns GroupBy method associated with <see cref="GroupByClauseSyntax"/>.</description>
        ''' </item>
        ''' <item>
        '''     <term><see cref="JoinClauseSyntax"/></term>
        '''     <description>Returns Join/GroupJoin method associated with <see cref="JoinClauseSyntax"/>.</description>
        ''' </item>
        ''' <item>
        '''     <term><see cref="SelectClauseSyntax"/></term>
        '''     <description>Returns Select method associated with <see cref="SelectClauseSyntax"/>, or <see cref="SymbolInfo.None"/> if none is.</description>
        ''' </item>
        ''' <item>
        '''     <term><see cref="FromClauseSyntax"/></term>
        '''     <description>
        '''         Returns Select method associated with <see cref="FromClauseSyntax"/>, which has only one
        '''         <see cref="CollectionRangeVariableSyntax"/> and is the only query clause within
        '''         <see cref="QueryExpressionSyntax"/>. <see cref="SymbolInfo.None"/> otherwise.
        '''         The method call is injected by the compiler to make sure that query is translated to at
        '''         least one method call.
        '''     </description>
        ''' </item>
        ''' <item>
        '''     <term><see cref="LetClauseSyntax"/></term>
        '''     <description><see cref="SymbolInfo.None"/></description>
        ''' </item>
        ''' <item>
        '''     <term><see cref="OrderByClauseSyntax"/></term>
        '''     <description><see cref="SymbolInfo.None"/></description>
        ''' </item>
        ''' <item>
        '''     <term><see cref="AggregateClauseSyntax"/></term>
        '''     <description>
        '''         <see cref="SymbolInfo.None"/>.
        '''         Use <see cref="GetAggregateClauseSymbolInfo(SemanticModel, AggregateClauseSyntax, CancellationToken)"/> instead.
        '''     </description>
        ''' </item>
        ''' </list>
        ''' </remarks>
        <Extension>
        Public Function GetSymbolInfo(
            semanticModel As SemanticModel,
            clauseSyntax As QueryClauseSyntax,
            Optional cancellationToken As CancellationToken = Nothing
        ) As SymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSymbolInfo(clauseSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Returns Select method associated with <see cref="ExpressionRangeVariableSyntax"/> within a <see cref="LetClauseSyntax"/>,
        ''' or <see cref="SymbolInfo.None"/> otherwise if none is.
        ''' </summary>
        <Extension>
        Public Function GetSymbolInfo(
            semanticModel As SemanticModel,
            variableSyntax As ExpressionRangeVariableSyntax,
            Optional cancellationToken As CancellationToken = Nothing
        ) As SymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSymbolInfo(variableSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Returns aggregate function associated with <see cref="FunctionAggregationSyntax"/>.
        ''' </summary>
        <Extension>
        Public Function GetSymbolInfo(
            semanticModel As SemanticModel,
            functionSyntax As FunctionAggregationSyntax,
            Optional cancellationToken As CancellationToken = Nothing
        ) As SymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSymbolInfo(functionSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Returns OrderBy/OrderByDescending/ThenBy/ThenByDescending method associated with <see cref="OrderingSyntax"/>.
        ''' </summary>
        <Extension>
        Public Function GetSymbolInfo(
            semanticModel As SemanticModel,
            orderingSyntax As OrderingSyntax,
            Optional cancellationToken As CancellationToken = Nothing
        ) As SymbolInfo
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.GetSymbolInfo(orderingSyntax, cancellationToken)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Analyze control-flow within a part of a method body.
        ''' </summary>
        <Extension>
        Public Function AnalyzeControlFlow(semanticModel As SemanticModel, firstStatement As StatementSyntax, lastStatement As StatementSyntax) As ControlFlowAnalysis
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.AnalyzeControlFlow(firstStatement, lastStatement)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Analyze control-flow within a part of a method body.
        ''' </summary>
        <Extension>
        Public Function AnalyzeControlFlow(semanticModel As SemanticModel, statement As StatementSyntax) As ControlFlowAnalysis
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.AnalyzeControlFlow(statement)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Analyze data-flow within an expression.
        ''' </summary>
        <Extension>
        Public Function AnalyzeDataFlow(semanticModel As SemanticModel, expression As ExpressionSyntax) As DataFlowAnalysis
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.AnalyzeDataFlow(expression)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Analyze data-flow within a set of contiguous statements.
        ''' </summary>
        <Extension>
        Public Function AnalyzeDataFlow(semanticModel As SemanticModel, firstStatement As StatementSyntax, lastStatement As StatementSyntax) As DataFlowAnalysis
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.AnalyzeDataFlow(firstStatement, lastStatement)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Analyze data-flow within a statement.
        ''' </summary>
        <Extension>
        Public Function AnalyzeDataFlow(semanticModel As SemanticModel, statement As StatementSyntax) As DataFlowAnalysis
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.AnalyzeDataFlow(statement)
            Else
                Return Nothing
            End If
        End Function

        ''' <summary>
        ''' Gets the SemanticModel for a MethodBlockBaseSyntax at a given position, used in Semantic Info for items not appearing in source code.
        ''' </summary>
        <Extension>
        Public Function TryGetSpeculativeSemanticModelForMethodBody(semanticModel As SemanticModel, position As Integer, method As MethodBlockBaseSyntax, <Out> ByRef speculativeModel As SemanticModel) As Boolean
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.TryGetSpeculativeSemanticModelForMethodBody(position, method, speculativeModel)
            Else
                speculativeModel = Nothing
                Return False
            End If
        End Function

        ''' <summary>
        ''' Gets the SemanticModel for a RangeArgumentSyntax at a given position, used in Semantic Info for items not appearing in source code.
        ''' </summary>
        <Extension>
        Public Function TryGetSpeculativeSemanticModel(semanticModel As SemanticModel, position As Integer, rangeArgument As RangeArgumentSyntax, <Out> ByRef speculativeModel As SemanticModel) As Boolean
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.TryGetSpeculativeSemanticModel(position, rangeArgument, speculativeModel)
            Else
                speculativeModel = Nothing
                Return False
            End If
        End Function

        ''' <summary>
        ''' Gets the SemanticModel for a ExecutableStatementSyntax at a given position, used in Semantic Info for items not appearing in source code.
        ''' </summary>
        <Extension>
        Public Function TryGetSpeculativeSemanticModel(semanticModel As SemanticModel, position As Integer, statement As ExecutableStatementSyntax, <Out> ByRef speculativeModel As SemanticModel) As Boolean
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.TryGetSpeculativeSemanticModel(position, statement, speculativeModel)
            Else
                speculativeModel = Nothing
                Return False
            End If
        End Function

        ''' <summary>
        ''' Gets the SemanticModel for a EqualsValueSyntax at a given position, used in Semantic Info for items not appearing in source code.
        ''' </summary>
        <Extension>
        Public Function TryGetSpeculativeSemanticModel(semanticModel As SemanticModel, position As Integer, initializer As EqualsValueSyntax, <Out> ByRef speculativeModel As SemanticModel) As Boolean
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.TryGetSpeculativeSemanticModel(position, initializer, speculativeModel)
            Else
                speculativeModel = Nothing
                Return False
            End If
        End Function

        ''' <summary>
        ''' Gets the SemanticModel for a AttributeSyntax at a given position, used in Semantic Info for items not appearing in source code.
        ''' </summary>
        <Extension>
        Public Function TryGetSpeculativeSemanticModel(semanticModel As SemanticModel, position As Integer, attribute As AttributeSyntax, <Out> ByRef speculativeModel As SemanticModel) As Boolean
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.TryGetSpeculativeSemanticModel(position, attribute, speculativeModel)
            Else
                speculativeModel = Nothing
                Return False
            End If
        End Function

        ''' <summary>
        ''' Gets the SemanticModel for a TypeSyntax at a given position, used in Semantic Info for items not appearing in source code.
        ''' </summary>
        <Extension>
        Public Function TryGetSpeculativeSemanticModel(semanticModel As SemanticModel, position As Integer, type As TypeSyntax, <Out> ByRef speculativeModel As SemanticModel, Optional bindingOption As SpeculativeBindingOption = SpeculativeBindingOption.BindAsExpression) As Boolean
            Dim vbmodel = TryCast(semanticModel, VBSemanticModel)
            If vbmodel IsNot Nothing Then
                Return vbmodel.TryGetSpeculativeSemanticModel(position, type, speculativeModel, bindingOption)
            Else
                speculativeModel = Nothing
                Return False
            End If
        End Function

    End Module

End Namespace
