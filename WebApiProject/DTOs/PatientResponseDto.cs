namespace WebApiProject.DTOs
{
    public class PatientResponseDto
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Insurance { get; set; }
        public string MRN { get; set; }
        public string PreferredLanguage { get; set; }
        public string CommunicationPreferences { get; set; }
    }
}
