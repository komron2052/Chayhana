using Chayhana.Domain.Entities;
using Chayhana.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Chayhana.Service.DTOs;

public class MealForResultDto
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public double TotalAmount { get; set; }
    public double TotalSoldAmount { get; set; }
    public double ToTalRemainingAmount { get; set; }
    public decimal TotalMoneyOfSoldMeal { get; set; }
    public CategoryType Type { get; set; }

    public ICollection<Order> SoldMeals { get; set; }
}
