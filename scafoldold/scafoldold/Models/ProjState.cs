using System;
using System.Collections.Generic;

namespace scafoldold.Models;

public partial class ProjState
{
    public int StateId { get; set; }

    public string? StateNames { get; set; }

    public int? CountryId { get; set; }

    public virtual ProjCountry? Country { get; set; }

    public virtual ICollection<ProjDistrict> ProjDistricts { get; set; } = new List<ProjDistrict>();

    public virtual ICollection<ProjId> ProjIds { get; set; } = new List<ProjId>();
}
