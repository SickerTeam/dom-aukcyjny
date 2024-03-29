﻿#nullable disable

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class CommentDTO(int id, DateTime? createdAt)
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; private set; } = id;

        public DateTime? CreatedAt { get; private set; } = createdAt;

        [Required]
        [Range(1, int.MaxValue)]
        public int PostId { get; set; }

        [Required]
        [StringLength(1023, ErrorMessage = "Text cannot exceed 1023 characters.")]
        public string Text { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
    }
}
