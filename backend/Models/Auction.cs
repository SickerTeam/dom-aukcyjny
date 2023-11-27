﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class auction
{
    public int auctionid { get; set; }

    public DateTime? endtime { get; set; }

    public int? firstprice { get; set; }

    public int? productid { get; set; }

    public float? estimatedminimum { get; set; }

    public float? estimatedmaximum { get; set; }

    public bool? archived { get; set; }

    public virtual ICollection<auctionpurchase> auctionpurchases { get; set; } = new List<auctionpurchase>();

    public virtual ICollection<bid> bids { get; set; } = new List<bid>();

    public virtual product product { get; set; }
}