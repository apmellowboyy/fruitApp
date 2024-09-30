using System.ComponentModel.DataAnnotations;

namespace bruhBruh.Models
{
    public class Fruits
    {
        
        public string? Name { get; set; }
        [Required]
        [Key]
        public string? Color { get; set; }
        [Required]
        public string? Size { get; set; }
        [Required]
        public int? Value  { get; set; }
    }
}
