using System.ComponentModel.DataAnnotations;

namespace bruhBruh.Models
{
    public class veggies
    {
        [Key]
        [Display(Name = "Veggie Name")]
        public string? Name { get; set; }
        [Required]
        public int? Weight { get; set; }
        [Required]
        public string? Size { get; set; }
        [Required]
        public int? Value { get; set; }
    }
}
