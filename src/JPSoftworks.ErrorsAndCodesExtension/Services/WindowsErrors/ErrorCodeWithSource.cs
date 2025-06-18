// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using JPSoftworks.ErrorsAndCodes.Models;

namespace JPSoftworks.ErrorsAndCodes.Services.WindowsErrors;

public record ErrorCodeWithSource(ErrorCodeDto ErrorCode, string SourceFile);