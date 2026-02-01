using AutoMapper;
using Azure.Core;
using LoanApplicationAPI.Context;
using LoanApplicationAPI.Contract;
using LoanApplicationAPI.DBModels;
using LoanApplicationAPI.Exceptions;
using LoanApplicationAPI.RequestModels;
using LoanApplicationAPI.Util;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationAPI.Services
{
    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly DBContext _dbContext;
        private readonly IMapper _mapper;

        public LoanApplicationService(DBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private void validateRequestBody(LoanApplicationRequest request)
        {

            if (_dbContext.ApplicationStatusList == null || !_dbContext.ApplicationStatusList.Where(x => x.StatusId == request.CurrentStatusId).Any())
            {
                throw new LoanApplicationNotFoundException(ApplicationStatusConstants.ERR_NO_APPLICATION_STATUS_EXISTS);
            }
            if (_dbContext.LoanTypeList == null || !_dbContext.LoanTypeList.Where(x => x.LoanId == request.LoanTypeId).Any())
            {
                throw new LoanApplicationNotFoundException(LoanTypeConstants.ERR_NO_LOAN_TYPE_EXISTS);
            }
            if (_dbContext.UsersList == null || !_dbContext.UsersList.Where(x => x.Id == request.UserId).Any())
            {
                throw new LoanApplicationNotFoundException(UserConstants.ERR_NO_USER_EXISTS);
            }
        }

        public async Task<LoanApplication> CreateAsync(LoanApplicationRequest request)
        {
            validateRequestBody(request);
            if (_dbContext.LoanApplicationList != null && _dbContext.LoanApplicationList.Where(x => x.UserId == request.UserId && x.LoanTypeId == request.LoanTypeId).Any())
            {
                throw new LoanApplicationAlreadyExistsException(LoanApplicationConstants.ERR_LOAN_APPLICATION_EXISTS);
            }
            var LoanApplication = new LoanApplication
            {
                UserId = request.UserId,
                LoanTypeId = request.LoanTypeId,
                CurrentStatusId = request.CurrentStatusId,
                PreviousStatusId = request.PreviousStatusId,
                LoanAmount = request.LoanAmount,
                CreatedDateTime = DateTime.UtcNow,
                UpdatedDateTime = DateTime.UtcNow

            };

            _ = _dbContext.LoanApplicationList.Add(LoanApplication);
            await _dbContext.SaveChangesAsync();

            return LoanApplication;
        }

        
        public async Task<LoanApplication?> GetByIdAsync(int id)
        {
            return await _dbContext.LoanApplicationList
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        
        public async Task<List<LoanApplication>> GetAllAsync()
        {
            return await _dbContext.LoanApplicationList
                .OrderBy(u => u.Id)
                .ToListAsync();
        }

        public async Task<LoanApplication?> PatchAsync(int id, LoanApplicationRequest request)
        {
            validateRequestBody(request);
            var LoanApplication = await _dbContext.LoanApplicationList
                .FirstOrDefaultAsync(u => u.Id == id);

            if (LoanApplication == null)
                throw new LoanApplicationNotFoundException(LoanApplicationConstants.ERR_NO_LOAN_APPLICATION_EXISTS);

            if (!_dbContext.ApplicationStatusList.Where(x => x.StatusId == request.CurrentStatusId).FirstOrDefault().IsUpdateEnabled)
                throw new LoanApplicationNotFoundException(LoanApplicationConstants.ERR_STATUS_UPDATE_NOT_ALLOWED);
            LoanApplication.PreviousStatusId = LoanApplication.CurrentStatusId;
            _mapper.Map(request, LoanApplication);
            LoanApplication.UpdatedDateTime = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
            return LoanApplication;
        }

        
        public async Task<bool> DeleteAsync(int id)
        {
            var LoanApplication = await _dbContext.LoanApplicationList
                .FirstOrDefaultAsync(u => u.Id == id);

            if (LoanApplication == null)
                throw new LoanApplicationNotFoundException(LoanApplicationConstants.ERR_LOAN_APPLICATION_NOT_FOUND);

            _dbContext.LoanApplicationList.Remove(LoanApplication);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
