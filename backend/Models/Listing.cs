using System.Net.Http.Headers;

namespace backend.Models
{
    public abstract class Listing
    {
        private double price;
        private Product product; 
        private bool isArchived;
    }
}
