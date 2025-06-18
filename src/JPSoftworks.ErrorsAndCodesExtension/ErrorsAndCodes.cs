// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.CommandPalette.Extensions;

namespace JPSoftworks.ErrorsAndCodes;

[Guid("beec796b-beb5-497f-95eb-5319592cbb09")]
public sealed partial class ErrorsAndCodes : IExtension, IDisposable
{
    private readonly ManualResetEvent _extensionDisposedEvent;

    private readonly ErrorsAndCodesCommandsProvider _provider = new();

    public ErrorsAndCodes(ManualResetEvent extensionDisposedEvent)
    {
        this._extensionDisposedEvent = extensionDisposedEvent;
    }

    public object? GetProvider(ProviderType providerType)
    {
        return providerType switch
        {
            ProviderType.Commands => this._provider,
            _ => null,
        };
    }

    public void Dispose() => this._extensionDisposedEvent.Set();
}