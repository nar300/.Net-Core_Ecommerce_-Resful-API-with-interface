using Ecommerce.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
   public interface IProductRepository
    {
        Task<IEnumerable> GetallProducts();
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProductByIid(int productId);
        Task<Product> UpdateProduct(int productId, Product product);
        Task<Product> DeleteProduct(int productId);
    }
}
