using Proj.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{ using Proj.DAL;
    

    public class HomeController : Controller
    {
        Repository<Products> urunler = new Repository<Products>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Listele()
        {
           

            return View( urunler.Listele());
        }
    }
}