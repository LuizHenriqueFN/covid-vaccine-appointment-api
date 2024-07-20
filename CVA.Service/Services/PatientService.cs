using CVA.Entity.DTOs;
using CVA.Entity.Entities;
using CVA.Entity.Filters;
using CVA.Entity.Model;
using CVA.Repository.Interface.IRepositories;
using CVA.Service.Interface.IServices;
using CVA.Utils.Exceptions;
using CVA.Utils.Messages;
using log4net;

namespace CVA.Service.Services
{
    public class PatientService : IPatientService
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(PatientService));

        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDTO> DeletePatient(int id)
        {
            var patient = await _patientRepository.GetPatientById(id);

            if(patient == null)
            {
                _log.InfoFormat(BusinessMessages.RecordNotFound, id);
                throw new ServiceException(string.Format(BusinessMessages.RecordNotFound, id));
            }

            await _patientRepository.Delete(patient);
            _log.InfoFormat(BusinessMessages.OperationSuccessful, "Delete");

            return DTO(patient);
        }

        public async Task<PatientDTO> InsertPatient(PatientRegistrationModel newPatient)
        {
            var patient = await _patientRepository.GetPatientByFilter(new PatientFilter { Name = newPatient.Name, BirthDate = newPatient.BirthDate });
            if (patient.Count > 0)
            {
                _log.InfoFormat(BusinessMessages.ExistingRecord, newPatient.Name);
                throw new ServiceException(string.Format(BusinessMessages.ExistingRecord, newPatient.Name));
            }

            Patient savedPatient = new Patient
            {
                Name = newPatient.Name,
                BirthDate = newPatient.BirthDate,
                CreationDate = DateTime.Now
            };

            savedPatient = await _patientRepository.Insert(savedPatient);

            _log.InfoFormat(BusinessMessages.OperationSuccessful, "Insert");

            return DTO(savedPatient);
        }

        public Task<List<PatientDTO>> ListPatients(PatientFilter? patientFilter)
        {
            if (patientFilter == null)
                return _patientRepository.GetAllPatients();

            return _patientRepository.GetPatientByFilter(patientFilter);
        }
        
        public Task<PatientDTO?> GetPatientById(int id)
        {
            if (id <= 0)
            {
                _log.InfoFormat(BusinessMessages.RecordNotFound, "Id:" + id);
                throw new ServiceException(string.Format(BusinessMessages.RecordNotFound, "Id:" + id));
            }

            return _patientRepository.GetPatientDTOById(id);
        }

        public async Task<PatientDTO> UpdatePatient(PatientRegistrationModel newPatient, int id)
        {
            var patient = await _patientRepository.GetPatientById(id, false);
            if (patient == null)
            {
                _log.InfoFormat(BusinessMessages.RecordNotFound, "Id:" + id);
                throw new ServiceException(string.Format(BusinessMessages.RecordNotFound, "Id:" + id));
            }

            patient.Name = newPatient.Name;
            patient.BirthDate = newPatient.BirthDate;
             await _patientRepository.Update(patient);

            _log.InfoFormat(BusinessMessages.OperationSuccessful, "Update");

            return DTO(patient);
        }

        private static PatientDTO DTO(Patient patient)
        {
            return new PatientDTO // TODO: Verificar se pode fazer isso
            {
                Id = patient.Id,
                Name = patient.Name,
                BirthDate = patient.BirthDate,
            };
        }
    }
}
