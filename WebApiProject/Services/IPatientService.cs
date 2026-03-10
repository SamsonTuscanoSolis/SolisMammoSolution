using WebApiProject.DTOs;
using WebApiProject.Models;

namespace WebApiProject.Services
{
    public interface IPatientService
    {
        //Task<Patient?> GetPatientByIdAsync(int patientId);
        Task<PatientResponseDto> GetPatientByIdAsync(int patientId, string mrn = null, DateTime? dob = null);
        Task<List<Patient>> SearchPatientsAsync(string? name, int? age, string? disease);
        //Task<List<Appointment>> GetAppointmentsAsync(int patientId);
        Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(int patientId, string status, DateTime? dateFrom, DateTime? dateTo);
        //Task<List<ExamResult>> GetResultsAsync(int patientId);
        Task<IEnumerable<ExamResultDto>> GetResultsAsync(int patientId, int? examId, DateTime? dateFrom, DateTime? dateTo);
        //Task<List<Communication>> GetCommunicationsAsync(int patientId);
        Task<IEnumerable<CommunicationDto>> GetCommunicationsAsync(int patientId, string channel, DateTime? dateFrom, DateTime? dateTo, string campaignId);
        //Task<InsuranceStatus?> GetInsuranceStatusAsync(int patientId);
        Task<InsuranceVerificationDto> GetInsurancesAsync(int patientId, string insurancePlanId, string examType, int facilityId);
    }
}
