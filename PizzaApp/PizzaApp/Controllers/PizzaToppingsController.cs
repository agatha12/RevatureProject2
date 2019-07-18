using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;
using PizzaEntities;

namespace PizzaApp.Controllers
{
    public class PizzaToppingsController : Controller
    {
        private readonly PizzaAppContext _context;

        public PizzaToppingsController(PizzaAppContext context)
        {
            _context = context;
        }

        // GET: PizzaToppings
        public async Task<IActionResult> Index()
        {
            return View(await _context.PizzaTopping.ToListAsync());
        }

        // GET: PizzaToppings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaTopping = await _context.PizzaTopping
                .FirstOrDefaultAsync(m => m.id == id);
            if (pizzaTopping == null)
            {
                return NotFound();
            }

            return View(pizzaTopping);
        }

        // GET: PizzaToppings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PizzaToppings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,pizzaId,toppingId")] PizzaTopping pizzaTopping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizzaTopping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pizzaTopping);
        }

        // GET: PizzaToppings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaTopping = await _context.PizzaTopping.FindAsync(id);
            if (pizzaTopping == null)
            {
                return NotFound();
            }
            return View(pizzaTopping);
        }

        // POST: PizzaToppings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,pizzaId,toppingId")] PizzaTopping pizzaTopping)
        {
            if (id != pizzaTopping.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizzaTopping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaToppingExists(pizzaTopping.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pizzaTopping);
        }

        // GET: PizzaToppings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaTopping = await _context.PizzaTopping
                .FirstOrDefaultAsync(m => m.id == id);
            if (pizzaTopping == null)
            {
                return NotFound();
            }

            return View(pizzaTopping);
        }

        // POST: PizzaToppings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizzaTopping = await _context.PizzaTopping.FindAsync(id);
            _context.PizzaTopping.Remove(pizzaTopping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaToppingExists(int id)
        {
            return _context.PizzaTopping.Any(e => e.id == id);
        }
    }
}
