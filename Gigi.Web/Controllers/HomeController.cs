using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Gigi.Business.Services.Interfaces;

namespace Gigi.Web.Controllers
{
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
            var principal = ClaimsPrincipal.Current;
            return View(garment);
        }

        [Authorize]
        public ActionResult About()
        {
            ClaimsPrincipal cp = ClaimsPrincipal.Current;
            string fullname =
                   string.Format("{0} {1}", cp.FindFirst(ClaimTypes.GivenName).Value,
                   cp.FindFirst(ClaimTypes.Surname).Value);
            ViewBag.Message = string.Format("Dear {0}, Welcome to the Gigi.com",
                              fullname);

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}