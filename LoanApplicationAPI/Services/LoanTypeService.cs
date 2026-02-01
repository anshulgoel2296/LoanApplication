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
    public class LoanTypeService : ILoanTypeService
    {
        private readonly DBContext _dbContext;
        private readonly IMapper _mapper;

        public LoanTypeService(DBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<LoanType> CreateAsync(LoanTypeRequest request)
        {
            if (_dbContext.LoanTypeList != null && _dbContext.LoanTypeList.Where(x => x.LoanCode.ToLower().Equals(request.LoanCode.ToLower())).Any())
            {
                throw new LoanTypeAlreadyExistsException(LoanTypeConstants.ERR_LOAN_TYPE_EXISTS);
            }
            var LoanType = new LoanType
            {
                LoanCode = request.LoanCode,
                Description = request.Description
            };

            _ = _dbContext.LoanTypeList.Add(LoanType);
            await _dbContext.SaveChangesAsync();

            return LoanType;
        }

        // READ (by id)
        public async Task<LoanType?> GetByIdAsync(int id)
        {
            return await _dbContext.LoanTypeList
                .FirstOrDefaultAsync(u => u.LoanId == id);
        }

        // READ (all)
        public async Task<List<LoanType>> GetAllAsync()
        {
            return await _dbContext.LoanTypeList
                .OrderBy(u => u.LoanId)
                .ToListAsync();
        }

        public async Task<LoanType?> PatchAsync(int id, LoanTypeRequest request)
        {
            var LoanType = await _dbContext.LoanTypeList
                .FirstOrDefaultAsync(u => u.LoanId == id);

            if (LoanType == null)
                throw new LoanTypeNotFoundException(LoanTypeConstants.ERR_NO_LOAN_TYPE_EXISTS);

            _mapper.Map(request, LoanType);

            await _dbContext.SaveChangesAsync();
            return LoanType;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var LoanType = await _dbContext.LoanTypeList
                .FirstOrDefaultAsync(u => u.LoanId == id);

            if (LoanType == null)
                throw new LoanTypeNotFoundException(LoanTypeConstants.ERR_LOAN_TYPE_NOT_FOUND);

            _dbContext.LoanTypeList.Remove(LoanType);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
