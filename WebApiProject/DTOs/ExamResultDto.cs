namespace WebApiProject.DTOs
{
    public class ExamResultDto
    {
        public int ExamId { get; set; }

        public string ExamType { get; set; }

        public DateTime ExamDate { get; set; }

        public string ResultStatus { get; set; }

        public bool ReportAvailable { get; set; }

        public DateTime? ResultDate { get; set; }
    }
}
