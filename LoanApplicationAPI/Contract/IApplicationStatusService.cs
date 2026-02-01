using LoanApplicationAPI.DBModels;
using LoanApplicationAPI.RequestModels;

namespace LoanApplicationAPI.Contract
{
    public interface IApplicationStatusService
    {
        Task<ApplicationStatus> CreateAsync(ApplicationStatusRequest request);
        Task<ApplicationStatus?> GetByIdAsync(int id);
        Task<List<ApplicationStatus>> GetAllAsync();
        Task<ApplicationStatus?> PatchAsync(int id, ApplicationStatusRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
