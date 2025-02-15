﻿using Domain.Common;

namespace Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public DateOnly ProduceDate { get; set; }
    public string ManufactureEmail { get; set; }
    public string ManufacturePhone { get; set; }
    public bool IsAvailable { get; set; }
    public string CreatedByUserId { get; set; }
}
