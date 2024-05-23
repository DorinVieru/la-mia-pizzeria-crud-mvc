using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaWebApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllPizzas(string? search)
        {
            if (search == null)
               return Ok(PizzaManager.GetAllPizze());

            return Ok(PizzaManager.GetAllPizzas(search));
        }

        [HttpGet("{id}")]
        public IActionResult GetPizzaById(int id)
        {
            var pizza = PizzaManager.GetPizzaById(id);
            if (pizza == null)
                return NotFound();

            return Ok(pizza);
        }
    }
}
