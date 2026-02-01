namespace LoanApplicationAPI.Util
{
    public class LoanApplicationConstants
    {
        public static string ERR_LOAN_APPLICATION_EXISTS = "Another Loan Application with same user and loan type exists already.";
        public static string ERR_LOAN_APPLICATION_NOT_FOUND = "No Loan Application Found.";
        public static string ERR_NO_LOAN_APPLICATION_EXISTS = "No Loan Application Exists with given id.";
        public static string ERR_STATUS_UPDATE_NOT_ALLOWED = "Status Change is not allowed for given status";
    }
}
