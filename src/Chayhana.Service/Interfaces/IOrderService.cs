using Chayhana.Domain.Configurations;
using Chayhana.Service.DTOs;

namespace Chayhana.Service.Interfaces;

public interface IOrderService
{
    Task<OrderForResultDto> AddAsync(OrderForCreationDto dto);
    Task<OrderForResultDto> ModifyAsync(int id, OrderForCreationDto dto);
    Task<bool> RemoveAsync(int id);
    Task<OrderForResultDto> RetrieveByIdAsync(int id);
    Task<IEnumerable<OrderForResultDto>> RetrieveAllAsync(PaginationParams @params, string searchString);
}
