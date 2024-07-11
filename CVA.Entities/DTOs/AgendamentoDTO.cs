namespace CVA.Entity.DTOs
{
    public class AgendamentoDTO
    {
        public DateOnly DatAgendamento { get; set; }

        public TimeOnly HorAgendamento { get; set; }

        public string DscStatus { get; set; } = string.Empty;
    }
}
