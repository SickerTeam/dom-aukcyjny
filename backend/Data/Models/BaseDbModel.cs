using System.ComponentModel.DataAnnotations;

namespace backend.Data.Models
{
    public abstract class BaseDbModel
    {
        [Key] 
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
