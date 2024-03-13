using candidatos.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace candidato.Business.Strategys
{
    public class ValidarCamposVaziosNulos : IStrategy
    {
        public string Processar(Candidato entidade)
        {
            if (string.IsNullOrEmpty(entidade.Nome) ||
               string.IsNullOrEmpty(entidade.Filiacao.NomeMae) ||
               string.IsNullOrEmpty(entidade.Endereco.Logradouro) ||
               string.IsNullOrEmpty(entidade.Endereco.Numero) ||
               string.IsNullOrEmpty(entidade.Endereco.Cep) ||
               string.IsNullOrEmpty(entidade.Endereco.Cidade.Nome) ||
               string.IsNullOrEmpty(entidade.Endereco.Cidade.Estado.Nome) ||
               string.IsNullOrEmpty(entidade.Endereco.Cidade.Estado.Sigla) 
              )
            {
                return "Existem campos obrigatorios não preenchidos, preecha todos os campos obrigatorios";
            }

                return null;
        }
       
    }
}
