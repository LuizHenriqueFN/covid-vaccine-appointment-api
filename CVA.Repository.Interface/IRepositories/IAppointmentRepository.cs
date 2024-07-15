using CVA.Entity.DTOs;
using CVA.Entity.Entities;
using CVA.Entity.Filters;

namespace CVA.Repository.Interface.IRepositories
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        Task<Appointment?> GetAppointmentById(int appointmentId, bool asNoTracking = true);

        Task<List<AppointmentDTO>> GetAllAppointments(bool asNoTracking = true);

        Task<List<AppointmentDTO>> GetAppointmentsByFilter(AppointmentFilter appointmentFilter, bool asNoTracking = true);
    }
}
