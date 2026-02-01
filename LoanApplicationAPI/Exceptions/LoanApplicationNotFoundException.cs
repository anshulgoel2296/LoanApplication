namespace LoanApplicationAPI.Exceptions
{
    public class LoanApplicationNotFoundException : Exception
    {
        public LoanApplicationNotFoundException(string msg) : base(msg) { }
    }
}
