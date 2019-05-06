' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports System.Collections.Immutable
Imports System.Globalization
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.CodeAnalysis.Emit
Imports Microsoft.CodeAnalysis.PooledObjects
Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports Microsoft.CodeAnalysis.VisualBasic.SyntaxFacts

Namespace Microsoft.CodeAnalysis.VisualBasic

    Partial Class VisualBasicCommandLineArguments

        Protected Friend Class Mutable_VBCommandLineArguments

            Protected Friend Sub New(args As IEnumerable(Of String), c As VisualBasicCommandLineParser, baseDirectory As String, IsScriptRunner As Boolean)
                Me.IsScriptCommandLineParser = IsScriptRunner
                scriptArgs = If(IsScriptRunner, New List(Of String)(), Nothing)
                c.FlattenArgs(args, diagnostics, flattenedArgs, scriptArgs, baseDirectory, responsePaths)
                Me.BaseDirectory = baseDirectory
                outputDirectory = Me.BaseDirectory
            End Sub

            Friend IsScriptCommandLineParser As Boolean = False
            Friend baseDirectory AS String
            Friend diagnostics As List(Of Diagnostic) = New List(Of Diagnostic)()
            Friend flattenedArgs As List(Of String) = New List(Of String)()
            Friend scriptArgs As List(Of String)

            ' normalized paths to directories containing response files:
            Friend responsePaths As New List(Of String)
            Friend displayLogo As Boolean = True
            Friend displayHelp As Boolean = False
            Friend displayVersion As Boolean = False
            Friend displayLangVersions As Boolean = False
            Friend outputLevel As OutputLevel = OutputLevel.Normal
            Friend optimize As Boolean = False
            Friend checkOverflow As Boolean = True
            Friend concurrentBuild As Boolean = True
            Friend deterministic As Boolean = False
            Friend emitPdb As Boolean
            Friend debugInformationFormat As DebugInformationFormat = If(PathUtilities.IsUnixLikePlatform, DebugInformationFormat.PortablePdb, DebugInformationFormat.Pdb)
            Friend noStdLib As Boolean = False
            Friend utf8output As Boolean = False
            Friend outputFileName As String = Nothing
            Friend outputRefFileName As String = Nothing
            Friend refOnly As Boolean = False
            Friend outputDirectory As String = baseDirectory
            Friend documentationPath As String = Nothing
            Friend errorLogPath As String = Nothing
            Friend parseDocumentationComments As Boolean = False ' Don't just null check documentationFileName because we want to do this even if the file name is invalid.
            Friend outputKind As OutputKind = OutputKind.ConsoleApplication
            Friend ssVersion As SubsystemVersion = SubsystemVersion.None
            Friend languageVersion As Language.Version.LanguageVersionService.LanguageVersion = Language.Version.LanguageVersionService.LanguageVersion.Default
            Friend mainTypeName As String = Nothing
            Friend win32ManifestFile As String = Nothing
            Friend win32ResourceFile As String = Nothing
            Friend win32IconFile As String = Nothing
            Friend noWin32Manifest As Boolean = False
            Friend managedResources as New List(Of ResourceDescription)()
            Friend sourceFiles as New List(Of CommandLineSourceFile)()
            Friend hasSourceFiles as boolean = False
            Friend additionalFiles as New List(Of CommandLineSourceFile)()
            Friend analyzerConfigPaths As ArrayBuilder(Of String) = ArrayBuilder(Of String).GetInstance()
            Friend embeddedFiles as New List(Of CommandLineSourceFile)()
            Friend embedAllSourceFiles as Boolean = False
            Friend codepage As Encoding = Nothing
            Friend checksumAlgorithm as SourceHashAlgorithm = SourceHashAlgorithm.Sha256
            Friend defines As IReadOnlyDictionary(Of String, Object) = Nothing
            Friend metadataReferences as New List(Of CommandLineReference)()
            Friend analyzers as New List(Of CommandLineAnalyzerReference)()
            Friend sdkPaths As New List(Of String)()
            Friend sdkDirectory As String = Nothing
            Friend libPaths As New List(Of String)()
            Friend sourcePaths As New List(Of String)()
            Friend keyFileSearchPaths as New List(Of String)()
            Friend globalImports as New List(Of GlobalImport)
            Friend rootNamespace As String = ""
            Friend optionStrict As OptionStrict = OptionStrict.Off
            Friend optionInfer As Boolean = False ' MSDN says: ...The compiler default for this option is /optioninfer-.
            Friend optionExplicit As Boolean = True
            Friend optionCompareText As Boolean = False
            Friend embedVbCoreRuntime As Boolean = False
            Friend platform As Platform = Platform.AnyCpu
            Friend preferredUILang As CultureInfo = Nothing
            Friend fileAlignment As Integer = 0
            Friend baseAddress As ULong = 0
            Friend highEntropyVA As Boolean = False
            Friend vbRuntimePath As String = Nothing
            Friend includeVbRuntimeReference As Boolean = True
            Friend generalDiagnosticOption As ReportDiagnostic = ReportDiagnostic.Default
            Friend pathMap As ImmutableArray(Of KeyValuePair(Of String, String)) = ImmutableArray(Of KeyValuePair(Of String, String)).Empty

            ' Diagnostic ids specified via /nowarn /warnaserror must be processed in case-insensitive fashion.
            Friend specificDiagnosticOptionsFromRuleSet as New Dictionary(Of String, ReportDiagnostic)(CaseInsensitiveComparison.Comparer)
            Friend specificDiagnosticOptionsFromGeneralArguments as New Dictionary(Of String, ReportDiagnostic)(CaseInsensitiveComparison.Comparer)
            Friend specificDiagnosticOptionsFromSpecificArguments as New Dictionary(Of String, ReportDiagnostic)(CaseInsensitiveComparison.Comparer)
            Friend specificDiagnosticOptionsFromNoWarnArguments as New Dictionary(Of String, ReportDiagnostic)(CaseInsensitiveComparison.Comparer)
            Friend keyFileSetting As String = Nothing
            Friend keyContainerSetting As String = Nothing
            Friend delaySignSetting As Boolean? = Nothing
            Friend moduleAssemblyName As String = Nothing
            Friend moduleName As String = Nothing
            Friend touchedFilesPath As String = Nothing
            Friend features as New List(Of String)()
            Friend reportAnalyzer As Boolean = False
            Friend publicSign As Boolean = False
            Friend interactiveMode As Boolean = False
            Friend instrumentationKinds As ArrayBuilder(Of InstrumentationKind) = ArrayBuilder(Of InstrumentationKind).GetInstance()
            Friend sourceLink As String = Nothing
            Friend ruleSetPath As String = Nothing



            Friend Function ToImmutable(parsedFeatures As ImmutableDictionary(Of String, String),
                                        specificDiagnosticOptions As IEnumerable(Of KeyValuePair(Of String, ReportDiagnostic)),
                                        compilationName As String,
                                        GenerateFileNameForDocComment As String,
                                        defaultCoreLibraryReference As CommandLineReference?,
                                        searchPaths As ImmutableArray(Of String)
                                        ) As VisualBasicCommandLineArguments
                Dim parseOptions As New VisualBasicParseOptions(
                                               languageVersion:= languageVersion,
                                             documentationMode:= If(parseDocumentationComments,
                                                                    DocumentationMode.Diagnose,
                                                                    DocumentationMode.None),
                                                          kind:= If(IsScriptCommandLineParser, SourceCodeKind.Script, SourceCodeKind.Regular),
                                           preprocessorSymbols:= AddPredefinedPreprocessorSymbols(outputKind, defines.AsImmutableOrEmpty()),
                                                      features:= parsedFeatures
                                                               )

                ' We want to report diagnostics with source suppression in the error log file.
                ' However, these diagnostics won't be reported on the command line.
                Dim reportSuppressedDiagnostics = errorLogPath IsNot Nothing
                Dim options = New VisualBasicCompilationOptions(
                outputKind:=outputKind,
                moduleName:=moduleName,
                mainTypeName:=mainTypeName,
                scriptClassName:=WellKnownMemberNames.DefaultScriptClassName,
                globalImports:=globalImports,
                rootNamespace:=rootNamespace,
                optionStrict:=optionStrict,
                optionInfer:=optionInfer,
                optionExplicit:=optionExplicit,
                optionCompareText:=optionCompareText,
                embedVbCoreRuntime:=embedVbCoreRuntime,
                checkOverflow:=checkOverflow,
                concurrentBuild:=concurrentBuild,
                deterministic:=deterministic,
                cryptoKeyContainer:=keyContainerSetting,
                cryptoKeyFile:=keyFileSetting,
                delaySign:=delaySignSetting,
                publicSign:=publicSign,
                platform:=platform,
                generalDiagnosticOption:=generalDiagnosticOption,
                specificDiagnosticOptions:=specificDiagnosticOptions,
                optimizationLevel:=If(optimize, OptimizationLevel.Release, OptimizationLevel.Debug),
                parseOptions:=parseOptions,
                reportSuppressedDiagnostics:=reportSuppressedDiagnostics)


                Dim emitOptions = New EmitOptions(
                metadataOnly:=refOnly,
                includePrivateMembers:=Not refOnly AndAlso outputRefFileName Is Nothing,
                debugInformationFormat:=debugInformationFormat,
                pdbFilePath:=Nothing, ' to be determined later
                outputNameOverride:=Nothing,  ' to be determined later
                fileAlignment:=fileAlignment,
                baseAddress:=baseAddress,
                highEntropyVirtualAddressSpace:=highEntropyVA,
                subsystemVersion:=ssVersion,
                runtimeMetadataVersion:=Nothing,
                instrumentationKinds:=instrumentationKinds.ToImmutableAndFree(),
                pdbChecksumAlgorithm:=HashAlgorithmName.SHA256) ' TODO: set from /checksumalgorithm (see https://github.com/dotnet/roslyn/issues/24735)


                ' add option incompatibility errors if any
                diagnostics.AddRange(options.Errors)

                If documentationPath Is GenerateFileNameForDocComment Then
                    documentationPath = PathUtilities.CombineAbsoluteAndRelativePaths(outputDirectory, PathUtilities.RemoveExtension(outputFileName))
                    documentationPath = documentationPath + ".xml"
                End If

            ' Enable interactive mode if either `\i` option is passed in or no arguments are specified (`vbi`, `vbi script.vbx \i`).
            ' If the script is passed without the `\i` option simply execute the script (`vbi script.vbx`).
            interactiveMode = interactiveMode Or (IsScriptCommandLineParser AndAlso sourceFiles.Count = 0)

            Return New VisualBasicCommandLineArguments With
            {
                .IsScriptRunner = IsScriptCommandLineParser,
                .InteractiveMode = interactiveMode,
                .BaseDirectory = baseDirectory,
                .Errors = diagnostics.AsImmutable(),
                .Utf8Output = utf8output,
                .CompilationName = compilationName,
                .OutputFileName = outputFileName,
                .OutputRefFilePath = outputRefFileName,
                .OutputDirectory = outputDirectory,
                .DocumentationPath = documentationPath,
                .ErrorLogPath = errorLogPath,
                .SourceFiles = sourceFiles.AsImmutable(),
                .PathMap = pathMap,
                .Encoding = codepage,
                .ChecksumAlgorithm = checksumAlgorithm,
                .MetadataReferences = metadataReferences.AsImmutable(),
                .AnalyzerReferences = analyzers.AsImmutable(),
                .AdditionalFiles = additionalFiles.AsImmutable(),
                .AnalyzerConfigPaths = analyzerConfigPaths.ToImmutableAndFree(),
                .ReferencePaths = searchPaths,
                .SourcePaths = sourcePaths.AsImmutable(),
                .KeyFileSearchPaths = keyFileSearchPaths.AsImmutable(),
                .Win32ResourceFile = win32ResourceFile,
                .Win32Icon = win32IconFile,
                .Win32Manifest = win32ManifestFile,
                .NoWin32Manifest = noWin32Manifest,
                .DisplayLogo = displayLogo,
                .DisplayHelp = displayHelp,
                .DisplayVersion = displayVersion,
                .DisplayLangVersions = displayLangVersions,
                .ManifestResources = managedResources.AsImmutable(),
                .CompilationOptions = options,
                .ParseOptions = parseOptions,
                .EmitOptions = emitOptions,
                .ScriptArguments = scriptArgs.AsImmutableOrEmpty(),
                .TouchedFilesPath = touchedFilesPath,
                .OutputLevel = outputLevel,
                .EmitPdb = emitPdb AndAlso Not refOnly, ' Silently ignore emitPdb when refOnly is set
                .SourceLink = sourceLink,
                .RuleSetPath = ruleSetPath,
                .DefaultCoreLibraryReference = defaultCoreLibraryReference,
                .PreferredUILang = preferredUILang,
                .ReportAnalyzer = reportAnalyzer,
                .EmbeddedFiles = embeddedFiles.AsImmutable()
            }
            End Function

        End Class

    End Class

End Namespace
