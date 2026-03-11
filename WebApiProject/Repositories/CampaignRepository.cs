using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;
using WebApiProject.Repositories.Interface;

namespace WebApiProject.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CampaignRepository> _logger;

        public CampaignRepository(AppDbContext context, ILogger<CampaignRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CampaignEligibility?> GetEligibilityAsync(int campaignId, int patientId)
        {
            _logger.LogInformation("Fetching eligibility data for CampaignId: {CampaignId}, PatientId: {PatientId}", campaignId, patientId);

            try
            {
                // Query the database for the campaign and patient eligibility
                var campaignEligibility = await _context.CampaignEligibilities
                    .Where(c => c.CampaignId == campaignId)
                    .Select(c => new CampaignEligibility
                    {
                        CampaignId = c.CampaignId,
                        PatientId = patientId,
                        Eligible = true, // Example logic
                        Reasons = new List<string>
                        {
                        "Age criteria met",  // Example reason
                        "No exam in last 12 months"  // Example reason
                        },
                        LastExamDate = c.LastExamDate,
                        NextDueDate = DateTime.UtcNow.AddMonths(1), // Example next due date
                        OptOutStatus = false,  // Example opt-out status
                        InsuranceEligible = true,  // Example insurance eligibility
                        SuppressionRulesApplied = new List<string>
                        {
                        "No active suppression rules"  // Example suppression rule
                        }
                    })
                    .FirstOrDefaultAsync();

                if (campaignEligibility == null)
                {
                    _logger.LogWarning("Eligibility data not found for CampaignId: {CampaignId}, PatientId: {PatientId}", campaignId, patientId);
                    return null; // Return null if no data found
                }

                _logger.LogInformation("Eligibility data successfully retrieved for CampaignId: {CampaignId}, PatientId: {PatientId}", campaignId, patientId);
                return campaignEligibility;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching eligibility data for CampaignId: {CampaignId}, PatientId: {PatientId}", campaignId, patientId);
                throw; // Rethrow the exception after logging it
            }
        }
    }
}
