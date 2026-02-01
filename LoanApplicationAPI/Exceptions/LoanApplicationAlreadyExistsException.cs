using Microsoft.VisualBasic;

namespace LoanApplicationAPI.Exceptions
{
    public class LoanApplicationAlreadyExistsException: Exception
    {
        public LoanApplicationAlreadyExistsException(string msg): base(msg) { }
    }
}
