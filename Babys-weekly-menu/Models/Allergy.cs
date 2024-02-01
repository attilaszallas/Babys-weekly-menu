using System.ComponentModel.DataAnnotations;

namespace BabysWeeklyMenu.Models
{
    public class Allergy
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Icon { get; set; }
    }
}
