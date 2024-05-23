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
        public IActionResult GetAllPizzas()
        {
            var pizzas = PizzaManager.GetAllPizze();
            return Ok(pizzas);
        }
    }
}
