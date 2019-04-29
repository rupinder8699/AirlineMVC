using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirlineMVC.Models;
//these controllers are calling pages of home 

namespace AirlineMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home 
        DbAirlineEntities1 obj = new DbAirlineEntities1();
        public ActionResult MainPage()
        {
            return View(obj.tbPlanes.ToList());
        }
        // GET: About uS
        public ActionResult AboutUs()
        {
            return View();
        }
        // GET: Privacy Policy
        public ActionResult PrivacyPolicy()
        {
            return View();
        }


    }
}