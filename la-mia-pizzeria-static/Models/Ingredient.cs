using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Ingredient
    {
        [Key] public int Id { get; set; }
        
        [StringLength(200, ErrorMessage = "Il nome della categoria può avere un massimo di 200 caratteri.")]
        [Required(ErrorMessage = "Il nome della categoria è obbligatorio.")]
        public string Name { get; set; }
        public List<Pizze> pizzes { get; set; }

        public Ingredient() { }
    }
}
