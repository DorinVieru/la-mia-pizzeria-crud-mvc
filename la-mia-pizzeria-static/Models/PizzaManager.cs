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
                using (PizzaContext context = new PizzaContext())
                {
                    return context.Pizze.FirstOrDefault(p => p.Id == id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: pizza non trovata. -> {ex.Message}");
                return null;
            }
        }

        public static List<Pizze> GetAllPizze()
        {
            using (var context = new PizzaContext())
            {
                return context.Pizze.ToList();
            }
        }
    }
}
