using BabysWeeklyMenu.Models;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.API.Data
{
    public class WeeklyMenuContext : DbContext
    {
        public WeeklyMenuContext(DbContextOptions<WeeklyMenuContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> Meals { get; set; }
    }
}
