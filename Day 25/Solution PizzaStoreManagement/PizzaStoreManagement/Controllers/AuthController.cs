using Microsoft.AspNetCore.Mvc;
using PizzaStoreManagement.Interfaces;
using PizzaStoreManagement.Models;
using PizzaStoreManagement.Models.DTOs;

namespace PizzaStoreManagement.Controllers
{
    [Route("api/pizzaStore")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registerUser")]
        [ProducesResponseType(typeof(RegisterReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegisterReturnDTO>> Register([FromBody] UserRegisterDTO user)
        {
            try
            {
                var result = await _userService.RegisterUser(user);
                if(result != null)
                {
                    return Ok(result);
                }
                throw new Exception("User created , But cannot get the details");
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501 , ex.Message));
            }
        }

        [HttpPost("loginUser")]
        [ProducesResponseType(typeof(LoginReturnDTO) , StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel) , StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginReturnDTO>> Login([FromBody]LoginDTO loginDTO)
        {
            try
            {
                var result = await _userService.LoginUser(loginDTO);
                if(result != null)
                {
                    return Ok(result);
                }
                throw new Exception("UserId , Token unavailable");
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
    }
}
