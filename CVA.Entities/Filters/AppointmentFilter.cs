namespace CVA.Entity.Filters
{
    public class AppointmentFilter
    {
        public int? Id { get; set; }

        public DateOnly? AppointmentDate { get; set; }

        public TimeOnly? AppointmentTime { get; set; }

        public string? StatusDescription { get; set; }

        public PatientFilter? PatientFilter { get; set; }

    }
}
