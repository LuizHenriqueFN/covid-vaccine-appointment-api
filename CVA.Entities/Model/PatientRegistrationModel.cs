namespace CVA.Entity.Model
{
    public class PatientRegistrationModel
    {
        public string Name { get; set; } = string.Empty;

        public DateOnly BirthDate { get; set; }
    }
}
