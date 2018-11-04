using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Domain;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        private IRepository<Products> _repository;

        public ProductService(IRepository<Products> repository)
        {
            _repository = repository;
        }
        public Task Create(Products products)
        {
            return _repository.Insert(products);
        }

        public Task Delete(Products products)
        {
            return _repository.Delete(products);
        }

        public Task<Products> GetById(int Id)
        {
            return _repository.Get(Id);
        }

        public Task<IEnumerable<Products>> List()
        {
            return _repository.GetAll();
        }

        public Task Update(Products products)
        {
            return _repository.Update(products);
        }
    }
}
