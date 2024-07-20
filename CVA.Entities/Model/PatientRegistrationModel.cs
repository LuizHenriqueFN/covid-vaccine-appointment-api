using System.ComponentModel.DataAnnotations;

namespace CVA.Entity.Model
{
    public class PatientRegistrationModel
    {
        public string Name { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }
    }
}
