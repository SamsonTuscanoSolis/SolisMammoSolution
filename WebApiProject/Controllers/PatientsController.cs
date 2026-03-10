using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DTOs;
using WebApiProject.Services;

namespace WebApiProject.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientsController> _logger;

        public PatientsController(IPatientService service, IMapper mapper, ILogger<PatientsController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        //[HttpGet("{patientId}")]
        //public async Task<IActionResult> GetPatient(int patientId)
        //{
        //    var patient = await _service.GetPatientByIdAsync(patientId);
        //    if (patient == null) return NotFound("Patient not found");
        //    return Ok(patient);
        //}

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatient(int patientId, [FromQuery] string mrn = null, [FromQuery] DateTime? dob = null)
        {
            //_logger.LogInformation("API request received for PatientId: {PatientId}", patientId);

            //var patient = await _service.GetPatientByIdAsync(patientId);

            //if (patient == null)
            //{
            //    _logger.LogWarning("Patient not found for PatientId: {PatientId}", patientId);
            //    return NotFound("Patient not found");
            //}

            //if (!string.IsNullOrEmpty(mrn) && patient.Mrn != mrn)
            //{
            //    _logger.LogWarning("MRN mismatch for PatientId: {PatientId}", patientId);
            //    return BadRequest("MRN mismatch");
            //}

            //if (dob.HasValue && patient.Dob != dob.Value.Date)
            //{
            //    _logger.LogWarning("DOB mismatch for PatientId: {PatientId}", patientId);
            //    return BadRequest("DOB mismatch");
            //}

            //var response = _mapper.Map<PatientResponseDto>(patient);

            //_logger.LogInformation("Patient data returned successfully for PatientId: {PatientId}", patientId);

            //return Ok(response);

            _logger.LogInformation("API request received for PatientId: {PatientId}", patientId);

            var patient = await _service.GetPatientByIdAsync(patientId, mrn, dob);

            if (patient == null)
            {
                _logger.LogWarning("Patient not found for PatientId: {PatientId}", patientId);
                return NotFound("Patient not found");
            }

            _logger.LogInformation("Patient data returned successfully for PatientId: {PatientId}", patientId);

            return Ok(patient);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPatients([FromQuery] string? name, [FromQuery] int? age, [FromQuery] string? disease)
        {
            var results = await _service.SearchPatientsAsync(name, age, disease);
            if (!results.Any()) return NotFound("No patients found matching the search criteria");
            return Ok(results);
        }

        //[HttpGet("{patientId}/appointments")]
        //public async Task<IActionResult> GetPatientAppointments(int patientId)
        //{
        //    var appointments = await _service.GetAppointmentsAsync(patientId);
        //    return Ok(appointments);
        //}

        [HttpGet("{patientId}/appointments")]
        public async Task<IActionResult> GetPatientAppointments(int patientId, [FromQuery] string status, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            _logger.LogInformation("Fetching appointments for PatientId: {PatientId}", patientId);

            var appointments = await _service.GetAppointmentsAsync(patientId, status, dateFrom, dateTo);

            if (appointments == null || !appointments.Any())
            {
                _logger.LogWarning("No appointments found for PatientId: {PatientId}", patientId);
                return NotFound("No appointments found");
            }

            _logger.LogInformation("Appointments retrieved for PatientId: {PatientId}", patientId);

            return Ok(appointments);
        }

        //[HttpGet("{patientId}/results")]
        //public async Task<IActionResult> GetExamResults(int patientId)
        //{
        //    var results = await _service.GetResultsAsync(patientId);
        //    return Ok(results);
        //}

        [HttpGet("{patientId}/results")]
        public async Task<IActionResult> GetExamResults(int patientId, [FromQuery] int? examId, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo)
        {
            _logger.LogInformation("API request for exam results. PatientId: {PatientId}", patientId);

            var results = await _service.GetResultsAsync(patientId, examId, dateFrom, dateTo);

            if (results == null || !results.Any())
            {
                _logger.LogWarning("No exam results found for PatientId: {PatientId}", patientId);
                return NotFound("No results found");
            }

            return Ok(results);
        }

        //[HttpGet("{patientId}/communications")]
        //public async Task<IActionResult> GetPatientCommunications(int patientId)
        //{
        //    var communications = await _service.GetCommunicationsAsync(patientId);
        //    return Ok(communications);
        //}

        [HttpGet("{patientId}/communications")]
        public async Task<IActionResult> GetPatientCommunications(int patientId, [FromQuery] string channel, [FromQuery] DateTime? dateFrom, [FromQuery] DateTime? dateTo, [FromQuery] string campaignId)
        {
            var communications = await _service.GetCommunicationsAsync(patientId, channel, dateFrom, dateTo, campaignId);

            return Ok(communications);
        }

        [HttpGet("{patientId}/insurance/verify")]
        public async Task<IActionResult> VerifyInsurance(int patientId)
        {
            var insurance = await _service.GetInsuranceStatusAsync(patientId);
            if (insurance == null) return NotFound("Insurance information not found");
            return Ok(insurance);
        }

    }
}
