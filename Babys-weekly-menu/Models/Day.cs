using System.ComponentModel.DataAnnotations;

namespace BabysWeeklyMenu.Models
{
    public class Day
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Meal>? Meals { get; set; }
    }
}
