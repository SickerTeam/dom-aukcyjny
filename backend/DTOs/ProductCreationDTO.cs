using backend.Models;

namespace backend.DTOs
{
    public class ProductCreationDTO
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double Depth { get; set; }

        public double Weight { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Artist { get; set; }
        
        public int SellerId { get; set; }
    }
}
