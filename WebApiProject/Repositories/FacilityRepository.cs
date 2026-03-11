using WebApiProject.Data;
using WebApiProject.Models;
using WebApiProject.Repositories.Interface;

namespace WebApiProject.Repositories
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<FacilityRepository> _logger;

        public FacilityRepository(AppDbContext context, ILogger<FacilityRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Facility> GetFacilities()
        {
            _logger.LogInformation("Fetching facilities from the database.");

            try
            {
                // Query the facilities from the database
                var facilities = _context.Facilities.ToList(); // Assuming Facilities is a DbSet<Facility>

                if (!facilities.Any())
                {
                    _logger.LogWarning("No facilities found in the database.");
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved {FacilityCount} facility(ies).", facilities.Count);
                }

                return facilities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching facilities.");
                throw; // Rethrow the exception after logging it
            }
        }
    }

}
