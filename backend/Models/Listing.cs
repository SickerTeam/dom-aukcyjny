using System.Net.Http.Headers;

namespace backend.Models
{
    public abstract class Listing
    {
        private Product Product; 
        private bool IsArchived;
        private DateTime CreatedAt;
    }
}
