using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabysWeeklyMenu.Models
{
    public class Ingredient
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int DishId { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public virtual ICollection<Allergy>? Allergies { get; set; }
    }
}
