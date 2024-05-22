using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaContext : IdentityDbContext<IdentityUser>
    {
        private const string SqlServer = "Data Source=localhost;Initial Catalog=pizzas;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public DbSet<Pizze> Pizze { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlServer);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizze>()
                .HasOne(o => o.Category)
                .WithMany(o => o.pizzes)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
