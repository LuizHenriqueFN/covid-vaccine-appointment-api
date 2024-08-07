﻿using ControleTarefas.Repositorio.Repositorios;
using CVA.Entity.DTOs;
using CVA.Entity.Entities;
using CVA.Entity.Filters;
using CVA.Repository.Interface.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CVA.Repository.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(Context context) : base(context) { }

        public Task<Patient?> GetPatientById(int patientId, bool asNoTracking = true)
        {
            var query = EntitySet.AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return query.FirstOrDefaultAsync(p => p.Id == patientId);
        }

        public Task<PatientDTO?> GetPatientDTOById(int patientId, bool asNoTracking = true)
        {
            var query = EntitySet.AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return query
                .Where(p => p.Id == patientId)
                .Select(p => new PatientDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    BirthDate = p.BirthDate,
                })
                .FirstOrDefaultAsync();
        }


        public Task<List<PatientDTO>> GetAllPatients(bool asNoTracking = true)
        {
            var query = _context.Patient
                        .Select(p => new PatientDTO
                        {
                            Id = p.Id,
                            Name = p.Name,
                            BirthDate = p.BirthDate,
                            AppointmentDTOs = p.Appointments.Select(a => new AppointmentDTO
                            {
                                Id = a.Id,
                                AppointmentDate = a.AppointmentDate,
                                AppointmentTime = a.AppointmentTime,
                                StatusDescription = a.StatusDescription
                            }).ToList()
                        });

            if (asNoTracking)
                query = query.AsNoTracking();

            return query.ToListAsync();
        }

        public Task<List<PatientDTO>> GetPatientByFilter(PatientFilter filter, bool asNoTracking = true)
        {
            var query = _context.Patient.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower()));

            if (filter.BirthDate.HasValue)
                query = query.Where(p => p.BirthDate.Equals(filter.BirthDate));

            var patientDTOQuery = query.Select(p => new PatientDTO
            {
                Id = p.Id,
                Name = p.Name,
                BirthDate = p.BirthDate,
                AppointmentDTOs = p.Appointments.Select(a => new AppointmentDTO
                {
                    AppointmentDate = a.AppointmentDate,
                    AppointmentTime = a.AppointmentTime,
                    StatusDescription = a.StatusDescription
                }).ToList()
            });

            if (asNoTracking)
                patientDTOQuery = patientDTOQuery.AsNoTracking();

            return patientDTOQuery.ToListAsync();
        }
    }
}
