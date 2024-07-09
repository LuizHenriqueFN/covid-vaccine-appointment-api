using ControleTarefas.Entidade.Entidades;

namespace CVA.Entity.Entities
{
    public class Agendamento: IdEntidade<int>
    {
        public DateOnly DatAgendamento { get; set; }

        public TimeOnly HorAgendamento { get; set; }

        public string DscStatus { get; set; }

        public DateTime DatCriacao { get; set; }

        public Paciente Paciente { get; set; }
    }
}
