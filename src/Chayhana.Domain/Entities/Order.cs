using Chayhana.Domain.Commons;
using Chayhana.Domain.Enums;

namespace Chayhana.Domain.Entities;

public class Order : Auditable
{
    public int MealId { get; set; }
    public Meal Meal { get; set; }
    public double Amount { get; set; }
    public decimal Money { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.panding;
    public PaymentType Type { get; set; }
    public bool isPaid { get; set; }    
}
