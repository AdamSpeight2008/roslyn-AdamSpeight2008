﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.LanguageServer.Protocol;
using StreamJsonRpc;

namespace Microsoft.CodeAnalysis.LanguageServer.Handler;

public class ClientLanguageServerManager : IClientLanguageServerManager
{
    private readonly JsonRpc _jsonRpc;

    public ClientLanguageServerManager(JsonRpc jsonRpc)
    {
        if (jsonRpc is null)
        {
            throw new ArgumentNullException(nameof(jsonRpc));
        }

        _jsonRpc = jsonRpc;
    }

    public async ValueTask SendNotificationAsync(string methodName, CancellationToken cancellationToken)
        => await _jsonRpc.NotifyAsync(methodName).ConfigureAwait(false);

    public async ValueTask SendNotificationAsync<TParams>(string methodName, TParams @params, CancellationToken cancellationToken)
    {
        await _jsonRpc.NotifyWithParameterObjectAsync(methodName, @params);
    }
}
