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
    public class CustomersController : Controller
    {
        private readonly PizzaAppContext _context;


        private AppSettings _appSettings;

        public CustomersController(PizzaAppContext context, IOptions<AppSettings> settings)
        {
            _context = context;
            _appSettings = settings.Value;

        }

        public IActionResult Login()
        {
            ViewData["url"] = _appSettings.APIUrl;

            return View("Login");
        }


        // GET: Customers 
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Customer.ToListAsync());
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync(_appSettings.APIUrl + "api/Customers");
            var res = stringTask.Result;

            List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(res);
            ViewData["url"] = _appSettings.APIUrl;
            // return View(customers);
            return View("Get");
        }

        // GET: Customers/Details/5 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var customer = await _context.Customer
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (customer == null)
            //{
            //    return NotFound();
            //}

            //return View(customer);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync(_appSettings.APIUrl + "api/Customers/" + id);
            var res = stringTask.Result;

            var customer = new Customer();
            //var json = JsonConvert.DeserializeObject(res);
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(res));
            var ser = new DataContractJsonSerializer(customer.GetType());
            customer = ser.ReadObject(ms) as Customer;
            ms.Close();
            ViewData["url"] = _appSettings.APIUrl;
            //return View(customer);
            return View("GetOne");
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["id"] = RandomNumbers.GenerateRandomId();
            ViewData["url"] = _appSettings.APIUrl;

            return View("Register");
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,firstName,lastName,address,phoneNumber,creditCardNumber,expDate,cvc,email,password")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(customer);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

                


            

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));


                await client.PostAsync(_appSettings.APIUrl + "api/customers", new JsonContent(customer));



                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var customer = await _context.Customer.FindAsync(id);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync(_appSettings.APIUrl+"api/Customers/" + id);
            var res = stringTask.Result;

            var customer = new Customer();
            //var json = JsonConvert.DeserializeObject(res);
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(res));
            var ser = new DataContractJsonSerializer(customer.GetType());
            customer = ser.ReadObject(ms) as Customer;
            ms.Close();
            ViewData["url"] = _appSettings.APIUrl;


            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,firstName,lastName,address,phoneNumber,creditCardNumber,expDate,cvc,email,password")] Customer customer)
        {
            if (id != customer.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   // _context.Update(customer);
                    //await _context.SaveChangesAsync();

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));


                    await client.PutAsync(_appSettings.APIUrl+"api/Customers/" + id, new JsonContent(customer));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var customer = await _context.Customer
            //    .FirstOrDefaultAsync(m => m.id == id);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync(_appSettings.APIUrl+"api/Customers/" + id);
            var res = stringTask.Result;

            var customer = new Customer();
            //var json = JsonConvert.DeserializeObject(res);
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(res));
            var ser = new DataContractJsonSerializer(customer.GetType());
            customer = ser.ReadObject(ms) as Customer;
            ms.Close();
            ViewData["url"] = _appSettings.APIUrl;

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var customer = await _context.Customer.FindAsync(id);
            //_context.Customer.Remove(customer);
            //await _context.SaveChangesAsync();


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = await client.DeleteAsync(_appSettings.APIUrl+"api/Customers/" + id);

            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.id == id);
        }


    }
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        { }
    }

    public static class RandomNumbers
    {
        public static Random rand;
        static RandomNumbers()
        {
            rand = new Random();
        }
        public static int GenerateRandomId()
        {
            return rand.Next();
        }
    }
}
