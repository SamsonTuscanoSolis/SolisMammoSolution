namespace WebApiProject.DTOs
{
    public class AppointmentDto
    {
        //public int AppointmentId { get; set; }
        //public DateTime AppointmentDate { get; set; }
        //public string Status { get; set; }
        //public string DoctorName { get; set; }
        //public string Department { get; set; }
        //public string Location { get; set; }

        public int AppointmentId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string Facility { get; set; }

        public string Modality { get; set; }

        public string ExamType { get; set; }

        public string Status { get; set; }

        public string ReferringPhysician { get; set; }

        public string OrderInfo { get; set; }
    }
}
