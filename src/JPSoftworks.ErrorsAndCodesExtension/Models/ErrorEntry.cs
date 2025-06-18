// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JPSoftworks.ErrorsAndCodes.Models;

public partial class ErrorEntry
{
    public string DecimalCode { get; }
    public string HexCode { get; }
    public string Symbol { get; }
    public string Message { get; }
    public string Header { get; }

    public ErrorEntry(string dec, string hex, string sym, string msg, string header)
    {
        this.DecimalCode = dec;
        this.HexCode = hex;
        this.Symbol = sym;
        this.Message = msg;
        this.Header = header;
    }
}

public partial class Facility
{
    public int Code { get; }
    public string Name { get; }

    public Facility(int code, string name)
    {
        this.Code = code;
        this.Name = name;
    }
}