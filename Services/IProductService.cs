using Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public interface IProductService
    {
        Task Create(Products products);

        Task Update(Products products);

        Task Delete(Products products);

        Task<IEnumerable<Products>> List();

        Task<Products> GetById(int Id);


    }
}
