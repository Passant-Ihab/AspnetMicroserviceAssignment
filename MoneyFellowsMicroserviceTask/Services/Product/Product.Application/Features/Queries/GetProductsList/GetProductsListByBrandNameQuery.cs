﻿using MediatR;

namespace Products.Application.Features.Queries.GetProductsList
{
    public class GetProductsListByBrandNameQuery(string brandName) : IRequest<List<ProductsDTO>>
    {
        public string BrandName { get; set; } = brandName ?? throw new ArgumentNullException(nameof(brandName));
    }
}