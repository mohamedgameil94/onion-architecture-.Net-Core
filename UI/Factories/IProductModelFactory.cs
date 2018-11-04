using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Factories
{
    public interface IProductModelFactory
    {
        Task<IEnumerable<ProductModel>> PrepareProductListAsync();
        Task<ProductModel> PrepareProductAsync(int id);
    }
}
