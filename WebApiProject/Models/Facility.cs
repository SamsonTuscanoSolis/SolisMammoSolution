
namespace WebApiProject.Models
{
    public class Facility
    {
        public int FacilityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Hours { get; set; }
        public List<string> ModalitiesAvailable { get; set; }
        public bool AcceptingStatus { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
