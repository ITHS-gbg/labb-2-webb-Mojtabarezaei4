﻿using BonsaiTreeShop.DataAccess.Commands;
using BonsaiTreeShop.DataAccess.Model;
using BonsaiTreeShop.DataAccess.Repositories.Interfaces;
using BonsaiTreeShop.Shared.DTOs;
using MediatR;

namespace BonsaiTreeShop.DataAccess.Handlers;

public class AddProductHandler: IRequestHandler<AddProductCommand, ProductDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddProductHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ProductDto?> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new ProductDto(
            Name : request.ProductDto.Name,
            Description : request.ProductDto.Description,
            Price : request.ProductDto.Price,
            Image : request.ProductDto.Image,
            Category: request.ProductDto.Category
        );
        //var product = new ProductDto()
        //{
        //    Name = request.ProductDto.Name,
        //    Description = request.ProductDto.Description,
        //    Price = request.ProductDto.Price,
        //    Image = request.ProductDto.Image,
        //    Category = request.ProductDto.Category
        //};

        if (product is null) return null;
        
        await _unitOfWork.ProductRepository.AddAsync(product);
        await _unitOfWork.CompleteAsync();
        return product;
    }
}