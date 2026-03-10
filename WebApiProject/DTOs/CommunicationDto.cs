namespace WebApiProject.DTOs
{
    public class CommunicationDto
    {
        public int CommId { get; set; }

        public string Channel { get; set; }

        public DateTime DateTime { get; set; }

        public string Template { get; set; }

        public string CampaignId { get; set; }

        public string Status { get; set; }

        public string Response { get; set; }
    }
}
