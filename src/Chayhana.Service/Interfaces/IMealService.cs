using Chayhana.Domain.Configurations;
using Chayhana.Service.DTOs;

namespace Chayhana.Service.Interfaces;

public interface IMealService
{
    Task<MealForResultDto> AddAsync(MealForCreationDto dto);
    Task<MealForResultDto> ModifyAsync(int id, MealForCreationDto dto);
    Task<bool> RemoveAsync(int id);
    Task<MealForResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<MealForResultDto>> RetrieveAllAsync(PaginationParams @params, string searchString);
}
