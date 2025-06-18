// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using JPSoftworks.ErrorsAndCodes.Services.WindowsErrors;

namespace JPSoftworks.ErrorsAndCodes.Services;

public sealed record LookupResult(
    Interpretation Interpretation,
    ErrorCodeWithSource Entry,
    HeaderFilePriority Priority);