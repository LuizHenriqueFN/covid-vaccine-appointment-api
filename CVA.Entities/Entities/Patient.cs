namespace CVA.Entity.Entities
{
    public class Patient: EntityId<int>
    {
        public string Name { get; set; } = string.Empty;

        public DateOnly BirthDate { get; set; }

        public DateTime CreationDate { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
