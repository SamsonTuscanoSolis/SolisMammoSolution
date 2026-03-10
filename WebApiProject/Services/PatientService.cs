using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiProject.DTOs;
using WebApiProject.Models;
using WebApiProject.Repositories;

namespace WebApiProject.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientService> _logger;

        public PatientService(IPatientRepository repository, IMapper mapper, ILogger<PatientService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        //public async Task<Patient> GetPatientByIdAsync(int id)
        //{
        //    _logger.LogInformation("Fetching patient with ID: {PatientId}", id);

        //    var patient = await _repository.GetPatientByIdAsync(id);

        //    if (patient == null)
        //    {
        //        _logger.LogWarning("Patient not found for ID: {PatientId}", id);
        //    }
        //    else
        //    {
        //        _logger.LogInformation("Patient retrieved successfully for ID: {PatientId}", id);
        //    }

        //    return patient;
        //}

        public async Task<PatientResponseDto> GetPatientByIdAsync(int patientId, string mrn = null, DateTime? dob = null)
        {
            _logger.LogInformation("Service: Getting patient {PatientId}", patientId);

            var patient = await _repository.GetPatientByIdAsync(patientId, mrn, dob);

            if (patient == null)
            {
                _logger.LogWarning("Service: Patient not found or filter mismatch for {PatientId}", patientId);
                return null;
            }

            var patientDto = _mapper.Map<PatientResponseDto>(patient);

            return patientDto;
        }

        public Task<List<Patient>> SearchPatientsAsync(string? name, int? age, string? disease) =>
            _repository.SearchAsync(name, age, disease);

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(int patientId, string status, DateTime? dateFrom, DateTime? dateTo)
        {
            //_logger.LogInformation("Service fetching appointments for PatientId: {PatientId}", patientId);

            //var appointments = await _repository.GetAppointmentsAsync(patientId, status, dateFrom, dateTo);

            ////return appointments.Select(a => new AppointmentDto
            ////{
            ////    AppointmentId = a.Id,
            ////    AppointmentDate = a.AppointmentDate,
            ////    Status = a.Status,
            ////    DoctorName = a.DoctorName,
            ////    Department = a.Department,
            ////    Location = a.Location
            ////});

            //return appointments.Select(a => new AppointmentDto
            //{
            //    AppointmentId = a.Id,
            //    AppointmentDateTime = a.AppointmentDateTime,
            //    Facility = a.Facility,
            //    Modality = a.Modality,
            //    ExamType = a.ExamType,
            //    Status = a.Status,
            //    ReferringPhysician = a.ReferringPhysician,
            //    OrderInfo = a.OrderInfo
            //});

            _logger.LogInformation("Service: Fetching appointments for PatientId {PatientId}", patientId);

            var appointments = await _repository.GetAppointmentsAsync(patientId, status, dateFrom, dateTo);

            if (appointments == null || !appointments.Any())
            {
                _logger.LogWarning("Service: No appointments found for PatientId {PatientId}", patientId);
                return Enumerable.Empty<AppointmentDto>();
            }

            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);

            return appointmentDtos;
        }
        //public Task<List<Appointment>> GetAppointmentsAsync(int patientId) =>
        //    _repository.GetAppointmentsAsync(patientId);

        //public Task<List<ExamResult>> GetResultsAsync(int patientId) =>
        //    _repository.GetResultsAsync(patientId);

        public async Task<IEnumerable<ExamResultDto>> GetResultsAsync(int patientId, int? examId, DateTime? dateFrom, DateTime? dateTo)
        {
            _logger.LogInformation("Service retrieving results for PatientId: {PatientId}", patientId);

            var results = await _repository.GetResultsAsync(patientId, examId, dateFrom, dateTo);

            //return results.Select(r => new ExamResultDto
            //{
            //    ExamId = r.Id,
            //    ExamType = r.ExamType,
            //    ExamDate = r.ExamDate,
            //    ResultStatus = r.ResultStatus,
            //    ReportAvailable = r.ReportAvailable,
            //    ResultDate = r.ResultDate
            //});
            return _mapper.Map<IEnumerable<ExamResultDto>>(results);
        }

        // public Task<List<Communication>> GetCommunicationsAsync(int patientId) =>            _repository.GetCommunicationsAsync(patientId);

        public async Task<IEnumerable<CommunicationDto>> GetCommunicationsAsync(int patientId, string channel, DateTime? dateFrom, DateTime? dateTo, string campaignId)
        {
            _logger.LogInformation("Service: Getting communications for PatientId {PatientId}", patientId);

            var communications = await _repository.GetCommunicationsAsync(
                                    patientId, channel, dateFrom, dateTo, campaignId);

            if (communications == null || !communications.Any())
            {
                _logger.LogWarning("Service: No communications found for PatientId {PatientId}", patientId);
                return Enumerable.Empty<CommunicationDto>();
            }

            var result = _mapper.Map<IEnumerable<CommunicationDto>>(communications);

            _logger.LogInformation("Service: Returning {Count} communications", result.Count());

            return result;
        }

        public Task<InsuranceStatus?> GetInsuranceStatusAsync(int patientId) =>
            _repository.GetInsuranceStatusAsync(patientId);
    }
}
