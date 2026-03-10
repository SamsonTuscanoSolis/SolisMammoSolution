namespace WebApiProject.Models
{
    public class Communication
    {
        //public int CommunicationId { get; set; }
        //public int PatientId { get; set; }
        //public string Type { get; set; } = null!;
        //public string Message { get; set; } = null!;
        //public DateTime SentDate { get; set; }

        public int CommId { get; set; }

        public int PatientId { get; set; }

        public string Channel { get; set; } // sms | email | voice | letter

        public DateTime DateTime { get; set; }

        public string Template { get; set; }

        public string CampaignId { get; set; }

        public string Status { get; set; } // sent | delivered | opened | failed | opted-out

        public string Response { get; set; }
    }
}
