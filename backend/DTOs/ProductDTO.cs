using System;
using System.Collections.Generic;

namespace backend.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    public decimal? Height { get; set; }

    public decimal? Width { get; set; }

    public decimal? Depth { get; set; }

    public decimal? Weight { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public virtual UserDTO Artist { get; set; }
}