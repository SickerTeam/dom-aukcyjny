using backend.Data.Models;

namespace backend.Data.Models
{
    public class DbProduct : BaseDbModel
    {
        public double Height { get; set; }

        public double Width { get; set; }

        public double Depth { get; set; }

        public double Weight { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Artist { get; set; }
    }
}
