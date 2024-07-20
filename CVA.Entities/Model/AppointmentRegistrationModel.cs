namespace CVA.Entity.Model
{
    public class AppointmentRegistrationModel
    {
        public string AppointmentDate { get; set; } = string.Empty;

        public string AppointmentTime { get; set; }  = string.Empty;

        public string StatusDescription { get; set; } = string.Empty;

        public int PatientId { get; set; }
    }
}
