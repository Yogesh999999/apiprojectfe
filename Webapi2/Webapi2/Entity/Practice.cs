namespace Webapi2.Entity
{
    public class Practice
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }

        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;


    }
}
