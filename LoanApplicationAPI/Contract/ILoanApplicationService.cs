using LoanApplicationAPI.DBModels;
using LoanApplicationAPI.RequestModels;

namespace LoanApplicationAPI.Contract
{
    public interface ILoanApplicationService
    {
        Task<LoanApplication> CreateAsync(LoanApplicationRequest request);
        Task<LoanApplication?> GetByIdAsync(int id);
        Task<List<LoanApplication>> GetAllAsync();
        Task<LoanApplication?> PatchAsync(int id, LoanApplicationRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
