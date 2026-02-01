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
    public class LoanTypeController : ControllerBase
    {
        private readonly ILoanTypeService _userService;

        public LoanTypeController(ILoanTypeService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _userService.GetAllAsync();

            if (user == null || !user.Any())
                return NotFound(LoanTypeConstants.ERR_LOAN_TYPE_NOT_FOUND);

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound(LoanTypeConstants.ERR_LOAN_TYPE_NOT_FOUND);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoanTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdLoanType = await _userService.CreateAsync(request);

            return CreatedAtAction(nameof(Get), new { id = createdLoanType.LoanId }, createdLoanType);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] LoanTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedLoanType = await _userService.PatchAsync(id, request);

            return CreatedAtAction(nameof(Get), new { id = updatedLoanType.LoanId }, updatedLoanType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isLoanTypeDeleted = await _userService.DeleteAsync(id);

            return Ok(isLoanTypeDeleted);
        }
    }
}
