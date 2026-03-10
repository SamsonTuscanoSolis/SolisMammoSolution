namespace WebApiProject.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Disease { get; set; } = null!;
        public string? Mrn { get; set; } = null!;
        public DateTime? Dob { get; set; } = null!;
    }

}
