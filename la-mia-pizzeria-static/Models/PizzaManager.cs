using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaManager
    {
        // AGGIUNTA DI UNA PIZZA
        public static void InsertPizza(Pizze Pizza)
        {
            using PizzaContext db = new PizzaContext();

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
                    return db.Pizze.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefault();
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

        // MODIFICARE UNA PIZZA (definendo come parametro ciò che voglio modificare)
        public static bool UpdatePizza(int id, Action<Pizze> edit)
        {
            try
            {
                using PizzaContext db = new PizzaContext();
                var pizzaModificata = db.Pizze.FirstOrDefault(p => p.Id == id);
                if (pizzaModificata == null)
                    return false;

                edit(pizzaModificata);

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
