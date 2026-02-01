using AutoMapper;
using LoanApplicationAPI.Context;
using LoanApplicationAPI.Contract;
using LoanApplicationAPI.DBModels;
using LoanApplicationAPI.Exceptions;
using LoanApplicationAPI.RequestModels;
using LoanApplicationAPI.Util;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationAPI.Services
{
    public class UserService: IUserService
    {
        private readonly DBContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(DBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<User> CreateAsync(UserRequest request)
        {
            if (_dbContext.UsersList != null && _dbContext.UsersList.Where(x => x.Email.ToLower().Equals(request.Email.ToLower())).Any())
            {
                throw new UserAlreadyExistsException(UserConstants.ERR_USER_EXISTS);
            }
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                ContactNumber = request.ContactNumber,
                CreatedDateTime = DateTime.UtcNow
            };

            _ = _dbContext.UsersList.Add(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        // READ (by id)
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _dbContext.UsersList
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        // READ (all)
        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.UsersList
                .OrderBy(u => u.Id)
                .ToListAsync();
        }

        public async Task<User?> PatchAsync(int id, UserRequest request)
        {
            var user = await _dbContext.UsersList
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new UserNotFoundException(UserConstants.ERR_NO_USER_EXISTS);

            _mapper.Map(request, user);
            
            await _dbContext.SaveChangesAsync();
            return user;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _dbContext.UsersList
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new UserNotFoundException(UserConstants.ERR_USER_NOT_FOUND);

            _dbContext.UsersList.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
