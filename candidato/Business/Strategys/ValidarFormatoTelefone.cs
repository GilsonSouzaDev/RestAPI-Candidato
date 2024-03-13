using candidatos.Models;
using System;
using System.Text.RegularExpressions;

namespace candidato.Business.Strategys
{
    public class ValidarFormatoTelefone : IStrategy
    {
        public string Processar(Candidato entidade)
        {
            string padrao = @"^\d{2}(?:-\d{4,5}-|\d{4,5})\d{4}$";

            foreach (Telefone telefone in entidade.Telefones)
            {
                // Verifique se o telefone corresponde ao padrão
                bool formatoCorreto = Regex.IsMatch(telefone.Numero, padrao);

                if (!formatoCorreto)
                {
                    return "Formato de telefone não aceito.";
                }      
                
            }

            return null;
        }
    }
}

