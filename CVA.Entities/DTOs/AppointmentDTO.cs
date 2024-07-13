﻿namespace CVA.Entity.DTOs
{
    public class AppointmentDTO
    {
        public DateOnly AppointmentDate { get; set; }

        public TimeOnly AppointmentTime { get; set; }

        public string StatusDescription { get; set; } = string.Empty;

        public PatientDTO Patient { get; set; } = new PatientDTO();
    }
}
