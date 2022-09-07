﻿using CleanArchMVC.Application.Products.Commands;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(_productRepository));
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
                throw new Exception("Entity cannot be found");

            var result = await _productRepository.RemoveAsync(product);
            return result;
        }
    }
}
