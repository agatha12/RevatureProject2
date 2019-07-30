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
    public class PizzaToppingsController : ControllerBase
    {
        private readonly PizzaAppContext _context;

        public PizzaToppingsController(PizzaAppContext context)
        {
            _context = context;
        }

        // GET: api/PizzaToppings
        [HttpGet]
        public IEnumerable<PizzaTopping> GetPizzaToppings()
        {
            return _context.PizzaToppings;
        }

        // GET: api/PizzaToppings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPizzaTopping([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pizzaTopping = await _context.PizzaToppings.FindAsync(id);

            if (pizzaTopping == null)
            {
                return NotFound();
            }

            return Ok(pizzaTopping);
        }

        // GetPizzaToppings by pizzaId
        [HttpGet]
        [Route("GetPizzaToppings/{pizzaId}")]
        public IEnumerable<PizzaTopping> getPizzaToppingsForCart([FromRoute] int pizzaId)
        {
            var toppingsInPizza = _context.PizzaToppings.Where(n => n.pizzaId == pizzaId);
            return toppingsInPizza;
        }

        // PUT: api/PizzaToppings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizzaTopping([FromRoute] int id, [FromBody] PizzaTopping pizzaTopping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pizzaTopping.id)
            {
                return BadRequest();
            }

            _context.Entry(pizzaTopping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaToppingExists(id))
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

        // POST: api/PizzaToppings
        [HttpPost]
        public async Task<IActionResult> PostPizzaTopping([FromBody] PizzaTopping pizzaTopping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PizzaToppings.Add(pizzaTopping);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PizzaToppingExists(pizzaTopping.id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPizzaTopping", new { id = pizzaTopping.id }, pizzaTopping);
        }

        // DELETE: api/PizzaToppings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizzaTopping([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pizzaTopping = await _context.PizzaToppings.FindAsync(id);
            if (pizzaTopping == null)
            {
                return NotFound();
            }

            _context.PizzaToppings.Remove(pizzaTopping);
            await _context.SaveChangesAsync();

            return Ok(pizzaTopping);
        }

        private bool PizzaToppingExists(int id)
        {
            return _context.PizzaToppings.Any(e => e.id == id);
        }
    }
}