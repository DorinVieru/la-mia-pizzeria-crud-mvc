using System;
using System.Linq;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaManager
    {
        public static void InsertPizza(string name, string description, string img, double price)
        {
            using PizzaContext context = new PizzaContext();

            context.Add(new Pizze(name, description, img, price));
            context.SaveChanges();

        }

        public static Pizze GetPizzaById(int id)
        {
            try
            {
                using PizzaContext context = new PizzaContext();

                return context.Pizze.FirstOrDefault(p => p.Id == id);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: pizza non trovata. -> {ex.Message}");
                return null;
            }
        }

        public static List<Pizze> GetAllPizze()
        {
            using var context = new PizzaContext();

            return context.Pizze.ToList();
        }

        public static bool UpdatePizza(int id, Pizze pizza)
        {
            try
            {
                using PizzaContext context = new PizzaContext();
                var pizzaModificata = context.Pizze.FirstOrDefault(p => p.Id == id);
                if (pizzaModificata == null)
                    return false;

                pizzaModificata.Name = pizza.Name;
                pizzaModificata.Description = pizza.Description;
                pizzaModificata.Img = pizza.Img;
                pizzaModificata.Price = pizza.Price;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool DeletePizza(int id)
        {
            try
            {
                var pizzaCancellata = GetPizzaById(id);
                if (pizzaCancellata == null)
                    return false;

                using PizzaContext context = new PizzaContext();
                context.Remove(pizzaCancellata);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
