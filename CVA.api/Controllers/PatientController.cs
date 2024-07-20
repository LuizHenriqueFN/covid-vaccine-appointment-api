using CVA.Entity.DTOs;
using CVA.Entity.Filters;
using CVA.Entity.Model;
using CVA.Service.Interface.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CVA.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<PatientDTO> InsertPatient(PatientRegistrationModel newPatient)
        {
            return await _patientService.InsertPatient(newPatient);
        }

        [HttpPut("{id}")]
        public async Task<PatientDTO> UpdatePatient(PatientRegistrationModel patient, int id)
        {
            return await _patientService.UpdatePatient(patient, id);
        }

        [HttpDelete("{id}")]
        public async Task<PatientDTO> DeletePatient(int id)
        {
            return await _patientService.DeletePatient(id);
        }

        [HttpGet]
        public async Task<List<PatientDTO>> ListPatients()
        {
            return await _patientService.ListPatients(null);
        }

        [HttpGet("{id}")]
        public async Task<PatientDTO?> ListPatients(int id)
        {
            return await _patientService.GetPatientById(id);
        }
        
        [HttpPost("Filter")]
        public async Task<List<PatientDTO>> ListPatients(PatientFilter? patientFilter)
        {
            return await _patientService.ListPatients(patientFilter);
        }
    }
}
