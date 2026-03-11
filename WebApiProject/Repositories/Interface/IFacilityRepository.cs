using WebApiProject.Models;

namespace WebApiProject.Repositories.Interface
{
    public interface IFacilityRepository
    {
        IEnumerable<Facility> GetFacilities();
    }
}
