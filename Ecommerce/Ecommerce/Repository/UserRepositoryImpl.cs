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
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly EcomDbContext context;

        public UserRepositoryImpl(EcomDbContext context)
        {
            this.context = context;
        }
        public async Task<User> AddtoCart(int userId, int productId)
        {
            //Getuser by ID
            var user = await context.Users.FirstOrDefaultAsync(x => x.id == userId);

            if (user == null)
            {

                return null;
            }
            else
            {
                //Create new cart and push into users cartlist

                var cart = new Cart() { ProductId = productId, Quantity = 1 };
                var carts = user.Cart;

                carts.Add(cart);
                //push cart into userlist
                user.Cart = carts;
                context.Users.Update(user);

                //context.Entry(user).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return user;
            }

            }

       
    }
    }

