using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using UI.Factories;
using UI.Infrastructure;
using UI.Models;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        private readonly IProductModelFactory _productModelFactory;
        public ProductsController(
              IProductService productService,
             IProductModelFactory productModelFactory
            )
        {
            _productService = productService;
            _productModelFactory = productModelFactory;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductModel>> Get()
        {
            return await _productModelFactory.PrepareProductListAsync();
            
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ProductModel> Get(int id)
        {
            return await _productModelFactory.PrepareProductAsync(id);
        }

        // POST: api/Products
        [HttpPost]
        public async Task Post([FromBody] ProductModel model)
        {

            var entity = new Products()
            {
                Id = model.Id,
                Name = model.Name,
                CreatedDate = DateTime.UtcNow

            };
            await _productService.Create(entity);


        }

        // PUT: api/Products/5
        [HttpPut]
        public async Task Put([FromBody] ProductModel model)
        {
            var Product = await _productService.GetById(model.Id);
            Product.Name = model.Name;
            Product.LastUpdatedDate = DateTime.UtcNow;
            await _productService.Update(Product);

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var Product = await _productService.GetById(id);
            await _productService.Delete(Product);
        }
    }
}
