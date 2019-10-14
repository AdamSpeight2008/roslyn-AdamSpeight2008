' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

'-----------------------------------------------------------------------------
' Contains the definition of the Scanner, which produces tokens from text 
'-----------------------------------------------------------------------------

Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Microsoft.CodeAnalysis.PooledObjects
Imports Microsoft.CodeAnalysis.Syntax.InternalSyntax
Imports Microsoft.CodeAnalysis.Text
Imports CoreInternalSyntax = Microsoft.CodeAnalysis.Syntax.InternalSyntax
Imports InternalSyntaxFactory = Microsoft.CodeAnalysis.VisualBasic.Syntax.InternalSyntax.SyntaxFactory

Namespace Microsoft.CodeAnalysis.VisualBasic.Syntax.InternalSyntax

    Partial Friend Class Parser

        ''' <summary>
        ''' Check to see if the given <paramref name="feature"/> is available with the <see cref="LanguageVersion"/>
        ''' of the parser.  If it is not available a diagnostic will be added to the returned value.
        ''' </summary>
        Private Function CheckFeatureAvailability(Of TNode As VisualBasicSyntaxNode)(feature As Feature, node As TNode) As TNode
            Return CheckFeatureAvailability(feature, node, _scanner.Options.LanguageVersion)
        End Function

        Friend Shared Function CheckFeatureAvailability(Of TNode As VisualBasicSyntaxNode)(feature As Feature, node As TNode, languageVersion As LanguageVersion) As TNode
            If CheckFeatureAvailability(languageVersion, feature) Then
                Return node
            End If

            Return ReportFeatureUnavailable(feature, node, languageVersion)
        End Function

        Private Shared Function ReportFeatureUnavailable(Of TNode As VisualBasicSyntaxNode)(feature As Feature, node As TNode, languageVersion As LanguageVersion) As TNode
            Dim featureName = ErrorFactory.ErrorInfo(feature.GetResourceId())
            Dim requiredVersion = New VisualBasicRequiredLanguageVersion(feature.GetLanguageVersion())
            Return ReportSyntaxError(node, ERRID.ERR_LanguageVersion, languageVersion.GetErrorName(), featureName, requiredVersion)
        End Function

        Friend Function ReportFeatureUnavailable(Of TNode As VisualBasicSyntaxNode)(feature As Feature, node As TNode) As TNode
            Return ReportFeatureUnavailable(feature, node, _scanner.Options.LanguageVersion)
        End Function

        Friend Function CheckFeatureAvailability(feature As Feature) As Boolean
            Return CheckFeatureAvailability(_scanner.Options.LanguageVersion, feature)
        End Function

        Friend Shared Function CheckFeatureAvailability(languageVersion As LanguageVersion, feature As Feature) As Boolean
            Dim required = feature.GetLanguageVersion()
            Return required <= languageVersion
        End Function

        ''' <summary>
        ''' Returns false and reports an error if the feature is un-available
        ''' </summary>
        Friend Shared Function CheckFeatureAvailability(diagnostics As DiagnosticBag, location As Location, languageVersion As LanguageVersion, feature As Feature) As Boolean
            If CheckFeatureAvailability(languageVersion, feature) Then Return True
            Dim featureName = ErrorFactory.ErrorInfo(feature.GetResourceId())
            Dim requiredVersion = New VisualBasicRequiredLanguageVersion(feature.GetLanguageVersion())
            diagnostics.Add(ERRID.ERR_LanguageVersion, location, languageVersion.GetErrorName(), featureName, requiredVersion)
            Return False
        End Function

    End Class

End Namespace
