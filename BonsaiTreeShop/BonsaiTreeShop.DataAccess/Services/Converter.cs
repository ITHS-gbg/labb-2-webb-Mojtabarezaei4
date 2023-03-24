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
            Price = productDto.Price
        };

        return product;
    }

    public static OrderDto ConvertToOrderDto(Order order)
    {
        var orderDto = new OrderDto(order.ShipAddress,
            order.CreatedAt,
            order.OrderDetails.Select(ConvertToOrderDetailsDto).ToList(),
            order.UserId);

        return orderDto;
    }

    public static OrderDetailsDto ConvertToOrderDetailsDto(OrderDetail orderDetail)
    {
        var orderDetailsDto = new OrderDetailsDto(orderDetail.ProductId, orderDetail.Quantity);

        return orderDetailsDto;
    }

    public static ProductDto ConvertToProductDto(Product product)
    {
        var productDto = new ProductDto(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Image,
            product.Category);

        return productDto;
    }

    public static UserDto ConvertToUserDto(User user)
    {
        var userDto = new UserDto(
            user.FirstName,
            user.LastName,
            user.Email!,
            user.PhoneNumber,
            user.Address
        );

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