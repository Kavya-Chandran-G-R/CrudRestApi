using CrudRestApi.DAL;
using CrudRestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _context.Products.ToList();
                if (products.Count == 0)
                {
                    return NotFound("Product not available");

                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {

                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product details not found with id {id}");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public IActionResult Post(Product model)
        {
            try
            {
                var product = new Product()

                {
                    Id =new Guid(),
                    ProductName = model.ProductName,
                    Price= model.Price,
                    Qty = model.Qty

                };
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Product Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public IActionResult Put(Product model)
        {
            
                if (model == null)
                {
                    return BadRequest("Model data is invalid");
                }
                else if (model.Id == Guid.Empty)
                {
                    return BadRequest($"Product Id {model.Id} is invalid");
                }
          
            try
            {
                var product = _context.Products.Find(model.Id);
                if (product == null)
                {
                    return NotFound($"Product not found with id {model.Id} ");
                }
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Qty = model.Qty;
                _context.SaveChanges();
                return Ok("Product details updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product not found with id {id} ");
                }
                _context.Products.Remove(product);

                _context.SaveChanges();
                return Ok("Product details deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
