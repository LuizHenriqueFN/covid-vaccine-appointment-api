namespace CVA.Entity.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateOnly BirthDate { get; set; }

        public List<AppointmentDTO> AppointmentDTOs { get; set; } = new List<AppointmentDTO> ();
    }
}
