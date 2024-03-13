using candidatos.Models;

namespace candidato.Business
{
    public interface IStrategy
    {
        public String Processar(Candidato entidade); 

    }
}
