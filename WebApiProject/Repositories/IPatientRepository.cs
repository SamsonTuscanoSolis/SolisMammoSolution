using WebApiProject.Models;

namespace WebApiProject.Repositories
{
    public interface IPatientRepository
    {
        //Task<Patient?> GetPatientByIdAsync(int patientId);
        Task<Patient> GetPatientByIdAsync(int patientId, string mrn = null, DateTime? dob = null);
        Task<List<Patient>> SearchAsync(string? name, int? age, string? disease);
        //Task<List<Appointment>> GetAppointmentsAsync(int patientId);
        Task<IEnumerable<Appointment>> GetAppointmentsAsync(int patientId, string status, DateTime? dateFrom, DateTime? dateTo);
        //Task<List<ExamResult>> GetResultsAsync(int patientId);
        Task<IEnumerable<ExamResult>> GetResultsAsync(int patientId, int? examId, DateTime? dateFrom, DateTime? dateTo);
        //Task<List<Communication>> GetCommunicationsAsync(int patientId);
        Task<List<Communication>> GetCommunicationsAsync(int patientId, string channel, DateTime? dateFrom, DateTime? dateTo, string campaignId);
        Task<InsuranceStatus?> GetInsuranceStatusAsync(int patientId);
    }
}
