using System.ComponentModel.DataAnnotations;

namespace BabysWeeklyMenu.Models
{
    public class Recipe
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? RecipeDescription { get; set; }
        public virtual ICollection<Ingredient>? Ingredients { get; set; }
    }
}
