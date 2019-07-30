using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PizzaApp.Models;
using PizzaEntities;

namespace PizzaApp.Controllers
{
    public class PizzasController : Controller
    {
        private readonly PizzaAppContext _context;
        private AppSettings _appSettings;

        public PizzasController(PizzaAppContext context, IOptions<AppSettings> settings)
        {
            _context = context;
            _appSettings = settings.Value;
        }

        // GET: Pizzas
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Pizza.ToListAsync());

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync(_appSettings.APIUrl + "api/Pizzas");
            var res = stringTask.Result;

            List<Pizza> pizzas = JsonConvert.DeserializeObject<List<Pizza>>(res);
            ViewData["url"] = _appSettings.APIUrl;

            return View("Create");
        }

        // GET: Pizzas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza
                .FirstOrDefaultAsync(m => m.id == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // GET: Pizzas/Create
        public IActionResult Create()
        {
            ViewData["id"] = RandomNumbers.GenerateRandomId();
            ViewData["OrderId"] = RandomNumbers.GenerateRandomId();
            ViewData["url"] = _appSettings.APIUrl;
            return View();
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,OrderId,size,sauce,crust")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(pizza);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));


                await client.PostAsync(_appSettings.APIUrl + "api/pizzas", new JsonContent(pizza));

               // localStorage.setItem("orderId", pizza.OrderId);
            }
            return View(pizza);
        }

        // GET: Pizzas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,OrderId,size,sauce,crust")] Pizza pizza)
        {
            if (id != pizza.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaExists(pizza.id))
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
            return View(pizza);
        }

        // GET: Pizzas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var pizza = await _context.Pizza
            //    .FirstOrDefaultAsync(m => m.id == id);
            
            var pizza = new Pizza();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            
            var stringTask = client.GetStringAsync(_appSettings.APIUrl + "api/Pizzas/" + id);
            var res = stringTask.Result;

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(res));
            var ser = new DataContractJsonSerializer(pizza.GetType());
            pizza = ser.ReadObject(ms) as Pizza;


            await client.DeleteAsync($"{_appSettings.APIUrl}api/pizzas/{id}");
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var pizza = await _context.Pizza.FindAsync(id);
            //_context.Pizza.Remove(pizza);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaExists(int id)
        {
            return _context.Pizza.Any(e => e.id == id);
        }
    }

}
