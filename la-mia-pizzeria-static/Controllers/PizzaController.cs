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

        // Action GET che fornisce la view della FORM per CREARE la pizza
        [HttpGet]
        public IActionResult Create()
        {
            PizzaFormModel model = new PizzaFormModel();
            model.Pizza = new Pizze();
            model.Categories = PizzaManager.GetAllCategories();
            return View(model);
        }

        // Chiamata POST che avviene tramite il form passandogli i dati della pizza INSERITA
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

        // Action GET che fornisce la view della FORM per MODIFICA la pizza
        [HttpGet]
        public IActionResult Update(int id)
        {
            var pizzaId = PizzaManager.GetPizzaById(id);
            if (pizzaId == null)
                return NotFound();

            return View(pizzaId);
        }

        // Chiamata POST che avviene tramite il form passandogli i dati della pizza da MODIFICARE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizze pizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", pizza); // Ritorna alla view in cui è presente il form di modifica
            }

            PizzaManager.UpdatePizza(id, pizza);
            return RedirectToAction("Index");
        }

        // Chiamata POST che avviene tramite il form passandogli i dati della pizza da MODIFICARE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            PizzaManager.DeletePizza(id);
            return RedirectToAction("Index");
        }
    }
}
