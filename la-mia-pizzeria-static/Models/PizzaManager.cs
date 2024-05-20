using System;
using System.Linq;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaManager
    {
        // AGGIUNTA DI UNA PIZZA
        public static void InsertPizza(string name, string description, string img, double price)
        {
            using PizzaContext db = new PizzaContext();

            db.Add(new Pizze(name, description, img, price));
            db.SaveChanges();

        }

        // RECUPERARE UN PIZZA TRAMITE IL SUO ID
        public static Pizze GetPizzaById(int id)
        {
            try
            {
                using PizzaContext db = new PizzaContext();

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

        // MODIFICARE UNA PIZZA
        public static bool UpdatePizza(int id, Pizze pizza)
        {
            try
            {
                using PizzaContext db = new PizzaContext();
                var pizzaModificata = db.Pizze.FirstOrDefault(p => p.Id == id);
                if (pizzaModificata == null)
                    return false;

                pizzaModificata.Name = pizza.Name;
                pizzaModificata.Description = pizza.Description;
                pizzaModificata.Img = pizza.Img;
                pizzaModificata.Price = pizza.Price;

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
    }
}
