using Ecommerce.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
  public  interface ICategoryRepository
    {
        Task<IEnumerable> GetAllCategory();
        Task<Category> CreateCategory(Category category);
        Task<Category> GetbyId(int categoryId);
        Task<Category> UpdateCategory(int categoryId, Category category);
        Task<Category> DeleteCategory(int categoryId);
    }
}
