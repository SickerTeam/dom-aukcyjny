using System.ComponentModel.DataAnnotations;
using backend.Models;

namespace backend.DTOs
{
    public class ProductCreationDTO
    {
        [Required]
        public double Height { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public double Depth { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Artist { get; set; }
        
        public int SellerId { get; set; } // set default value to cureent user id
    }
}
