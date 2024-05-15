using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaHutAPI.Exceptions;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;

namespace PizzaHutAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [ProducesResponseType(typeof(Pizza),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage),StatusCodes.Status500InternalServerError)]
        [HttpPost("AddPizza")]
        public async Task<ActionResult<Pizza>> AddPizza(Pizza pizza)
        {
            try
            {
                var result = await _pizzaService.Add(pizza);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessage(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }
        
        [ProducesResponseType(typeof(IEnumerable<Pizza>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorMessage),StatusCodes.Status500InternalServerError)]

        [HttpGet("Pizza/getAvailablePizza")]
        public async Task<ActionResult<List<Pizza>>> GetAvailablePizza()
        {
            try
            {
                var result = await _pizzaService.GetAvailablePizza();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessage(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }

    }
}
