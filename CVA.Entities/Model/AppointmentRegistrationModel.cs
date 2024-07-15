namespace CVA.Entity.Model
{
    public class AppointmentRegistrationModel
    {
        public DateOnly AppointmentDate { get; set; }

        public TimeOnly AppointmentTime { get; set; }

        public string StatusDescription { get; set; } = string.Empty;

        public int PatientId { get; set; }
    }
}
