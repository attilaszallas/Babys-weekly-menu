using System.ComponentModel.DataAnnotations;

namespace BabysWeeklyMenu.API.Models
{
    public class Allergy
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int IngredientId { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }
}
