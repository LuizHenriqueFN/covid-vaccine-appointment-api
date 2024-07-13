namespace CVA.Entity.Entities
{
    public class Appointment: EntityId<int>
    {
        public DateOnly AppointmentDate { get; set; }

        public TimeOnly AppointmentTime { get; set; }

        public string StatusDescription { get; set; } = string.Empty;

        public DateTime CreationDate { get; set; }

        public Patient Patient { get; set; } = new Patient();
    }
}
