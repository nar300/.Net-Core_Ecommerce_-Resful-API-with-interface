using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCartController : ControllerBase
    {
        private readonly IUserRepository repo;

        public UserCartController(IUserRepository repo)
        {
            this.repo = repo;
        }

       

        [HttpPut("{id}")]
        public async Task<IActionResult> AddtoCart(int id ,int productId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var user = await repo.AddtoCart(id, productId);
            if(user == null)
            {
                return BadRequest("user not found ");
            }
            return Ok(user);

        }

    }
}