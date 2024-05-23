using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

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
            var pizza = PizzaManager.GetPizzaById(id, true);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

        // CREAZIONE GET
        [HttpGet]
        [Authorize (Roles ="Admin")]
        public IActionResult Create()
        {
            Pizze p = new Pizze();
            List<Category> categories = PizzaManager.GetAllCategories();

            PizzaFormModel model = new PizzaFormModel(p, categories);
            model.CreateIngredients();

            return View(model);
        }

        // CREAZIONE POST che avviene tramite il form passandogli i dati della pizza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (PizzaFormModel pizzaDaInserire, IFormFile img)
        {
            if (!ModelState.IsValid)
            {
                // Ottenere la lista degli errori di validazione
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                // Verifica se ci sono errori o se la foto non è presente
                if (errorMessages.Count > 1 || img == null || img.Length == 0)
                {
                    pizzaDaInserire.Categories = PizzaManager.GetAllCategories();
                    pizzaDaInserire.CreateIngredients();
                    return View("Create", pizzaDaInserire); // Ritorna alla view in cui è presente il form
                }
            }

            string imgFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img");
            string imgFileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
            string imgPath = Path.Combine(imgFolderPath, imgFileName);

            using (var stream = new FileStream(imgPath, FileMode.Create))
            {
                await img.CopyToAsync(stream);
            }
            //pizza.Pizza.Foto;

            PizzaManager.InsertPizza(pizzaDaInserire.Pizza, pizzaDaInserire.SelectedIngredients);
            return RedirectToAction("Index");
        }

        // MODIFICA GET 
        [HttpGet]
        public IActionResult Update(int id)
        {
            var pizzaModificata = PizzaManager.GetPizzaById(id);
            if (pizzaModificata == null)
                return NotFound();

            PizzaFormModel model = new PizzaFormModel(pizzaModificata, PizzaManager.GetAllCategories());
            model.CreateIngredients();

            return View(model);
        }

        // MODIFICA POST che avviene tramite il form passandogli i dati della pizza
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaFormModel pizzaDaModificare)
        {
            if (!ModelState.IsValid)
            {
                pizzaDaModificare.Categories = PizzaManager.GetAllCategories();
                pizzaDaModificare.CreateIngredients();
                return View("Update", pizzaDaModificare); // Ritorna alla view in cui è presente il form di modifica
            }

            if (PizzaManager.UpdatePizza(id, pizzaDaModificare.Pizza, pizzaDaModificare.SelectedIngredients))
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
