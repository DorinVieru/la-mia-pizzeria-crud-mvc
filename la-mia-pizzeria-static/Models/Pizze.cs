namespace la_mia_pizzeria_static.Models
{
    public class Pizze
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public double Price { get; set; }

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
