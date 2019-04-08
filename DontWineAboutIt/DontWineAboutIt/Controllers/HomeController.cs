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
        /// <summary>
        /// Displays Home page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// POST action for search form on Home page.
        /// </summary>
        /// <param name="price">Price result from form</param>
        /// <param name="points">Points result from form</param>
        /// <returns>Price and Points</returns>
        [HttpPost]
        public IActionResult Index(decimal price, int points)
        {
            return RedirectToAction("Results", new { price, points });
        }

        /// <summary>
        /// Displays Results page with formated data using LINQ query based on POST.
        /// </summary>
        /// <param name="price">Price from POST</param>
        /// <param name="points">Points from POST</param>
        /// <returns>Formated wine list</returns>
        [HttpGet]
        public IActionResult Results(decimal price, int points)
        {
            List<Wine> wineList = Wine.GetWineList();
            List<Wine> curatedList = new List<Wine>();

            var selection = wineList
                .Where(w => w.Price <= price && w.Points <= points)
                .OrderByDescending(w => w.Points);
            foreach (var wine in selection)
            {
                curatedList.Add(wine);
            }

            return View(curatedList);
        }

    }
}
