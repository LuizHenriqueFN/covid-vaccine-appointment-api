using CVA.Entity.DTOs;
using CVA.Entity.Entities;

namespace CVA.Repository.Interface.IRepositories
{
    public interface IAppoitmentRepository : IBaseRepository<Appointment>
    {
        Task<AppointmentDTO?> GetAppointmentById(int appointmentId, bool asNoTracking = true);

        Task<List<AppointmentDTO>> GetAllAppointments(bool asNoTracking = true);

        Task<List<AppointmentDTO>> GetAppointmentsByPatientName(string patientName, bool asNoTracking = true);

        Task<List<AppointmentDTO>> GetAppointmentsByPatientID(int patientId, bool asNoTracking = true);

        Task<List<AppointmentDTO>> GetAppointmentsByDate(DateOnly appointmentDate, bool asNoTracking = true);

        Task<List<AppointmentDTO>> GetAppointmentsByTime(TimeOnly appointmentTime, bool asNoTracking = true);

        Task<List<AppointmentDTO>> GetAppointmentsByStatus(string status, bool asNoTracking = true);
    }
}
