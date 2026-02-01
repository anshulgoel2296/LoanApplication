using Azure.Core;
using LoanApplicationAPI.Contract;
using LoanApplicationAPI.DBModels;
using LoanApplicationAPI.RequestModels;
using LoanApplicationAPI.Util;
using Microsoft.AspNetCore.Mvc;


namespace LoanApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplicationController : ControllerBase
    {
        private readonly ILoanApplicationService _loanApplicationService;

        public LoanApplicationController(ILoanApplicationService loanApplicationService)
        {
            _loanApplicationService = loanApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _loanApplicationService.GetAllAsync();

            if (user == null || !user.Any())
                return NotFound(LoanApplicationConstants.ERR_LOAN_APPLICATION_NOT_FOUND);

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _loanApplicationService.GetByIdAsync(id);

            if (user == null)
                return NotFound(LoanApplicationConstants.ERR_LOAN_APPLICATION_NOT_FOUND);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoanApplicationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdLoanApplication = await _loanApplicationService.CreateAsync(request);

            return CreatedAtAction(nameof(Get), new { id = createdLoanApplication.Id }, createdLoanApplication);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] LoanApplicationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedLoanApplication = await _loanApplicationService.PatchAsync(id, request);

            return CreatedAtAction(nameof(Get), new { id = updatedLoanApplication.Id }, updatedLoanApplication);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isLoanApplicationDeleted = await _loanApplicationService.DeleteAsync(id);

            return Ok(isLoanApplicationDeleted);
        }
    }
}
