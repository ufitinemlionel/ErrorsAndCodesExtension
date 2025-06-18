// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using System.Collections.Generic;

namespace JPSoftworks.ErrorsAndCodes.Services;

public interface IErrorLookup
{
    IEnumerable<LookupResult> Lookup(string input);
}