using Chayhana.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Chayhana.Service.DTOs;

public class MealForCreationDto
{
    [Required(ErrorMessage ="Name is requaried")]
    public string Name { get; set; }
    public string Description { get; set; }

    [Required(ErrorMessage = "Price is requaried")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Total amount is requaried")]
    public double TotalAmount { get; set; }

    [Required(ErrorMessage = "Type is requaried")]
    public CategoryType Type { get; set; }
}
