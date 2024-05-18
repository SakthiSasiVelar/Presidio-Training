using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaStoreManagement.Interfaces;
using PizzaStoreManagement.Models;
using PizzaStoreManagement.Models.DTOs;

namespace PizzaStoreManagement.Controllers
{
    [Route("api/pizzaStore")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [Authorize(Roles = "admin")]
        [HttpPost("addPizza")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddPizza([FromBody] Pizza pizza)
        {
            try
            {
                var result = await _pizzaService.AddPizza(pizza);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorModel(501,ex.Message));
            }
        }

        [Authorize]
        [HttpGet("availablePizzaList")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<Pizza>>> GetAllAvailablePizza()
        {
            try
            {
                var result = await _pizzaService.GetAvailablePizza();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501,ex.Message));
            }
        }
    }
}
