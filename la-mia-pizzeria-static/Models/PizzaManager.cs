using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaManager
    {
        // AGGIUNTA DI UNA PIZZA
        public static void InsertPizza(Pizze Pizza, List<string> SelectedIngredients = null)
        {
            using PizzaContext db = new PizzaContext();

            if (SelectedIngredients != null)
            {
                Pizza.Ingredients = new List<Ingredient>();
                // Trasformo gli ID scelti nel form in ingredienti da ggiungere alle pizze
                foreach (var ingId in SelectedIngredients)
                {
                    int id = int.Parse(ingId);
                    var ing = db.Ingredients.FirstOrDefault(i => i.Id == id);
                    Pizza.Ingredients.Add(ing);
                }
            }

            db.Pizze.Add(Pizza);
            db.SaveChanges();

        }

        // RECUPERARE UN PIZZA TRAMITE IL SUO ID
        public static Pizze GetPizzaById(int id, bool includeReferences = true)
        {
            try
            {
                using PizzaContext db = new PizzaContext();

                if (includeReferences)
                    return db.Pizze.Where(p => p.Id == id).Include(p => p.Category).Include(p => p.Ingredients).FirstOrDefault();
                return db.Pizze.FirstOrDefault(p => p.Id == id);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: pizza non trovata. -> {ex.Message}");
                return null;
            }
        }

        // OTTENERE LA LISTA DI TUTTE LE PIZZE
        public static List<Pizze> GetAllPizze()
        {
            using var db = new PizzaContext();

            return db.Pizze.ToList();
        }

        // OTTENERE LA LISTA DI TUTTE LE PIZZE CON FILTRO
        public static List<Pizze> GetAllPizzas(string? search)
        {
            using PizzaContext db = new PizzaContext();

            if (search == null)
                return db.Pizze.ToList();

            return db.Pizze.Where(p => p.Name.ToLower().Contains(search)).ToList();
        }

        // MODIFICARE UNA PIZZA
        public static bool UpdatePizza(int id, Pizze pizzaData, List<string> ingredients)
        {
            using PizzaContext db = new PizzaContext();
            var pizza = db.Pizze.Where(p => p.Id == id).Include(i => i.Ingredients).FirstOrDefault();

            if (pizza == null)
                return false;

            pizza.Name = pizzaData.Name;
            pizza.Description = pizzaData.Description;
            pizza.ImgFile = pizzaData.ImgFile;
            pizza.Price = pizzaData.Price;
            pizza.CategoryId = pizzaData.CategoryId;

            pizza.Ingredients.Clear(); // Prima svuoto così da salvare solo le informazioni che l'utente ha scelto, NON le aggiungiamo ai vecchi dati
            if (ingredients != null)
            {
                foreach (var ing in ingredients)
                {
                    int ingredientId = int.Parse(ing);
                    var ingredientDB = db.Ingredients.FirstOrDefault(x => x.Id == ingredientId);
                    pizza.Ingredients.Add(ingredientDB);
                }
            }

            db.SaveChanges();

            return true;
        }

        // CANCELLARE UNA PIZZA
        public static bool DeletePizza(int id)
        {
            try
            {
                var pizzaCancellata = GetPizzaById(id);
                if (pizzaCancellata == null)
                    return false;

                using PizzaContext db = new PizzaContext();
                db.Remove(pizzaCancellata);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        // PRENDERE TUTTE LE CATEGORIE DELLE PIZZE
        public static List<Category> GetAllCategories()
        {
            using PizzaContext db = new PizzaContext();
            return db.Categories.ToList();
        }

        // PRENDERE TUTTE GLI INGREDIENTI DELLE PIZZE
        public static List<Ingredient> GetAllIngredients()
        {
            using PizzaContext db = new PizzaContext();
            return db.Ingredients.ToList();
        }  
    }
}
