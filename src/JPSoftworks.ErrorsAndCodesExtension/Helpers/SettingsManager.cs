// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using System.IO;
using JPSoftworks.ErrorsAndCodes.Resources;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace JPSoftworks.ErrorsAndCodes.Helpers;

internal sealed class SettingsManager : JsonSettingsManager
{
    private const string DefaultNamespace = "jpsoftworks.errorsandcodes";

    private readonly ToggleSetting _showDetailsOption = new(
        Namespaced(nameof(ShowDetails)),
        Strings.Settings_ShowDetails_Title!,
        Strings.Settings_ShowDetails_Subtitle!,
        false);

    public bool ShowDetails => this._showDetailsOption.Value;

    public SettingsManager()
    {
        this.FilePath = SettingsJsonPath();
        this.Settings.Add(this._showDetailsOption);
        this.LoadSettings();
        this.Settings.SettingsChanged += (_, _) => this.SaveSettings();
    }

    private static string Namespaced(string propertyName)
    {
        return $"{DefaultNamespace}.{propertyName}";
    }

    private static string SettingsJsonPath()
    {
        var directory = Utilities.BaseSettingsPath("Microsoft.CmdPal");
        Directory.CreateDirectory(directory);
        return Path.Combine(directory, "settings.json");
    }
}