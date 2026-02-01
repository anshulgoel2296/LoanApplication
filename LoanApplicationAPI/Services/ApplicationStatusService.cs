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
    public class ApplicationStatusService : IApplicationStatusService
    {
        private readonly DBContext _dbContext;
        private readonly IMapper _mapper;

        public ApplicationStatusService(DBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationStatus> CreateAsync(ApplicationStatusRequest request)
        {
            if (_dbContext.ApplicationStatusList != null && _dbContext.ApplicationStatusList.Where(x => x.StatusCode.ToLower().Equals(request.StatusCode.ToLower())).Any())
            {
                throw new ApplicationStatusAlreadyExistsException(ApplicationStatusConstants.ERR_APPLICATION_STATUS_EXISTS);
            }
            var ApplicationStatus = new ApplicationStatus
            {
                StatusCode = request.StatusCode,
                Description = request.Description
            };

            _ = _dbContext.ApplicationStatusList.Add(ApplicationStatus);
            await _dbContext.SaveChangesAsync();

            return ApplicationStatus;
        }

        
        public async Task<ApplicationStatus?> GetByIdAsync(int id)
        {
            return await _dbContext.ApplicationStatusList
                .FirstOrDefaultAsync(u => u.StatusId == id);
        }

        
        public async Task<List<ApplicationStatus>> GetAllAsync()
        {
            return await _dbContext.ApplicationStatusList
                .OrderBy(u => u.StatusId)
                .ToListAsync();
        }

        public async Task<ApplicationStatus?> PatchAsync(int id, ApplicationStatusRequest request)
        {
            var ApplicationStatus = await _dbContext.ApplicationStatusList
                .FirstOrDefaultAsync(u => u.StatusId == id);

            if (ApplicationStatus == null)
                throw new ApplicationStatusNotFoundException(ApplicationStatusConstants.ERR_NO_APPLICATION_STATUS_EXISTS);

            _mapper.Map(request, ApplicationStatus);

            await _dbContext.SaveChangesAsync();
            return ApplicationStatus;
        }

        
        public async Task<bool> DeleteAsync(int id)
        {
            var ApplicationStatus = await _dbContext.ApplicationStatusList
                .FirstOrDefaultAsync(u => u.StatusId == id);

            if (ApplicationStatus == null)
                throw new ApplicationStatusNotFoundException(ApplicationStatusConstants.ERR_APPLICATION_STATUS_NOT_FOUND);

            _dbContext.ApplicationStatusList.Remove(ApplicationStatus);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
