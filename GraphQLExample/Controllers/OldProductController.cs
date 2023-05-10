using GraphQLExample.Data;
using GraphQLExample.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraphQLExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OldProductController : ControllerBase
    {
        #region Old
        private readonly DB _db;

        public OldProductController(DB db)
        {
            _db = db;
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var produts = await _db.Products.ToListAsync();
            return Ok(produts);
        }

        [HttpGet("getBrands")]
        public async Task<IActionResult> GetBrands()
        {
            var brs = await _db.Brands.ToListAsync();
            return Ok(brs);
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            for (int i = 0; i < 15; i++)
            {
                var brand = new Brand()
                {
                    Name = Guid.NewGuid().ToString(),
                };
                await _db.Brands.AddAsync(brand);
                await _db.SaveChangesAsync();
            }


            for (int i = 0; i < 50; i++)
            {
                var brid = new Random().Next(1, 15);
                var pr = new Product()
                {
                    Barcode = $"Barcode {i}",
                    CreateTime = DateTime.Now,
                    Description = $"Description {i}",
                    IsActive = true,
                    IsDeleted = false,
                    IsShowCase = true,
                    ModifiedTime = DateTime.Now,
                    PaidPrice = i,
                    Price = i + 1,
                    ShortDescr = $"Short Description {i}",
                    Stock = i,
                    Title = $"Title {i}",
                    BrandId = brid
                };
                await _db.Products.AddAsync(pr);
                await _db.SaveChangesAsync();
            }
            return Ok();
        }
        #endregion

    }
}
