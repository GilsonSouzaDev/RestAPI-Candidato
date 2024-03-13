using candidatos.Models;

namespace candidato.Business.Strategys
{
    public class ValidarTelefone : IStrategy
    {
        public string Processar(Candidato entidade)
        {
            if (entidade.Telefones.Count == 0)
            {
                return "É necessário adicionar pelo menos um telefone ao candidato.";
            }

            if (entidade.Telefones.Count > 3)
            {
                return "Não é permitido adicionar mais de 3 telefones ao candidato.";
            }

         

            return null;

        }
    }
}
