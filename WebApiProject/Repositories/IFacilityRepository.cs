using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public interface IFacilityRepository
    {
        IEnumerable<Facility> GetFacilities();
    }
}
