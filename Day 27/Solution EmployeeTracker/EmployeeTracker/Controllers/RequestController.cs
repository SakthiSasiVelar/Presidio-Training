using EmployeeTracker.Interfaces;
using EmployeeTracker.Models;
using EmployeeTracker.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeTracker.Controllers
{
    [Route("api/request")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService) 
        { 
            _requestService = requestService;
        }

        [Authorize]
        [HttpPost("addRequest")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]

        public async Task<ActionResult<int>> AddRequest([FromBody] RaiseRequestDTO request)
        {
            try
            {
                var result = await _requestService.RaiseRequest(request);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorModel(501 ,ex.Message));
            }
        }

        [Authorize]
        [HttpGet("getRequest/{id}")]
        [ProducesResponseType(typeof(RequestReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<RequestReturnDTO>>> GetRequestById(int id)
        {
            try
            {
                var result = await _requestService.GetAllRequestById(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet("getAllRequest")]
        [ProducesResponseType(typeof(RequestReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<RequestReturnDTO>>> GetAllRequest()
        {
            try
            {
                var result = await _requestService.GetAllOpenRequest();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
