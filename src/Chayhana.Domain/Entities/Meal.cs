﻿using Chayhana.Domain.Commons;
using Chayhana.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Chayhana.Domain.Entities;

public class Meal : Auditable
{
    [StringLength(30, MinimumLength = 2)]
    public string Name { get; set; }

    [StringLength(50, MinimumLength = 2)]
    public string Description { get; set; }
    public decimal Price { get; set; }
    public double TotalAmount { get; set; }
    public double TotalSoldAmount { get; set; }
    public double ToTalRemainingAmount { get; set; }
    public decimal TotalMoneyOfSoldMeal { get; set; }
    public CategoryType Type { get; set; }

    public ICollection<Order> Oredrs { get; set; }
}
