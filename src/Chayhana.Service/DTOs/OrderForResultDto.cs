using Chayhana.Domain.Enums;

namespace Chayhana.Service.DTOs;

public class OrderForResultDto
{
    public int Id { get; set; }
    public MealForResultDto Meal { get; set; }
    public double Amount { get; set; }
    public decimal Money { get; set; }
    public OrderStatus Status { get; set; }
    public PaymentType Type { get; set; }
    public bool isPaid { get; set; }
}
