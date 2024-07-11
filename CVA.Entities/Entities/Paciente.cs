using ControleTarefas.Entidade.Entidades;

namespace CVA.Entity.Entities
{
    public class Paciente: IdEntidade<int>
    {
        public string DscNome { get; set; } = string.Empty;

        public DateOnly DatNascimento { get; set; }

        public DateTime DatCriacao { get; set; }

        public List<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
