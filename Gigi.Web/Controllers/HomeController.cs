using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gigi.Business.Services.Interfaces;

namespace Gigi.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IGarmentService _garmentService;

        public HomeController(IGarmentService garmentService)
        {
            _garmentService = garmentService;
        }

        public ActionResult Index()
        {
            var garment = _garmentService.GetGarmentById(1);
            return View(garment);
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
    }
}