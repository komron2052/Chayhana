using Chayhana.Domain.Commons;
using Chayhana.Domain.Enums;

namespace Chayhana.Domain.Entities;

public class SoldMeal : Auditable
{
    public int MealId { get; set; }
    public Meal Meal { get; set; }
    public double SoldAmount { get; set; }
    public decimal Money { get; set; }
}
