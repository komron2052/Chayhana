using AutoMapper;
using Chayhana.Data.IRepositories;
using Chayhana.Domain.Configurations;
using Chayhana.Domain.Entities;
using Chayhana.Service.DTOs;
using Chayhana.Service.Exeptions;
using Chayhana.Service.Extensions;
using Chayhana.Service.Interfaces;

namespace Chayhana.Service.Services;

public class OrderService : IOrderService
{
    private readonly IRepository<Order> orderRepository;
    private readonly IMapper mapper;

    public OrderService(IRepository<Order> orderRepository, IMapper mapper)
    {
        this.orderRepository = orderRepository;
        this.mapper = mapper;
    }

    public async Task<OrderForResultDto> AddAsync(OrderForCreationDto dto)
    {
        var mappedOrder = this.mapper.Map<Order>(dto);
        var addedOrder = await this.orderRepository.InsertAsync(mappedOrder);
        addedOrder.CreatedAt = DateTime.UtcNow;

        await this.orderRepository.SaveAsync();

        return this.mapper.Map<OrderForResultDto>(addedOrder);
    }

    public async Task<IEnumerable<OrderForResultDto>> RetrieveAllAsync(PaginationParams @params, string searchString)
    {
        var orders = this.orderRepository.SelectAll(null, new string[] { "Meal" }, isTracking: false);

        orders = !string.IsNullOrEmpty(searchString) ?
                orders.Where(m => m.Meal.Name.Contains(searchString)
                || m.Meal.Description.Contains(searchString)).ToPagedList(@params)
                : orders.ToPagedList(@params);

        return this.mapper.Map<IEnumerable<OrderForResultDto>>(orders.ToList());
    }

    public async Task<OrderForResultDto> ModifyAsync(int id, OrderForCreationDto dto)
    {
        var order = await this.orderRepository.SelectAsync(o => o.Id == id);
        if (order == null)
            throw new CustomExeption(404, "Not found");

        var updatedOrder = this.mapper.Map(dto, order);

        await this.orderRepository.SaveAsync();

        return this.mapper.Map<OrderForResultDto>(updatedOrder);
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var order = await this.orderRepository.SelectAsync(o => o.Id == id);
        if (order == null)
            throw new CustomExeption(404, "Not found");

        await this.orderRepository.DeleteAsync(o => o.Id == id);

        await this.orderRepository.SaveAsync();

        return true;
    }

    public async Task<OrderForResultDto> RetrieveByIdAsync(int id)
    {
        var order = await this.orderRepository.SelectAsync(o => o.Id == id, new string[] { "Meal" });
        if (order == null)
            throw new CustomExeption(404, "Not found");

        return this.mapper.Map<OrderForResultDto>(order);
    }
}
