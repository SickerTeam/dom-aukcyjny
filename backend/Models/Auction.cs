namespace backend.Models
{
    public class Auction : Listing
    {
        public Auction(double minPrice, double minEstimate, double maxEstimate, DateTime deadline)
        {
            this.minPrice = minPrice;
            this.minEstimate = minEstimate;
            this.maxEstimate = maxEstimate;
            this.deadline = deadline;
        }

        private double minPrice { get; set; }
        private double minEstimate { get; set; }
        private double maxEstimate { get; set; }
        private DateTime deadline {  get; set; }
    }
}
