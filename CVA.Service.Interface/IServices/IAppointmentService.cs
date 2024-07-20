using CVA.Entity.DTOs;
using CVA.Entity.Filters;
using CVA.Entity.Model;

namespace CVA.Service.Interface.IServices
{
    public interface IAppointmentService
    {
        Task<AppointmentDTO> InsertAppointment(AppointmentRegistrationModel newAppointment);

        Task<AppointmentDTO> UpdateAppointment(AppointmentRegistrationModel appointment, int id);

        Task<AppointmentDTO> DeleteAppointment(int id);

        Task<List<AppointmentDTO>> ListAppointments(AppointmentFilter appointmentFilter);

        Task<AppointmentLimit> GetAppointmentLimit(AppointmentLimit appointmentLimit);
    }
}
