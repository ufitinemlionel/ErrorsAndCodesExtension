// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

namespace JPSoftworks.ErrorsAndCodes.Services;

public enum MatchType
{
    /// <summary>
    /// Matches the error code or the symbol exactly, without any transformations or interpretations.
    /// </summary>
    Exact,

    /// <summary>
    /// Matches the error code after some value transformation.
    /// </summary>
    Inferred,

    /// <summary>
    /// Partial matches the error code, such as matching a substring of the symbol name or a partial numeric value.
    /// </summary>
    Partial
}