using BabysWeeklyMenu.Models;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.Data
{
    public class WeeklyMenuDbContext : DbContext
    {
        public WeeklyMenuDbContext(DbContextOptions<WeeklyMenuDbContext> options) : base(options) { }

        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Day> Days { get; set; }
    }
}
