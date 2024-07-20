using CVA.Entity.DTOs;
using CVA.Entity.Filters;
using CVA.Entity.Model;
using CVA.Service.Interface.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CVA.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<AppointmentDTO> InsertAppointment([FromBody] AppointmentRegistrationModel newAppointment)
        {
            return await _appointmentService.InsertAppointment(newAppointment);
        }

        [HttpPut("{id}")]
        public async Task<AppointmentDTO> UpdateAppointment([FromBody] AppointmentRegistrationModel appointment, int id)
        {
            return await _appointmentService.UpdateAppointment(appointment, id);
        }

        [HttpDelete("{id}")]
        public async Task<AppointmentDTO> DeleteAppointment(int id)
        {
            return await _appointmentService.DeleteAppointment(id);
        }

        [HttpGet]
        public async Task<List<AppointmentDTO>> ListAppointments()
        {
            return await _appointmentService.ListAppointments(null);
        }
        
        [HttpPost("limit")]
        public async Task<AppointmentLimit> GetAppointmentLimit([FromBody] AppointmentLimit appointmentLimit)
        {
            return await _appointmentService.GetAppointmentLimit(appointmentLimit);
        }
        
        [HttpPost("Filter")]
        public async Task<List<AppointmentDTO>> ListAppointments([FromBody] AppointmentFilter appointmentFilter)
        {
            return await _appointmentService.ListAppointments(appointmentFilter);
        }
    }
}
