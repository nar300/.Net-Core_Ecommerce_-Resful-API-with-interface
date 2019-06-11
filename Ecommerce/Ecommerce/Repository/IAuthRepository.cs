using Ecommerce.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public interface IAuthRepository
    {
        
        Task<User> RegisterUser(User user);
        Task<User> LoginUser(string email,string password);
        Task<bool> isUserExist(string email);
        Task<IEnumerable> GetallUsers();
    }
}
