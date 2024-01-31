using System.ComponentModel.DataAnnotations;

namespace BabysWeeklyMenu.API.Models
{
    public class Meal
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int Time { get; set; }
        public virtual ICollection<Dish>? Dishes { get; set; }
    }
}
