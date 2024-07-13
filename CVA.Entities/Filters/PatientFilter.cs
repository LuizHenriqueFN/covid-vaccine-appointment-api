namespace CVA.Entity.Filters
{
    public class PatientFilter
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        public DateOnly? BirthDate { get; set; }
    }
}
