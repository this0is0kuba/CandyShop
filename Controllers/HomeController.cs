using CandyShop.Data;
using CandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace CandyShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(string? searchPhrase)
        {
            if (_context.Sweets == null)
                return Problem("Sorry, there are no product that meet your request");

            if (searchPhrase == null)
                return View("Index");

            var sweetsTable = await _context.Sweets.
                Where(s => s.Name.Contains(searchPhrase) || s.Description.Contains(searchPhrase)).ToListAsync();

            var kitsTable = await _context.Kits.
                Where(k => k.Name.Contains(searchPhrase) || k.Description.Contains(searchPhrase)).ToListAsync();

            var products = new Products
            {
                Kits = kitsTable,
                Sweets = sweetsTable
            };

            return View(products);
        }

        public ActionResult Basket()
        {
            var allCookies = Request.Cookies;
            decimal totalPrice = 0;

            if (allCookies.Count > 0)
            {
                foreach (var cookie in allCookies)
                {
                    if (cookie.Key.Equals(".AspNetCore.Antiforgery.o3MzoDseqwg"))
                        continue;

                    int id = Convert.ToInt32(cookie.Key);
                    int amount = Convert.ToInt32(cookie.Value);
                    string name;
                    string kit;
                    decimal price;
                    decimal sumPrice;
                    string link;
                        
                    if(id > 1000)
                    {
                        id = id - 1000;
                        var myKit = _context.Kits.First(k => k.ID == id);

                        kit = "Kit";
                        name = myKit.Name;
                        price = myKit.CurrentPrice;
                        sumPrice = price * amount;
                        link = "https://localhost:7180/Kits/Details/" + id;

                        totalPrice += sumPrice;
                    }
                    else
                    {
                        var mySweetness = _context.Sweets.First(s => s.ID == id);

                        kit = "Sweetness";
                        name = mySweetness.Name;
                        price = mySweetness.CurrentPrice;
                        sumPrice = price * amount;
                        link = "https://localhost:7180/Sweets/Details/" + id;

                        totalPrice += sumPrice;
                    }
                        
                    ViewData[cookie.Key] = cookie.Value + ";" + kit + ";" + name + ";" + price + ";" + sumPrice + ";" + link;
                }
            }

            ViewData["totalCost"] = totalPrice;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}