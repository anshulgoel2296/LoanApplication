using LoanApplicationAPI.DBModels;
using LoanApplicationAPI.RequestModels;

namespace LoanApplicationAPI.Contract
{
    public interface ILoanTypeService
    {
        Task<LoanType> CreateAsync(LoanTypeRequest request);
        Task<LoanType?> GetByIdAsync(int id);
        Task<List<LoanType>> GetAllAsync();
        Task<LoanType?> PatchAsync(int id, LoanTypeRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
