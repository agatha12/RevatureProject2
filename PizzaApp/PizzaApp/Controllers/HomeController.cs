using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using PizzaEntities;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using Microsoft.Extensions.Options;

namespace PizzaApp.Controllers
{
    public class HomeController : Controller
    {
        

        private AppSettings _appSettings;

        public HomeController(PizzaAppContext context, IOptions<AppSettings> settings)
        {
           
            _appSettings = settings.Value;

        }
        public IActionResult Index()
        {
            //var name = HttpContext.Session.GetString("Name");
            //var id = HttpContext.Session.GetInt32("id");
            //ViewData["Name"] = name;
            //ViewData["id"] = id;

            ViewData["url"] = _appSettings.APIUrl;

            return View();
        }

        public IActionResult Register(int id)
        {
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));

            //var stringTask = client.GetStringAsync(url + "api/Customers/" + id);
            //var res = stringTask.Result;

            //var customer = new Customer();
            ////var json = JsonConvert.DeserializeObject(res);
            //var ms = new MemoryStream(Encoding.UTF8.GetBytes(res));
            //var ser = new DataContractJsonSerializer(customer.GetType());
            //customer = ser.ReadObject(ms) as Customer;
            //ms.Close();

            //var name = customer.firstName;

            //HttpContext.Session.SetString("Name", name);
            //HttpContext.Session.SetInt32("id", id);
            //ViewData["Name"] = name;
            //ViewData["id"] = id;
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public int? sessionGetId()
        {
            var val = HttpContext.Session.GetInt32("id");
            return val;
        }
    }
}

