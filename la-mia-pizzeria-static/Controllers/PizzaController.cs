using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            var pizze = PizzaManager.GetAllPizze();
            return View(pizze);
        }

        public IActionResult Details(int id)
        {
            var pizza = PizzaManager.GetPizzaById(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }
    }
}
