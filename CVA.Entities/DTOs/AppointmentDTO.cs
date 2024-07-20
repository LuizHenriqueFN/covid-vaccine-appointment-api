namespace CVA.Entity.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        public string StatusDescription { get; set; } = string.Empty;

        public PatientDTO Patient { get; set; } = new PatientDTO();
    }
}
