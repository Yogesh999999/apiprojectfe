using System;
using System.Collections.Generic;

namespace scafoldold.Models;

public partial class ProjCountry
{
    public int CountryId { get; set; }

    public string? CountryNames { get; set; }

    public virtual ICollection<ProjId> ProjIds { get; set; } = new List<ProjId>();

    public virtual ICollection<ProjState> ProjStates { get; set; } = new List<ProjState>();
}
