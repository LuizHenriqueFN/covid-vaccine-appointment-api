using ControleTarefas.Repositorio.Repositorios;
using CVA.Entity.DTOs;
using CVA.Entity.Entities;
using CVA.Entity.Filters;
using CVA.Repository.Interface.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CVA.Repository.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(Context context) : base(context) { }

        public Task<List<AppointmentDTO>> GetAllAppointments(bool asNoTracking = true)
        {
            var query = _context.Appointment
                        .Include(a => a.Patient)
                        .Select(a => new AppointmentDTO
                        {
                            Id = a.Id,
                            AppointmentDate = a.AppointmentDate,
                            AppointmentTime = a.AppointmentTime,
                            StatusDescription = a.StatusDescription,
                            Patient = new PatientDTO
                            {
                                Id = a.Patient.Id,
                                Name = a.Patient.Name,
                                BirthDate = a.Patient.BirthDate
                            }
                        });

            if (asNoTracking)
                query = query.AsNoTracking();

            return query.ToListAsync();
        }

        public Task<Appointment?> GetAppointmentById(int appointmentId, bool asNoTracking = true)
        {
            var query = EntitySet.AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return query.FirstOrDefaultAsync(a => a.Id == appointmentId);
        }

        public Task<List<AppointmentDTO>> GetAppointmentsByFilter(AppointmentFilter filter, bool asNoTracking = true)
        {
            var query = _context.Appointment.AsQueryable();

            if (filter.AppointmentDate.HasValue)
                query = query.Where(a => a.AppointmentDate == filter.AppointmentDate);

            if (filter.AppointmentTime.HasValue)
                query = query.Where(a => a.AppointmentTime == filter.AppointmentTime);

            if (!string.IsNullOrEmpty(filter.StatusDescription))
                query = query.Where(a => a.StatusDescription.ToLower() == filter.StatusDescription.ToLower());

            if (filter.PatientFilter != null)
            {
                if (filter.PatientFilter.Id.HasValue)
                    query = query.Where(a => a.Patient.Id == filter.PatientFilter.Id);

                if (!string.IsNullOrEmpty(filter.PatientFilter.Name))
                    query = query.Where(a => a.Patient.Name.ToLower() == filter.PatientFilter.Name.ToLower());

                if (filter.PatientFilter.BirthDate.HasValue)
                    query = query.Where(a => a.Patient.BirthDate == filter.PatientFilter.BirthDate);
            }

            var appointmentDTOQuery = query.Select(a => new AppointmentDTO
            {
                Id = a.Id,
                AppointmentDate = a.AppointmentDate,
                AppointmentTime = a.AppointmentTime,
                StatusDescription = a.StatusDescription,
                Patient = new PatientDTO
                {
                    Id = a.Patient.Id,
                    Name = a.Patient.Name,
                    BirthDate = a.Patient.BirthDate
                }
            });

            if (asNoTracking)
                appointmentDTOQuery = appointmentDTOQuery.AsNoTracking();

            return appointmentDTOQuery.ToListAsync();
        }
    }
}
