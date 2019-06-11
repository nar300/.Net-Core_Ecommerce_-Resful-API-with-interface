using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class ProductImpl : IProductRepository
    {
        private readonly EcomDbContext db;
        public ProductImpl(EcomDbContext _db)
        {
            db = _db;
        }

        public async Task<Product> CreateProduct(   Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            var Product = await db.Products.FindAsync(productId);
            if (Product == null) return null;
            db.Products.Remove(Product);
            await db.SaveChangesAsync();
            return Product;

        }

        public async Task<IEnumerable> GetallProducts()
        {
            var Product = await db.Products.ToListAsync();
            return Product;
        }

        public async Task<Product> GetProductByIid(int productId)
        {
            var Product = await db.Products.FindAsync(productId);
            return Product;
        }

        public async Task<Product> UpdateProduct(int productId, Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return product;
        }
    }
}
