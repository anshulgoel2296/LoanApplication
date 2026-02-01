using Microsoft.VisualBasic;

namespace LoanApplicationAPI.Exceptions
{
    public class ApplicationStatusAlreadyExistsException : Exception
    {
        public ApplicationStatusAlreadyExistsException(string msg) : base(msg) { }
    }
}
