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
        public IActionResult Index(decimal price, int points)
        {
            return RedirectToAction("Results", new { price, points });
        }

        [HttpGet]
        public IActionResult Results(decimal price, int points)
        {
            List<Wine> wineList = Wine.GetWineList();
            List<Wine> curatedList = new List<Wine>();

            var selection = wineList.Where(w => w.Price <= price && w.Points <= points);
            foreach (var wine in selection)
            {
                curatedList.Add(wine);
            }

            return View(curatedList);
        }

    }
}
