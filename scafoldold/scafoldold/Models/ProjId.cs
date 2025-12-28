using System;
using System.Collections.Generic;

namespace scafoldold.Models;

public partial class ProjId
{
    public int Id { get; set; }

    public int? UsersId { get; set; }

    public int? CountryId { get; set; }

    public int? StateId { get; set; }

    public int? DistrictId { get; set; }

    public virtual ProjCountry? Country { get; set; }

    public virtual ProjState? State { get; set; }
}
