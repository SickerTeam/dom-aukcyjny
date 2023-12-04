﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Auction
{
    public int? Id { get; set; }

    public DateTime? EndsAt { get; set; }

    public decimal? FirstPrice { get; set; }

    public Product Product { get; set; }

    public decimal? EstimatedMinimum { get; set; }

    public decimal? EstimatedMaximum { get; set; }

    public bool? IsArchived { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<AuctionPurchase> AuctionPurchases { get; set; } = new List<AuctionPurchase>();

    public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();
}