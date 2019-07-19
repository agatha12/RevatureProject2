using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;
using PizzaEntities;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingsController : ControllerBase
    {
        private readonly PizzaAppContext _context;

        public ToppingsController(PizzaAppContext context)
        {
            _context = context;
        }

        // GET: api/Toppings
        [HttpGet]
        public IEnumerable<Topping> GetToppings()
        {
            return _context.Toppings;
        }

        // GET: api/Toppings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopping([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var topping = await _context.Toppings.FindAsync(id);

            if (topping == null)
            {
                return NotFound();
            }

            return Ok(topping);
        }

        // PUT: api/Toppings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopping([FromRoute] int id, [FromBody] Topping topping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topping.id)
            {
                return BadRequest();
            }

            _context.Entry(topping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToppingExists(id))
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

        // POST: api/Toppings
        [HttpPost]
        public async Task<IActionResult> PostTopping([FromBody] Topping topping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Toppings.Add(topping);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ToppingExists(topping.id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTopping", new { id = topping.id }, topping);
        }

        // DELETE: api/Toppings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopping([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var topping = await _context.Toppings.FindAsync(id);
            if (topping == null)
            {
                return NotFound();
            }

            _context.Toppings.Remove(topping);
            await _context.SaveChangesAsync();

            return Ok(topping);
        }

        private bool ToppingExists(int id)
        {
            return _context.Toppings.Any(e => e.id == id);
        }
    }
}