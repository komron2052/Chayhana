using Chayhana.Domain.Entities;
using Chayhana.Domain.Enums;

namespace Chayhana.Service.DTOs;

public class OrderForCreationDto
{
    public int MealId { get; set; }
    public double Amount { get; set; }
    public decimal Money { get; set; }
    public PaymentType Type { get; set; }
}
