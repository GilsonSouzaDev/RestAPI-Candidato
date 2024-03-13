using candidatos.Models;

namespace candidato.Business.Strategys
{
    public class ValidarCurso : IStrategy
    {
        public string Processar(Candidato entidade)
        {
            if (entidade.Cursos.Count == 0)
            {
                return "É necessário adicionar pelo menos um curso ao candidato.";
            }

            if (entidade.Cursos.Count > 3)
            {
                return "Não é permitido adicionar mais de 3 cursos ao candidato.";
            }

            return null; 
           
        }
    }
}
