using EmployeeTracker.Interfaces;
using EmployeeTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTracker.Controllers
{
    [Route("api")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        [Authorize(Roles = "admin")]
        [HttpPut("admin/UpdateUserStatus")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> UpdateStatus([FromBody] int userId)
        {
            try
            {
                var result = await _adminService.UpdateUserStatus(userId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorModel(501 , ex.Message));
            }
        }
    }
}
