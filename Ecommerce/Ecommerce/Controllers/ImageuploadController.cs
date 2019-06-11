using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageuploadController : ControllerBase
    {
        EcomDbContext db;
        private readonly IHostingEnvironment _host;

        public ImageuploadController(EcomDbContext co, IHostingEnvironment hostingEnvironment)
        {
            db = co;
            _host = hostingEnvironment;
        }
        public async Task<IActionResult> Imageupload(IFormFile file)
        {
            var filepath = Path.Combine(_host.WebRootPath, "Images", file.FileName);
            var stream = new FileStream(filepath, FileMode.Create);

            await file.CopyToAsync(stream);


            return Ok(new { path = file.FileName });
        }
    }
}