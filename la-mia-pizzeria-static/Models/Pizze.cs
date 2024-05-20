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

        [Required(ErrorMessage = "L'immagine della pizza è obbligatoria.")]
        public string Img { get; set; }

        [Required(ErrorMessage = "Il prezzo della pizza è obbligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Il prezzo della pizza deve essere superiore a 0,00€.")]
        [RegularExpression(@"^\d+\,\d{0,2}$", ErrorMessage = "Il prezzo della pizza deve essere in formato numerico con massimo due decimali.")]
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public Pizze() { }

        public Pizze(string name, string description, string img, double price)
        {
            this.Name = name;
            this.Description = description;
            this.Img = img;
            this.Price = price;
        }
    }
}
