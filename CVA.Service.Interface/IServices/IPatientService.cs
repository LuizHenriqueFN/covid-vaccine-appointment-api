using CVA.Entity.DTOs;
using CVA.Entity.Filters;
using CVA.Entity.Model;

namespace CVA.Service.Interface.IServices
{
    public interface IPatientService
    {
        Task<PatientDTO> InsertPatient(PatientRegistrationModel newPatient);

        Task<PatientDTO> UpdatePatient(PatientRegistrationModel patient, int id);

        Task<PatientDTO> DeletePatient(int id);

        Task<List<PatientDTO>> ListPatients(PatientFilter? patientFilter);

        Task<PatientDTO?> GetPatientById(int id);
    }
}
