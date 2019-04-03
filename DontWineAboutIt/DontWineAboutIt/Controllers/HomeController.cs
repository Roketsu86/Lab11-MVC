using DontWineAboutIt.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DontWineAboutIt.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, int price, int points)
        {
            List<Wine> wines = new List<Wine>();
            wines = Wine.GetWineList();

            return RedirectToAction("Results", wines);
        }
    }
}
