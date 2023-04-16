using Chayhana.Domain.Commons;
using Chayhana.Domain.Enums;

namespace Chayhana.Domain.Entities;

public class Meal : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
    public decimal Count { get; set; }
    public CategoryType Type { get; set; }
}
