using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Auth
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var Users = await _repo.GetallUsers();
            return Ok(Users);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _repo.isUserExist(user.email))
            {
                return BadRequest("user exists");
            }


            var myuser = await  _repo.RegisterUser(user);
            return Ok(myuser);
        }
        [HttpPost("login")]
        public async Task<IActionResult>Login(User user)
        {
            if (!ModelState.IsValid) return BadRequest();

            var users = await _repo.LoginUser(user.email, user.password);
            if(users == null)
            {
                return BadRequest("invalid credentials");
            }
            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",

                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
               


        }

    }
}