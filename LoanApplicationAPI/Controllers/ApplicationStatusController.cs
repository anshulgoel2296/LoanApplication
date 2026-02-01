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
        private readonly IApplicationStatusService _applicationStatusService;

        public ApplicationStatusController(IApplicationStatusService applicationStatusService)
        {
            _applicationStatusService = applicationStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _applicationStatusService.GetAllAsync();

            if (user == null || !user.Any())
                return NotFound(ApplicationStatusConstants.ERR_APPLICATION_STATUS_NOT_FOUND);

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _applicationStatusService.GetByIdAsync(id);

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
            var createdApplicationStatus = await _applicationStatusService.CreateAsync(request);

            return CreatedAtAction(nameof(Get), new { id = createdApplicationStatus.StatusId }, createdApplicationStatus);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] ApplicationStatusRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedApplicationStatus = await _applicationStatusService.PatchAsync(id, request);

            return CreatedAtAction(nameof(Get), new { id = updatedApplicationStatus.StatusId }, updatedApplicationStatus);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var isApplicationStatusDeleted = await _applicationStatusService.DeleteAsync(id);

            return Ok(isApplicationStatusDeleted);
        }
    }
}
