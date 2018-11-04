using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Factories
{
    public class ProductModelFactory : IProductModelFactory
    {
        private readonly IProductService _productService;
        public ProductModelFactory(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductModel> PrepareProductAsync(int id)
        {
            var Product = await _productService.GetById(id);
            return new ProductModel()
            {
                Id = Product.Id,
                Name = Product.Name,
                CreatedDate = Product.CreatedDate,
                LastUpdatedDate = Product.LastUpdatedDate
            };
        }

        public async Task<IEnumerable<ProductModel>> PrepareProductListAsync()
        {
            var Products = await _productService.List();
            return Products.Select(p => new ProductModel()
            {
                Id = p.Id,
                Name = p.Name,
                CreatedDate = p.CreatedDate,
                LastUpdatedDate = p.LastUpdatedDate
            });
        }
    }
}
