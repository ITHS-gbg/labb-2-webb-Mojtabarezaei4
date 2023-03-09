﻿using BonsaiTreeShop.DataAccess.Data;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BonsaiTreeShop.DataAccess.Repositories;

public class OrderRepository: IRepository<Order>
{
    private readonly DataContext _dataContext;

    public OrderRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _dataContext.Orders.ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(object id)
    {
        var order = await _dataContext.Orders.FirstOrDefaultAsync(o => o.Id == (Guid)id);
        return order ?? null;
    }

    public async Task<Order?> AddAsync(Order order)
    {
        await _dataContext.Orders.AddAsync(order);
        return order;
    }

    public async Task<Order?> UpdateAsync(Order order, object id)
    {
        var existingOrder = await _dataContext.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
        
        if (existingOrder is null) return null;

        _dataContext.Orders.Update(existingOrder);
        
        return order;
    }

    public async Task<Order?> DeleteByIdAsync(object id)
    {
        var existingOrder = await _dataContext.Orders.FirstOrDefaultAsync(o => o.Id == (Guid)id);

        if (existingOrder is null) return null;

        _dataContext.Orders.Remove(existingOrder);
        return existingOrder;
    }
}