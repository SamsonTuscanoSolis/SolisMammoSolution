using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class Appointment
    {
        //public int Id { get; set; }

        //public int PatientId { get; set; }

        //public DateTime AppointmentDate { get; set; }

        //public string Status { get; set; }

        //public string DoctorName { get; set; }

        //public string Department { get; set; }

        //public string Location { get; set; }

        //public DateTime CreatedDate { get; set; }

        //// Navigation property
        //public Patient Patient { get; set; }




        public int Id { get; set; }

        public int PatientId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string Facility { get; set; }

        public string Modality { get; set; }

        public string ExamType { get; set; }

        public string Status { get; set; }

        public string ReferringPhysician { get; set; }

        public string OrderInfo { get; set; }

        public DateTime CreatedDate { get; set; }

        // Navigation property
        [NotMapped]
        public Patient Patient { get; set; }
    }
}
