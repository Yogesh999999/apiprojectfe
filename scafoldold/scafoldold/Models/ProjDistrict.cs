using System;
using System.Collections.Generic;

namespace scafoldold.Models;

public partial class ProjDistrict
{
    public int DistrictId { get; set; }

    public string? DistrictNames { get; set; }

    public int? StateId { get; set; }

    public virtual ProjState? State { get; set; }
}
