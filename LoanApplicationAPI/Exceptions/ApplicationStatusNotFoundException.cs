using Microsoft.VisualBasic;

namespace LoanApplicationAPI.Exceptions
{
    public class ApplicationStatusNotFoundException : Exception
    {
        public ApplicationStatusNotFoundException(string msg) : base(msg) { }
    }
}
