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
    public class AuthRepositoryImpl : IAuthRepository
        
    {
        private readonly EcomDbContext _context;
        public AuthRepositoryImpl(EcomDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable> GetallUsers()
        {
            var Users = await _context.Users.ToListAsync();
            return Users;
        }
        

        public async Task<bool> isUserExist(string email)
        {
           var uniqueuser= await _context.Users.AnyAsync(x => x.email == email);

            return uniqueuser;
        }

        public async Task<User> LoginUser(string email, string password)
        {
            var dbuser = await _context.Users.FirstOrDefaultAsync(x => x.email == email && x.password == password);

            return dbuser;

        }

        public async Task<User> RegisterUser(User user)
        {
            
            _context.Users.Add(user);
           await _context.SaveChangesAsync();
            return user;
        }
    }
}
