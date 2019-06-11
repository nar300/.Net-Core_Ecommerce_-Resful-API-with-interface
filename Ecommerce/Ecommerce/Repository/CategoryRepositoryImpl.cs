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
    public class CategoryRepositoryImpl : ICategoryRepository
    {
        private readonly EcomDbContext db;
        public CategoryRepositoryImpl(EcomDbContext _db)
        {
            db = _db;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteCategory(int categoryId)
        {
            var Cat = await db.Categories.FindAsync(categoryId);
            if (Cat == null) return null;

            db.Categories.Remove(Cat);
           await db.SaveChangesAsync();
            
            return Cat ;
         

        }

        public async Task<IEnumerable> GetAllCategory()
        {
            var Cat = await db.Categories.ToListAsync();
            
            return Cat;
        }

        public async Task<Category> GetbyId(int categoryId)
        {
            var Cat = await db.Categories.FindAsync(categoryId);

                return Cat;
        }

        public async Task<Category> UpdateCategory(int categoryId,Category category)
        {

            db.Entry(category).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return category;
            
        }

        //public Task<Category> UpdateCategory(Category category)
        //{
        //    throw new NotImplementedException();
        //}

        //void ICategoryRepository.CreateCategory(Category category)
        //{
        //    db.Categories.Add(category);
        //     db.SaveChangesAsync();
            
        //}
    }
}
