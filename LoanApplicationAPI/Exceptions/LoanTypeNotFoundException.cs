namespace LoanApplicationAPI.Exceptions
{
    public class LoanTypeNotFoundException : Exception
    {
        public LoanTypeNotFoundException(string msg) : base(msg) { }
    }
}
