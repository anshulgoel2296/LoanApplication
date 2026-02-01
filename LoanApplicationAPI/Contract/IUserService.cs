using LoanApplicationAPI.DBModels;
using LoanApplicationAPI.RequestModels;

namespace LoanApplicationAPI.Contract
{
    public interface IUserService
    {
        Task<User> CreateAsync(UserRequest request);
        Task<User?> GetByIdAsync(int id);
        Task<List<User>> GetAllAsync();
        Task<User?> PatchAsync(int id, UserRequest request);
        Task<bool> DeleteAsync(int id);
    }
}
