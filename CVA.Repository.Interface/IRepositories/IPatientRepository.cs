using CVA.Entity.DTOs;
using CVA.Entity.Entities;
using CVA.Entity.Filters;

namespace CVA.Repository.Interface.IRepositories
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<Patient?> GetPatientById(int patientId, bool asNoTracking = true);

        Task<List<PatientDTO>> GetAllPatients(bool asNoTracking = true);

        Task<List<PatientDTO>> GetPatientByFilter(PatientFilter filter, bool asNoTracking = true);

        Task<PatientDTO?> GetPatientDTOById(int patientId, bool asNoTracking = true);
    }
}
