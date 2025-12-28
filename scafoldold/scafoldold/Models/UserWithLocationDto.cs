namespace scafoldold.Models
{
    public class UserWithLocationDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public DateOnly? Dob { get; set; }  // Added get/set for Dob
        public string Submitted { get; set; }  // Added get/set for Submitted
        public string Skills { get; set; }  // Added get/set for Skills
        public int? Units { get; set; }  

        public int? CountryId { get; set; }
        public string? CountryName { get; set; }

        public int? StateId { get; set; }
        public string? StateName { get; set; }

        public int? DistrictId { get; set; }
        public string? DistrictName { get; set; }
    }
}
