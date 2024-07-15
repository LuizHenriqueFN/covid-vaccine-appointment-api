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
    public class AppointmentService : IAppointmentService
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(PatientService));

        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository, IPatientRepository patientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
        }

        public async Task<AppointmentDTO> DeleteAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(id);

            if (appointment == null)
            {
                _log.InfoFormat(BusinessMessages.RecordNotFound, id);
                throw new ServiceException(string.Format(BusinessMessages.RecordNotFound, id));
            }

            await _appointmentRepository.Delete(appointment);
            _log.InfoFormat(BusinessMessages.OperationSuccessful, "Delete");

            return DTO(appointment);
        }

        public async Task<AppointmentDTO> InsertAppointment(AppointmentRegistrationModel newAppointment)
        {
            var patient = await _patientRepository.GetPatientById(newAppointment.PatientId);
            if (patient == null)
            {
                _log.InfoFormat(BusinessMessages.RecordNotFound, newAppointment.PatientId);
                throw new ServiceException(string.Format(BusinessMessages.RecordNotFound, newAppointment.PatientId));
            }

            var appointmentFilter = new AppointmentFilter
            {
                AppointmentDate = newAppointment.AppointmentDate,
                AppointmentTime = newAppointment.AppointmentTime,
                StatusDescription = newAppointment.StatusDescription,
                PatientFilter = new PatientFilter
                {
                    Id = newAppointment.PatientId
                }
            };

            var appointment = await _appointmentRepository.GetAppointmentsByFilter(appointmentFilter);
            if (appointment != null)
            {
                _log.InfoFormat(BusinessMessages.ExistingRecord, newAppointment.AppointmentTime);
                throw new ServiceException(string.Format(BusinessMessages.ExistingRecord, newAppointment.AppointmentTime));
            }

            var savedAppointment = new Appointment
            {
                AppointmentDate = newAppointment.AppointmentDate,
                AppointmentTime = newAppointment.AppointmentTime,
                StatusDescription = newAppointment.StatusDescription,
                Patient = patient
            };

            savedAppointment = await _appointmentRepository.Insert(savedAppointment);

            _log.InfoFormat(BusinessMessages.OperationSuccessful, "Insert");

            return DTO(savedAppointment);
        }

        public Task<List<AppointmentDTO>> ListAppointments(AppointmentFilter appointmentFilter)
        {
            if (appointmentFilter == null)
                return _appointmentRepository.GetAllAppointments();

            return _appointmentRepository.GetAppointmentsByFilter(appointmentFilter);
        }

        public async Task<AppointmentDTO> UpdateAppointment(AppointmentRegistrationModel newAppointment, int id)
        {
            var patient = await _patientRepository.GetPatientById(newAppointment.PatientId);
            if (patient == null)
            {
                _log.InfoFormat(BusinessMessages.RecordNotFound, newAppointment.PatientId);
                throw new ServiceException(string.Format(BusinessMessages.RecordNotFound, newAppointment.PatientId));
            }

            var appointment = await _appointmentRepository.GetAppointmentById(id, false);
            if (appointment == null)
            {
                _log.InfoFormat(BusinessMessages.RecordNotFound, newAppointment.AppointmentTime);
                throw new ServiceException(string.Format(BusinessMessages.RecordNotFound, newAppointment.AppointmentTime));
            }

            appointment.AppointmentDate = newAppointment.AppointmentDate;
            appointment.AppointmentTime = newAppointment.AppointmentTime;
            appointment.StatusDescription = newAppointment.StatusDescription;
            appointment.Patient = patient;

            await _appointmentRepository.Update(appointment);

            _log.InfoFormat(BusinessMessages.OperationSuccessful, "Update");

            return DTO(appointment);
        }

        private static AppointmentDTO DTO(Appointment appointment)
        {
            return new AppointmentDTO
            {
                Id = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTime = appointment.AppointmentTime,
                StatusDescription = appointment.StatusDescription,
                Patient = new PatientDTO
                {
                    Id = appointment.Patient.Id,
                    Name = appointment.Patient.Name,
                    BirthDate = appointment.Patient.BirthDate,
                }
            };
        }
    }
}
