using System.Net.Http.Headers;

namespace backend.Models
{
    public abstract class Listing
    {
        private double Price;
        private Product Product; 
        private bool IsArchived;
    }
}
