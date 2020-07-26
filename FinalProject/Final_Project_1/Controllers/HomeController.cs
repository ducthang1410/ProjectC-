using Final_Project_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project_1.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewCar()
        {
            return View();
        }

        public ActionResult ProductInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProductInfo(String ID)
        {   
            var Car = CarData.getCarByID(ID);
            return View(Car);               
        }

        public ActionResult DescriptionProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DescriptionProduct(String ID)
        {
            var Tech = TechnologyData.getTechonologyByCarID(ID);
            return View(Tech);
        }
    }
}