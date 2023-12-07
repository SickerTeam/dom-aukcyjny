#nullable disable

namespace backend.Models;

public class InstaBuy
{
    public int? Id { get; set; }

    public decimal Price { get; set; }

    public bool? IsArchived { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<InstaBuyPurchase> InstaBuyPurchases { get; set; } = new List<InstaBuyPurchase>();

    public virtual Product Product { get; set; }
}