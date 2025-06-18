// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using JPSoftworks.CommandPalette.Extensions.Toolkit.Helpers;
using JPSoftworks.CommandPalette.Extensions.Toolkit.Logging;
using Microsoft.CommandPalette.Extensions;
using Shmuelie.WinRTServer.CsWinRT;

namespace JPSoftworks.ErrorsAndCodes;

public static class Program
{
    [MTAThread]
    public static async Task Main(string[] args)
    {
        Logger.Initialize("JPSoftworks", "ErrorsAndCodes");

        if (args.Length > 0 && args[0] == "-RegisterProcessAsComServer")
        {
            global::Shmuelie.WinRTServer.ComServer server = new();

            ManualResetEvent extensionDisposedEvent = new(false);

            // We are instantiating an extension instance once above, and returning it every time the callback in RegisterExtension below is called.
            // This makes sure that only one instance of SampleExtension is alive, which is returned every time the host asks for the IExtension object.
            // If you want to instantiate a new instance each time the host asks, create the new instance inside the delegate.
            ErrorsAndCodes extensionInstance = new(extensionDisposedEvent);
            server.RegisterClass<ErrorsAndCodes, IExtension>(() => extensionInstance);
            server.Start();

            // This will make the main thread wait until the event is signalled by the extension class.
            // Since we have single instance of the extension object, we exit as soon as it is disposed.
            extensionDisposedEvent.WaitOne();
            server.Stop();
            server.UnsafeDispose();
        }
        else
        {
            await StartupHelper.HandleDirectLaunchAsync();
        }
    }
}