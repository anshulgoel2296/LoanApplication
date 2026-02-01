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
    public class ApplicationStatusController : ControllerBase
    {
        private readonly IApplicationStatusService _userService;

        public ApplicationStatusController(IApplicationStatusService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _userService.GetAllAsync();

            if (user == null || !user.Any())
                return NotFound(ApplicationStatusConstants.ERR_APPLICATION_STATUS_NOT_FOUND);

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound(ApplicationStatusConstants.ERR_APPLICATION_STATUS_NOT_FOUND);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApplicationStatusRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdApplicationStatus = await _userService.CreateAsync(request);

            return CreatedAtAction(nameof(Get), new { id = createdApplicationStatus.StatusId }, createdApplicationStatus);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] ApplicationStatusRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedApplicationStatus = await _userService.PatchAsync(id, request);

            return CreatedAtAction(nameof(Get), new { id = updatedApplicationStatus.StatusId }, updatedApplicationStatus);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isApplicationStatusDeleted = await _userService.DeleteAsync(id);

            return Ok(isApplicationStatusDeleted);
        }
    }
}
