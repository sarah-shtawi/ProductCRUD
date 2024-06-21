using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCRUD.Models;
using System.Data;

namespace ProductCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1,Name= "Product 1" ,Description="This is product one" },
            new Product { Id = 2,Name= "Product 2" ,Description="This is product two" },
            new Product { Id = 3,Name= "Product 3" ,Description= "This is product three" }
        };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductByID(int id)
        {
            var product = products.FirstOrDefault(pro =>  pro.Id == id);
            if (product is null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add (Product Request)
        {
            if (Request == null)
                return BadRequest();
            var product = new Product
            {
                Id = Request.Id,
                Name = Request.Name,
                Description = Request.Description,
            };
            products.Add(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id , Product Request )
        {
            var productCurrent = products.FirstOrDefault(pro => pro.Id == id);
            if (productCurrent is null)
                return NotFound();
           
            productCurrent.Name = Request.Name;
            productCurrent.Description = Request.Description;
          
            return Ok(productCurrent);
        }

        [HttpDelete("{id}")]
        public IActionResult actionResult(int id)
        {
            var Product = products.FirstOrDefault(p => p.Id == id);
            if(Product is null)
                return NotFound();
            products.Remove(Product);
            return Ok();
        }


    }
}
