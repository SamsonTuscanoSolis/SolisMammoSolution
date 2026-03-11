namespace WebApiProject.DTOs
{
    public class SlotDTO
    {
        public int SlotId { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string Facility { get; set; }
        public string Room { get; set; }
        public string Modality { get; set; }
        public string Provider { get; set; } // Nullable, if applicable
    }
}
