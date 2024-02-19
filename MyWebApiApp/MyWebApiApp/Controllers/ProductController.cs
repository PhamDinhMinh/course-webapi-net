using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
            //LINQ [Object] Query
            var product = products.SingleOrDefault(p => p.id == Guid.Parse(id));
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost] 
        public IActionResult Create(ProductVM productVM)
        {
            var product = new Product
            {
                id = Guid.NewGuid(),
                NameHH = productVM.NameHH,
                Price = productVM.Price,
            };
            products.Add(product);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(String id, ProductVM productVM)
        {
            try
            {
                //LINQ [Object] Query
                var product = products.SingleOrDefault(p => p.id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                if(id != product.id.ToString())
                {
                    return BadRequest();
                }
                product.NameHH = productVM.NameHH;
                product.Price = productVM.Price;
                return Ok(product);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            try
            {
                //LINQ [Object] Query
                var product = products.SingleOrDefault(p => p.id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                products.Remove(product);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
