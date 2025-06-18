// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using System;
using System.Text;

namespace JPSoftworks.ErrorsAndCodes.Helpers;

public static class MarkdownHelper
{
    // Characters that need to be escaped in markdown
    private static readonly char[] SpecialChars =
        ['\\', '`', '*', '_', '{', '}', '[', ']', '<', '>', '(', ')', '#', '+', '-', '.', '!', '|', '~'];

    /// <summary>
    /// Escapes special markdown characters so text displays literally
    /// </summary>
    /// <param name="text">The text to escape</param>
    /// <returns>Escaped text safe for markdown display</returns>
    public static string EscapeMarkdown(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        var sb = new StringBuilder(text.Length * 2); // Pre-allocate assuming some escaping needed

        foreach (char c in text)
        {
            if (Array.IndexOf(SpecialChars, c) >= 0)
            {
                sb.Append('\\');
            }

            sb.Append(c);
        }

        return sb.ToString();
    }
}