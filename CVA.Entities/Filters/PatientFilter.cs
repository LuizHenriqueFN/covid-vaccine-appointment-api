using System.ComponentModel.DataAnnotations;

namespace CVA.Entity.Filters
{
    public class PatientFilter
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}
