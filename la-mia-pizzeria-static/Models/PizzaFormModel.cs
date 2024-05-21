using Microsoft.AspNetCore.Mvc.Rendering;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaFormModel
    {
        public Pizze Pizza { get; set; }
        public List<Category>? Categories { get; set; }
        public List<SelectListItem>? Ingredients { get; set; } // Gli ingredienti selezionabili 
        public List<string>? SelectedIngredients { get; set; } // Gli ID degli ingredienti effettivamente selezionati

        public PizzaFormModel() { }
    }
}
