using Ecommerce.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
 public interface IUserRepository
    {
        Task<User> AddtoCart(int userId,int productId);
        

    }
}
