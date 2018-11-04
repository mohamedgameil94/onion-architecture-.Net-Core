using System;
using System.Collections.Generic;
using System.Text;
using Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Data.DomianMapping
{
    public class ProductsMap
    {
        public ProductsMap(EntityTypeBuilder<Products> entityBuilder)
        {
           
            entityBuilder.HasKey(p => p.Id);
           
        }
    }
}
