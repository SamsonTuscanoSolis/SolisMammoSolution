namespace WebApiProject.Models
{
    //public class ExamResult
    //{
    //    public int ResultId { get; set; }
    //    public int PatientId { get; set; }
    //    public string ExamName { get; set; } = null!;
    //    public string Status { get; set; } = null!;
    //    public DateTime ResultDate { get; set; }
    //}

    public class ExamResult
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string ExamType { get; set; }

        public DateTime ExamDate { get; set; }

        public string ResultStatus { get; set; }  // pending | preliminary | final

        public bool ReportAvailable { get; set; }

        public DateTime? ResultDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public Patient Patient { get; set; }
    }
}
