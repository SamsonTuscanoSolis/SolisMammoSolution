namespace WebApiProject.Models
{
    public class Slot
    {
        public int SlotId { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int FacilityId { get; set; }
        public string Facility { get; set; }
        public string Room { get; set; }
        public string Modality { get; set; }
        public string ExamType { get; set; }
        public bool IsAvailable { get; set; }
        public int? InsurancePlanId { get; set; }
        public string Provider { get; set; } // Nullable, if applicable
    }
}
