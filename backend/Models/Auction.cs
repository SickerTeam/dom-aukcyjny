﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Auction
{
    public int Id { get; set; }

    public DateTime? endtime { get; set; }

    public int? firstprice { get; set; }

    public int? productid { get; set; }

    public float? estimatedminimum { get; set; }

    public float? estimatedmaximum { get; set; }

    public bool? archived { get; set; }

    public virtual ICollection<AuctionPurchase> auctionpurchases { get; set; } = new List<AuctionPurchase>();

    public virtual ICollection<Bid> bids { get; set; } = new List<Bid>();

    public virtual Product product { get; set; }
}