using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PatientRepository> _logger;

        public PatientRepository(AppDbContext context, ILogger<PatientRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        //public async Task<Patient?> GetPatientByIdAsync(int patientId)
        //{
        //    return await _context.Patients.FindAsync(patientId);
        //}

        public async Task<Patient> GetPatientByIdAsync(int patientId, string mrn = null, DateTime? dob = null)
        {
            _logger.LogInformation("Repository: Fetching patient {PatientId}", patientId);

            var query = _context.Patients
                                .Where(p => p.Id == patientId)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(mrn))
            {
                _logger.LogInformation("Repository: Filtering by MRN {MRN}", mrn);
                query = query.Where(p => p.Mrn == mrn);
            }

            if (dob.HasValue)
            {
                _logger.LogInformation("Repository: Filtering by DOB {DOB}", dob.Value);
                query = query.Where(p => p.Dob == dob.Value.Date);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Patient>> SearchAsync(string? name, int? age, string? disease)
        {
            var query = _context.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (age.HasValue)
                query = query.Where(p => p.Age == age.Value);

            if (!string.IsNullOrEmpty(disease))
                query = query.Where(p => p.Disease.Contains(disease));

            return await query.ToListAsync();
        }

        //public async Task<List<Appointment>> GetAppointmentsAsync(int patientId)
        //{
        //    return await _context.Appointments.Where(a => a.PatientId == patientId).ToListAsync();
        //}

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync(int patientId, string status, DateTime? dateFrom, DateTime? dateTo)
        {
            _logger.LogInformation("Querying appointments for PatientId: {PatientId}", patientId);

            var query = _context.Appointments
                                .Where(a => a.PatientId == patientId)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                _logger.LogInformation("Applying status filter: {Status}", status);
                query = query.Where(a => a.Status.ToLower() == status.ToLower());
            }

            if (dateFrom.HasValue)
            {
                _logger.LogInformation("Applying dateFrom filter: {DateFrom}", dateFrom);
                query = query.Where(a => a.AppointmentDateTime >= dateFrom.Value);
            }

            if (dateTo.HasValue)
            {
                _logger.LogInformation("Applying dateTo filter: {DateTo}", dateTo);
                query = query.Where(a => a.AppointmentDateTime <= dateTo.Value);
            }

            var appointments = await query.ToListAsync();

            _logger.LogInformation("Total appointments found: {Count}", appointments.Count);

            return appointments;
        }

        //public async Task<List<ExamResult>> GetResultsAsync(int patientId)
        //{
        //    return await _context.ExamResults.Where(r => r.PatientId == patientId).ToListAsync();
        //}

        public async Task<IEnumerable<ExamResult>> GetResultsAsync(int patientId, int? examId, DateTime? dateFrom, DateTime? dateTo)
        {
            _logger.LogInformation("Fetching exam results for PatientId: {PatientId}", patientId);

            var query = _context.ExamResults
                                .Where(r => r.PatientId == patientId)
                                .AsQueryable();

            if (examId.HasValue)
            {
                query = query.Where(r => r.Id == examId.Value);
            }

            if (dateFrom.HasValue)
            {
                query = query.Where(r => r.ExamDate >= dateFrom.Value);
            }

            if (dateTo.HasValue)
            {
                query = query.Where(r => r.ExamDate <= dateTo.Value);
            }

            return await query.ToListAsync();
        }

        //public async Task<List<Communication>> GetCommunicationsAsync(int patientId)
        //{
        //    return await _context.Communications.Where(c => c.PatientId == patientId).ToListAsync();
        //}

        public async Task<List<Communication>> GetCommunicationsAsync(int patientId, string channel, DateTime? dateFrom, DateTime? dateTo, string campaignId)
        {
            _logger.LogInformation("Repository: Fetching communications for PatientId {PatientId}", patientId);

            var query = _context.Communications
                                .Where(c => c.PatientId == patientId)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(channel))
            {
                _logger.LogInformation("Filtering by Channel {Channel}", channel);
                query = query.Where(c => c.Channel.ToLower() == channel.ToLower());
            }

            if (dateFrom.HasValue)
            {
                query = query.Where(c => c.DateTime >= dateFrom.Value);
            }

            if (dateTo.HasValue)
            {
                query = query.Where(c => c.DateTime <= dateTo.Value);
            }

            if (!string.IsNullOrEmpty(campaignId))
            {
                query = query.Where(c => c.CampaignId == campaignId);
            }

            var communications = await query
                                       .OrderByDescending(c => c.DateTime)
                                       .ToListAsync();

            _logger.LogInformation("Repository: Retrieved {Count} communications", communications.Count);

            return communications;
        }

        //public async Task<InsuranceStatus?> GetInsuranceStatusAsync(int patientId)
        //{
        //    return await _context.InsuranceStatuses.FirstOrDefaultAsync(i => i.PatientId == patientId);
        //}

        public async Task<Insurance> GetInsurancesAsync(int patientId, string insurancePlanId, string examType, int facilityId)
        {
            _logger.LogInformation("Repository: Fetching insurance status for PatientId {PatientId}, InsurancePlanId {InsurancePlanId}, ExamType {ExamType}, FacilityId {FacilityId}",
                                   patientId, insurancePlanId, examType, facilityId);

            var insurance = await _context.Insurances
                                          .Where(i => i.PatientId == patientId
                                                      && i.InsurancePlanId == insurancePlanId
                                                      && i.ExamType == examType
                                                      && i.FacilityId == facilityId)
                                          .FirstOrDefaultAsync();

            if (insurance == null)
            {
                _logger.LogWarning("Repository: No insurance found for PatientId {PatientId} with the given parameters.", patientId);
            }

            return insurance;
        }
    }
}
