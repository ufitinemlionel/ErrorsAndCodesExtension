// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace JPSoftworks.ErrorsAndCodes.Helpers;

internal static class Icons
{
    public static IconInfo Message { get; } = new IconInfo("\uE8BD");

    public static IconInfo MessageGroup { get; } = IconHelpers.FromRelativePath("Assets\\Icons\\BookOfErrors20.png");

    public static IconInfo ErrorsCodesIcon { get; }
        = IconHelpers.FromRelativePath("Assets\\Square44x44Logo.scale-100.png");
}