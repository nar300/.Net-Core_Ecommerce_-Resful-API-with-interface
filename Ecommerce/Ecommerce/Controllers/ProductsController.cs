using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Controllers
{
   //[ Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var Product = await _repo.GetallProducts();
            return Ok(Product);
        }


        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _repo.GetProductByIid(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.productId)
            {
                return BadRequest();
            }

            await _repo.UpdateProduct(id, product);

            return Ok("product updated ");
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           await  _repo.CreateProduct(product);


            return CreatedAtAction("GetProduct", new { id = product.productId }, product);

        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _repo.DeleteProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            if (product == null) return NotFound("no product found with this id ");
            

            return Ok(product);
        }

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.productId == id);
        //}
    }
}