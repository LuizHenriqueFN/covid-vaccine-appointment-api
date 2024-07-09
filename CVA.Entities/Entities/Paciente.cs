using ControleTarefas.Entidade.Entidades;

namespace CVA.Entity.Entities
{
    public class Paciente: IdEntidade<int>
    {
        public string DscNome { get; set; }

        public DateOnly DatNascimento { get; set; }

        public DateTime DatCriacao { get; set; }
    }
}
