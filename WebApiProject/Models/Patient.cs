namespace WebApiProject.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Disease { get; set; } = null!;
        public string? Mrn { get; set; } = null!;
        public DateTime? Dob { get; set; } = null!;
    }
}
