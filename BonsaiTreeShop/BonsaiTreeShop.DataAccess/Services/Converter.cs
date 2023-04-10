using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.Shared.DTOs;

namespace BonsaiTreeShop.DataAccess.Services;

public static class Converter
{
    public static Order ConvertToOrderModel(OrderDto orderDto)
    {
        var order = new Order()
        {
            ShipAddress = orderDto.ShipAddress,
            CreatedAt = orderDto.CreatedAt,
            UserId = orderDto.UserId,
            OrderDetails = orderDto.OrderDetails.Select(ConvertToOrderDetailModel).ToList(),
        };

        return order;
    }

    public static OrderDetail ConvertToOrderDetailModel(OrderDetailsDto orderDetailsDto)
    {
        var orderDetails = new OrderDetail()
        {
            ProductId = orderDetailsDto.ProductId,
            Quantity = orderDetailsDto.Quantity
        };

        return orderDetails;
    }

    public static Product ConvertToProductModel(ProductDto productDto)
    {
        var product = new Product()
        {
            Name = productDto.Name,
            Category = productDto.Category,
            Description = productDto.Description,
            Image = productDto.Image,
            Price = productDto.Price,
            IsInStock = productDto.IsInStock,
        };

        return product;
    }

    public static OrderDto ConvertToOrderDto(Order order)
    {
        var orderDto = new OrderDto()
        {
            ShipAddress = order.ShipAddress,
            CreatedAt = order.CreatedAt,
            OrderDetails = order.OrderDetails.Select(ConvertToOrderDetailsDto).ToList(),
            UserId = order.UserId
        };

        return orderDto;
    }

    public static OrderDetailsDto ConvertToOrderDetailsDto(OrderDetail orderDetail)
    {
        var orderDetailsDto = new OrderDetailsDto()
        {
            ProductId = orderDetail.ProductId, 
            Quantity = orderDetail.Quantity
        };

        return orderDetailsDto;
    }

    public static ProductDto ConvertToProductDto(Product product)
    {
        var productDto = new ProductDto()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Image = product.Image,
            Category = product.Category,
            IsInStock = product.IsInStock
        };

        return productDto;
    }

    public static UserDto ConvertToUserDto(User user)
    {
        var userDto = new UserDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address
        };

        return userDto;
    }

    public static User ConvertToUser(UserDto userDto)
    {
        var newUser = new User()
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            PhoneNumber = userDto.PhoneNumber,
            Address = userDto.Address ?? ""
        };

        return newUser;
    }
    
}