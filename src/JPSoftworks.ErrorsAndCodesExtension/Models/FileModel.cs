// ------------------------------------------------------------
// 
// Copyright (c) Jiří Polášek. All rights reserved.
// 
// ------------------------------------------------------------

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JPSoftworks.ErrorsAndCodes.Models;

public sealed class HeaderFile
{
    public string HeaderFileName { get; set; }

    public List<ErrorCodeDto> ErrorCodes { get; set; } = [];

    public List<FacilityDto> Facilities { get; set; } = [];
}

public sealed class FacilityDto(string Name, int Code)
{
    public string Name { get; init; } = Name;
    public int Code { get; init; } = Code;

    public void Deconstruct(out string Name, out int Code)
    {
        Name = this.Name;
        Code = this.Code;
    }
}

public sealed record ErrorCodeDto
{
    public string Id { get; set; }
    public string Message { get; set; }
    public int DecimalCode { get; set; } // Decimal representation of the error code; value is equivalent to HexCode

    public string
        HexCode { get; set; } // Hexadecimal representation of the error code; value is equivalent to DecimalCode

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public CodeType Type { get; set; }

    public ErrorCodeDto(string id, string message, int decimalCode, string hexCode, CodeType type)
    {
        this.Id = id;
        this.Message = message;
        this.DecimalCode = decimalCode;
        this.HexCode = hexCode;
        this.Type = type;
    }

    public void Deconstruct(
        out string Id,
        out string Message,
        out int DecimalCode,
        out string HexCode,
        out CodeType Type)
    {
        Id = this.Id;
        Message = this.Message;
        DecimalCode = this.DecimalCode;
        HexCode = this.HexCode;
        Type = this.Type;
    }
}

public enum CodeType
{
    Unknown,
    HResult,
    NTStatus,
    Win32Error,
    PlainNumber
}