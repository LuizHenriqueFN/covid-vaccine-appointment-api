namespace CVA.Entity.Filters
{
    public class AppointmentFilter
    {
        public int? Id { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public TimeSpan? AppointmentTime { get; set; }

        public string? StatusDescription { get; set; }

        public PatientFilter? PatientFilter { get; set; }

    }
}
