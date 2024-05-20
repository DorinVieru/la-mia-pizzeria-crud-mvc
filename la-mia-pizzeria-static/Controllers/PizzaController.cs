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

        // CREAZIONE GET
        [HttpGet]
        public IActionResult Create()
        {
            PizzaFormModel model = new PizzaFormModel();
            model.Pizza = new Pizze();
            model.Categories = PizzaManager.GetAllCategories();
            return View(model);
        }

        // CREAZIONE POST che avviene tramite il form passandogli i dati della pizza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (PizzaFormModel pizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", pizza); // Ritorna alla view in cui è presente il form
            }

            PizzaManager.InsertPizza(pizza.Pizza);
            return RedirectToAction("Index");
        }

        // MODIFICA GET 
        [HttpGet]
        public IActionResult Update(int id)
        {
            var pizzaModificata = PizzaManager.GetPizzaById(id);
            if (pizzaModificata == null)
                return NotFound();

            PizzaFormModel model = new PizzaFormModel();
            model.Pizza = pizzaModificata;
            model.Categories = PizzaManager.GetAllCategories();
            return View(model);
        }

        // MODIFICA POST che avviene tramite il form passandogli i dati della pizza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaFormModel pizza)
        {
            if (!ModelState.IsValid)
            {
                List<Category> categories = PizzaManager.GetAllCategories();
                pizza.Categories = categories;
                return View("Update", pizza); // Ritorna alla view in cui è presente il form di modifica
            }

            // Trova la pizza esistente
            var pizzaDaModificare = PizzaManager.GetPizzaById(id);
            if (pizzaDaModificare == null)
                return NotFound();

            // MODIFICA CON LA FUNZIONE LAMBDA
            bool result = PizzaManager.UpdatePizza(id, pizzaModificata =>
            {
                pizzaModificata.Name = pizza.Pizza.Name;
                pizzaModificata.Description = pizza.Pizza.Description;
                pizzaModificata.Img = pizza.Pizza.Img;
                pizzaModificata.Price = pizza.Pizza.Price;
                pizzaModificata.CategoryId = pizza.Pizza.CategoryId;
            });
            
            if (result)
                return RedirectToAction("Index");
            else
                return NotFound();
        }

        // CNACELLAZIONE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            PizzaManager.DeletePizza(id);
            return RedirectToAction("Index");
        }
    }
}
