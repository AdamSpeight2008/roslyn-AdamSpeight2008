﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.Serialization;

namespace Microsoft.CodeAnalysis.Contracts.EditAndContinue;

/// <summary>
/// Diagnostic information about a particular edit made through hot reload.
/// </summary>
/// <remarks>
/// Creates a new <see cref="ManagedHotReloadDiagnostic"/> for an edit made by the user.
/// </remarks>
/// <param name="id">Diagnostic information identifier.</param>
/// <param name="message">User message.</param>
/// <param name="severity">Severity of the edit, whether it's an error or a warning.</param>
/// <param name="filePath">File path for the target edit.</param>
/// <param name="span">Source span of the edit.</param>
[DataContract]
internal readonly struct ManagedHotReloadDiagnostic(
    string id,
    string message,
    ManagedHotReloadDiagnosticSeverity severity,
    string filePath,
    SourceSpan span)
{

    /// <summary>
    /// Diagnostic information identifier.
    /// </summary>
    [DataMember(Name = "id")]
    public string Id { get; } = id;

    /// <summary>
    /// User message which will be displayed for the edit.
    /// </summary>
    [DataMember(Name = "message")]
    public string Message { get; } = message;

    /// <summary>
    /// Severity of the diagnostic information.
    /// </summary>
    [DataMember(Name = "severity")]
    public ManagedHotReloadDiagnosticSeverity Severity { get; } = severity;

    /// <summary>
    /// File path where the edit was made.
    /// </summary>
    [DataMember(Name = "filePath")]
    public string FilePath { get; } = filePath;

    /// <summary>
    /// Source span for the edit.
    /// </summary>
    [DataMember(Name = "span")]
    public SourceSpan Span { get; } = span;
}
