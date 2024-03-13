namespace candidato.Business.Exception
{
    public class ValidacaoException: IOException
    {
        public ValidacaoException(string message) : base(message)
        {
        }

        public ValidacaoException(string message, RankException innerException) : base(message, innerException)
        {
            
        }

    }
}
