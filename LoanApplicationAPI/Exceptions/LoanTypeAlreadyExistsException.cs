using Microsoft.VisualBasic;

namespace LoanApplicationAPI.Exceptions
{
    public class LoanTypeAlreadyExistsException: Exception
    {
        public LoanTypeAlreadyExistsException(string msg): base(msg) { }
    }
}
