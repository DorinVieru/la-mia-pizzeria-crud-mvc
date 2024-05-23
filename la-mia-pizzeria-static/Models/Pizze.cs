using System.ComponentModel.DataAnnotations;
using Xunit;
using Xunit.Sdk;

namespace la_mia_pizzeria_static.Models
{
    public class Pizze
    {
        [ Key ] public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Il nome della pizza può avere un massimo di 50 caratteri (nessun nome è così lungo!).")]
        [Required(ErrorMessage = "Il nome della pizza è obbligatorio.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Il nome della pizza può avere un massimo di 500 caratteri.")]
        [Required(ErrorMessage = "La descrizione della pizza è obbligatoria.")]
        public string Description { get; set; }
        public byte[]? ImgFile { get; set; }
        public string ImgSrc => ImgFile != null ? $"data:image/png;base64,{Convert.ToBase64String(ImgFile)}" : "";

        [Required(ErrorMessage = "Il prezzo della pizza è obbligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Il prezzo della pizza deve essere superiore a 0,00€.")]
        [RegularExpression(@"^\d+(\,\d{1,2})?$", ErrorMessage = "Il prezzo della pizza deve essere in formato numerico con massimo due decimali.")]
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Ingredient>? Ingredients { get; set; }

        public Pizze() { }

        public string ViewCategory()
        {
            if (Category == null)
                return "Nessuna categoria assegnata.";
            return Category.Title;
        }
    }
}
