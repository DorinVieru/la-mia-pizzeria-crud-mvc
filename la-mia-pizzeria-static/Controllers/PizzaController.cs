using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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

        // Action GET che fornisce la view della FORM
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Chiamata POST che avviene tramite il form passandogli i dati della pizza inserita
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (Pizze pizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", pizza); // Ritorna alla view in cui è presente il form
            }

            PizzaManager.InsertPizza(pizza.Name, pizza.Description, pizza.Img, pizza.Price);
            return RedirectToAction("Index");
        }
    }
}
