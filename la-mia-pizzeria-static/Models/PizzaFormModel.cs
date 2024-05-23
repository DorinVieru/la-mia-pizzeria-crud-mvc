using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaFormModel
    {
        public Pizze Pizza { get; set; }
        public List<Category>? Categories { get; set; }
        public List<SelectListItem>? Ingredients { get; set; } // Gli ingredienti selezionabili 
        public List<string>? SelectedIngredients { get; set; } // Gli ID degli ingredienti effettivamente selezionati
        public IFormFile? ImageFormFile { get; set; } // Immagine da caricare

        public PizzaFormModel() { }

        public PizzaFormModel(Pizze pizza, List<Category>? categories)
        {
            Pizza = pizza;
            Categories = categories;
            SelectedIngredients = new List<string>();
            if (Pizza.Ingredients != null)
                foreach (var i in Pizza.Ingredients)
                    SelectedIngredients.Add(i.Id.ToString());
        }

        public void CreateIngredients()
        {
            this.Ingredients = new List<SelectListItem>();
            if (this.SelectedIngredients == null)
                this.SelectedIngredients = new List<string>();

            var ingredientsFromDB = PizzaManager.GetAllIngredients();
            foreach (var ing in ingredientsFromDB)
            {
                bool isSelected = this.SelectedIngredients.Contains(ing.Id.ToString()); 
                this.Ingredients.Add(new SelectListItem() // lista degli elementi selezionabili
                {
                    Text = ing.Name, 
                    Value = ing.Id.ToString(), 
                    Selected = isSelected 
                });
            }
        }

        // Travasa i dati di ImageFormFile in Pizza.Img(da IFormFile a byte[])
        public byte[] SetImageFileFromFormFile()
        {
            if (ImageFormFile == null)
                return null;

            using var stream = new MemoryStream();
            this.ImageFormFile?.CopyTo(stream);
            Pizza.ImgFile = stream.ToArray();

            return Pizza.ImgFile;
        }
    }
}
