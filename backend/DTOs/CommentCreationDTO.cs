﻿#nullable disable

using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class CommentCreationDTO
    {
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
