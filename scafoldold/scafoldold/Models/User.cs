using System;
using System.Collections.Generic;

namespace scafoldold.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Submitted { get; set; }

    public bool IsDeleted { get; set; }

    public string? Skills { get; set; }

    public int? Units { get; set; }
}
