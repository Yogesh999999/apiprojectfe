using System;
using System.Collections.Generic;

namespace Apidatabase.Models;

public partial class newusers
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public long? Phone { get; set; }

    public string? Dob { get; set; }

    public string? Submitted { get; set; }

    public string? Skills { get; set; }

    public int? Units { get; set; }
}
