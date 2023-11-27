﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Product
{
    public int productid { get; set; }

    public float? height { get; set; }

    public float? widht { get; set; }

    public float? depth { get; set; }

    public float? weight { get; set; }

    public string title { get; set; }

    public string description { get; set; }

    public int? artisid { get; set; }

    public virtual User artis { get; set; }

    public virtual ICollection<Auction> auctions { get; set; } = new List<Auction>();
}