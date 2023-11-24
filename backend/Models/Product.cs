namespace backend.Models
{
    public class Product
    {
        public Product(string title, string description, float height, float width, float depth, float weight)
        {
            this.title = title;
            this.description = description;
            this.height = height;
            this.width = width;
            this.depth = depth;
            this.weight = weight;
        }

        private string title {  get; set; }
        private string description { get; set; }
        private float height { get; set; }
        private float width { get; set; }
        private float depth { get; set; }
        private float weight { get; set; }
    }
}
