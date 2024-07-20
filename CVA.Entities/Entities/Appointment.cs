namespace CVA.Entity.Entities
{
    public class Appointment: EntityId<int>
    {
        public DateTime AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        public string StatusDescription { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; }

        public Patient Patient { get; set; } = new Patient();
    }
}
