using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.DataAccess.Services;
using BonsaiTreeShop.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BonsaiTreeShop.DataAccess.Repositories;

public class OrderRepository: IRepository<OrderDto>
{
    private readonly DataContext _dataContext;

    public OrderRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var orders = await _dataContext.Orders.Include("OrderDetails").ToListAsync();
        var orderDtos = orders.Select(Converter.ConvertToOrderDto).ToList();
        return orderDtos;
    }

    public async Task<OrderDto?> GetByIdAsync(object id)
    {
        var order = await _dataContext.Orders.Include("OrderDetails").FirstOrDefaultAsync(o => o.Id == (Guid)id);
        if (order is null) return null;
        return Converter.ConvertToOrderDto(order);
    }

    public async Task<OrderDto?> AddAsync(OrderDto orderDto)
    {
        await _dataContext.Orders.AddAsync(Converter.ConvertToOrderModel(orderDto));
        return orderDto;
    }

    public async Task<OrderDto?> UpdateAsync(OrderDto orderDto, object id)
    {
        var existingOrder = await _dataContext.Orders.FirstOrDefaultAsync(o => o.Id == (Guid)id);
        
        if (existingOrder is null) return null;

        _dataContext.Orders.Update(existingOrder);
        
        return orderDto;
    }

    public async Task<OrderDto?> DeleteByIdAsync(object id)
    {
        var existingOrder = await _dataContext.Orders.FirstOrDefaultAsync(o => o.Id == (Guid)id);

        if (existingOrder is null) return null;

        _dataContext.Orders.Remove(existingOrder);

        return Converter.ConvertToOrderDto(existingOrder);
    }
}