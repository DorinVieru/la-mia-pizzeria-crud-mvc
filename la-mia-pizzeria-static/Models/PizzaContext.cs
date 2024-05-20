using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaContext : DbContext
    {
        private const string SqlServer = "Data Source=localhost;Initial Catalog=pizzas;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public DbSet<Pizze> Pizze { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlServer);
        }
    }
}
