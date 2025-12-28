using System;
using System.Collections.Generic;

namespace Webapi3.Models;

/// <summary>
/// 
/// 
/// 
/// </summary>
public partial class Detail
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int? Pincode { get; set; }
}
