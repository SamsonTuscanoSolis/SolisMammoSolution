using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public class FacilityRepository : IFacilityRepository
    {
        public IEnumerable<Facility> GetFacilities()
        {
            return new List<Facility>
            {
                new Facility
                {
                    FacilityId = 1,
                    Name = "City Hospital",
                    Address = "123 Main St",
                    Phone = "555-1234",
                    Hours = "8AM - 6PM",
                    ModalitiesAvailable = new List<string>{"MRI","CT Scan"},
                    AcceptingStatus = true,
                    Latitude = 40.7128,
                    Longitude = -74.0060
                }
            };
        }
    }

}
