using BabysWeeklyMenu.Models;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.API.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergy>().HasData(
            new Allergy { Id = 1, IngredientId = 1, Name = "" },
            new Allergy { Id = 2, IngredientId = 1, Name = "" });

        modelBuilder.Entity<Ingredient>().HasData(
            new Ingredient { Id = 1, DishId = 1, Name = "" },
            new Ingredient { Id = 2, DishId = 1, Name = "" });

        modelBuilder.Entity<Dish>().HasData(
            new Dish { Id = 1, MealId = 1, Name = "" },
            new Dish { Id = 2, MealId = 1, Name = "" });

        modelBuilder.Entity<Meal>().HasData(
            new Meal { Id = 1, Time = 10 },
            new Meal { Id = 2, Time = 14 });
    }
}
