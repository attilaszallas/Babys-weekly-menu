using System.ComponentModel.DataAnnotations;

namespace BabysWeeklyMenu.Models
{
    public class Meal
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Time { get; set; }
        public virtual ICollection<Dish>? Dishes { get; set; }
    }
}
