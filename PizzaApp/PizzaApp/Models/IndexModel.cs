using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PizzaApp.Models
{

    //public class IndexModel
    //{
    //    public int? sessionGetId()
    //    {
    //        var val = HttpContext.Session.GetInt32("id");
    //        return val;
    //    }
    //}
    //public class IndexModel : PageModel
    //{
    //    public const string SessionKeyName = "_Name";
    //    public const string SessionKeyAge = "_Age";
    //    const string SessionKeyTime = "_Time";

    //    public string SessionInfo_Name { get; private set; }
    //    public string SessionInfo_Age { get; private set; }
    //    public string SessionInfo_CurrentTime { get; private set; }
    //    public string SessionInfo_SessionTime { get; private set; }
    //    public string SessionInfo_MiddlewareValue { get; private set; }

    //    public void OnGet()
    //    {
    //        // Requires: using Microsoft.AspNetCore.Http;
    //        if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
    //        {
    //            HttpContext.Session.SetString(SessionKeyName, "The Doctor");
    //            HttpContext.Session.SetInt32(SessionKeyAge, 773);
    //        }

    //        var name = HttpContext.Session.GetString(SessionKeyName);
    //        var age = HttpContext.Session.GetInt32(SessionKeyAge);
    //    }
    //}
}
