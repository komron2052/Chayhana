using Chayhana.Domain.Commons;
using Chayhana.Domain.Enums;

namespace Chayhana.Domain.Entities;

public class Meal : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public double TotalAmount { get; set; }
    public double TotalSoldAmount { get; set; }
    public double ToTalRemainingAmount { get; set; }
    public decimal TotalMoneyOfSoldMeal { get; set; }
    public CategoryType Type { get; set; }

    public ICollection<SoldMeal> SoldMeals { get; set; }
}
