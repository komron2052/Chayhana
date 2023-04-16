using Chayhana.Domain.Configurations;
using Chayhana.Service.DTOs;
using Chayhana.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chayhana.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersConroller : ControllerBase
{
    private readonly IOrderService orderService;

    public OrdersConroller(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(OrderForCreationDto dto) =>
        Ok(await orderService.AddAsync(dto));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id) =>
        Ok(await orderService.RetrieveByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult> GetAllAsync([FromQuery] PaginationParams @params, string searchString) =>
        Ok(await orderService.RetrieveAllAsync(@params, searchString));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id) =>
    Ok(await orderService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute] int id, OrderForCreationDto dto) =>
    Ok(await orderService.ModifyAsync(id, dto));
}
