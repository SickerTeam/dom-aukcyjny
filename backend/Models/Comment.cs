﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    public string Text { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Post Post { get; set; }

    public virtual User User { get; set; }
}