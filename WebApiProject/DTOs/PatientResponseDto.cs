namespace WebApiProject.DTOs
{
    public class PatientResponseDto
    {
        public string Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Insurance { get; set; }
        public string MRN { get; set; }
        public string PreferredLanguage { get; set; }
        public string CommunicationPreferences { get; set; }
    }

    public class PatientSearchRequestDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? Dob { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Mrn { get; set; }

        public string? InsuranceId { get; set; }
    }

    public class PatientSearchResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        public string Disease { get; set; } = null!;

        public string? Mrn { get; set; }

        public DateTime? Dob { get; set; }
    }
}
