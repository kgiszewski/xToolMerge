﻿using System.Text.Json.Serialization;

namespace xToolMerge.Xcs.Models;

public class CoordinateModel
{
    [JsonPropertyName("x")]
    public decimal X { get; set; }
    [JsonPropertyName("y")]
    public decimal Y { get; set; }
}