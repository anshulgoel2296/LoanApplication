using Microsoft.VisualBasic;

namespace LoanApplicationAPI.Exceptions
{
    public class UserAlreadyExistsException: Exception
    {
        public UserAlreadyExistsException(string msg): base(msg) { }
    }
}
