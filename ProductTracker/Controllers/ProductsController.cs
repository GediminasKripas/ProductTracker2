using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductTracker.Models;

namespace ProductTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;

            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product
                {
                    id = 1,
                    itemName = "Coca-cola",
                    price = 0.89,
                    kCal = 201
                });

                _context.Products.Add(new Product
                {
                    id = 2,
                    itemName = "Pepsi",
                    price = 0.89,
                    url = "https://www.pepsi.com/en-us/uploads/images/twil-can.png"
                });

                _context.Products.Add(new Product
                {
                    id = 3,
                    itemName = "Fanta",
                    price = 0.89
                });

                _context.SaveChanges();
            }

        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetTodoItems()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(long id, Product product)
        {

            if (product.id == 0)
            {
                product.id = id;
            }

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

            return product;
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProduct", new { id = product.id }, product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchProduct(long id, [FromBody] JsonPatchDocument<Product> patchProduct)
        {

            var fromDb = _context.Products.FirstOrDefault(x => x.id == id);
            patchProduct.ApplyTo(fromDb, ModelState);

            var isValid = TryValidateModel(fromDb);

            if (!isValid)
            {
                return BadRequest();
            }

            _context.Update(fromDb);
            _context.SaveChanges();


            return Ok(fromDb);
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.id == id);
        }
    }
}
