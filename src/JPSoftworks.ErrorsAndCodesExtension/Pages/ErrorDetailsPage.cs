// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using System;
using JPSoftworks.ErrorsAndCodes.Helpers;
using JPSoftworks.ErrorsAndCodes.Services.WindowsErrors;
using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;

namespace JPSoftworks.ErrorsAndCodes.Pages;

internal sealed partial class ErrorDetailsPage : ContentPage
{
    private readonly ErrorCodeWithSource _errorCodeWithSource;

    public ErrorDetailsPage(ErrorCodeWithSource errorCodeWithSource)
    {
        ArgumentNullException.ThrowIfNull(errorCodeWithSource);

        this._errorCodeWithSource = errorCodeWithSource;
        this.Icon = Icons.Message;
        this.Name = "Show details";
    }

    public override IContent[] GetContent()
    {
        return
        [
            new MarkdownContent($"# {MarkdownHelper.EscapeMarkdown(this._errorCodeWithSource.ErrorCode.Id)}"),
            new MarkdownContent(string.IsNullOrWhiteSpace(this._errorCodeWithSource.ErrorCode.Message)
                ? "(no message)"
                : MarkdownHelper.EscapeMarkdown(this._errorCodeWithSource.ErrorCode.Message)),
            new MarkdownContent($"""
                                 ## Source ##
                                 `{this._errorCodeWithSource.SourceFile}`
                                 """),
            new MarkdownContent($"""
                                 ## Value (hex) ##
                                 `{this._errorCodeWithSource.ErrorCode.HexCode}`
                                 """),
            new MarkdownContent($"""
                                 ## Value (decimal) ##
                                 `{this._errorCodeWithSource.ErrorCode.DecimalCode}`
                                 """),
        ];
    }
}