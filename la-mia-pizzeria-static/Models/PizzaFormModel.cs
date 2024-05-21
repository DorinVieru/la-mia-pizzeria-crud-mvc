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

        public void CreateIngredients()
        {
            this.Ingredients = new List<SelectListItem>();
            this.SelectedIngredients = new List<string>();
            var ingredientsFromDB = PizzaManager.GetAllIngredients();
            foreach (var ing in ingredientsFromDB)
            {
                bool isSelected = this.Pizza.Ingredients?.Any(i => i.Id == ing.Id) == true;
                this.Ingredients.Add(new SelectListItem() // lista degli elementi selezionabili
                {
                    Text = ing.Name, 
                    Value = ing.Id.ToString(), 
                    Selected = isSelected 
                });
                if (isSelected)
                    this.SelectedIngredients.Add(ing.Id.ToString()); 
            }
        }
    }
}
