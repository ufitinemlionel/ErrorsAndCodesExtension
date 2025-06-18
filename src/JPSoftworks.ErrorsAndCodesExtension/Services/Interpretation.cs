// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

namespace JPSoftworks.ErrorsAndCodes.Services;

public record Interpretation(string Description, MatchType MatchType, string? Details = null);