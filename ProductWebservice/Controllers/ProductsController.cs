using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductWebservice.Models;

namespace ProductWebservice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;

            if (!_context.products.Any())
            {
                _context.products.Add(new Product
                {
                    id = "1",
                    productName = "Coca-Cola 0.5",
                    price = 0.89,
                    date = "2022-01-02"
                });
                _context.products.Add(new Product
                {
                    id = "2",
                    productName = "Pepsi 0.5",
                    price = 0.89,
                    date = "2022-03-18"
                });
                _context.products.Add(new Product
                {
                    id = "3",
                    productName = "Fanta 0.5",
                    price = 0.89,
                    date = "2022-02-07"
                });
                _context.SaveChanges();
            }

        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Getproducts()
        {
            return await _context.products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _context.products.FindAsync(id);

            if (product == null)
            {
                return NotFound("Product does not exist!");
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(string id, Product product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.products.Add(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = product.id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(string id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(string id)
        {
            return _context.products.Any(e => e.id == id);
        }
    }
}
