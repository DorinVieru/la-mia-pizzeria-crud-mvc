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

        [HttpPost]
        public IActionResult CreatePizza([FromBody] Pizze pizza)
        {
            PizzaManager.InsertPizza(pizza);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePizza(int id, [FromBody] Pizze pizza)
        {
            var oldPizza = PizzaManager.GetPizzaById(id);
            if (oldPizza == null)

                return NotFound("Errore devastante del sistema! Riprova, sarai più fortunato.");
            PizzaManager.UpdatePizza(id, pizza, null);
            return Ok(oldPizza);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            bool found = PizzaManager.DeletePizza(id);
            if (found)
                return Ok("Pizza selezionata cancellata con successo.");

            return NotFound();
        }
    }
}
