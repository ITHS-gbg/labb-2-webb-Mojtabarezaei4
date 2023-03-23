using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
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
        var orders = await _dataContext.Orders.ToListAsync();
        var orderDtos = orders.Select(ConvertToDto).ToList();
        return orderDtos;
    }

    public async Task<OrderDto?> GetByIdAsync(object id)
    {
        var order = await _dataContext.Orders.FirstOrDefaultAsync(o => o.Id == (Guid)id);
        if (order is null) return null;
        return ConvertToDto(order);
    }

    public async Task<OrderDto?> AddAsync(OrderDto orderDto)
    {
        await _dataContext.Orders.AddAsync(ConvertToModel(orderDto));
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

        return ConvertToDto(existingOrder);
    }

    private Order ConvertToModel(OrderDto orderDto)
    {
        var order = new Order()
        {
            ShipAddress = orderDto.ShipAddress,
            CreatedAt = orderDto.CreatedAt,
            UserId = orderDto.UserId
        };

        return order;
    }
    private OrderDto ConvertToDto(Order order)
    {
        var orderDto = new OrderDto(order.ShipAddress,
            order.CreatedAt, 
            new OrderDetailsDto(
                order.OrderDetails.Select(od => 
                    new ProductDto(od.Product.Name, od.Product.Description,
                        od.Product.Price, od.Product.Image, od.Product.Category)), 
                order.OrderDetails.Sum(od => od.Quantity)),  
            order.UserId);
        

        return orderDto;
    }
}