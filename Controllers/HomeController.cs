using CandyShop.Data;
using CandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

            var sweetsTable = _context.Sweets.
                Where(s => s.Name.Contains(searchPhrase) || s.Description.Contains(searchPhrase)).ToList();

            var kitsTable = _context.Kits.
                Where(k => k.Name.Contains(searchPhrase) || k.Description.Contains(searchPhrase)).ToList();

            var products = new Products
            {
                Kits = kitsTable,
                Sweets = sweetsTable
            };

            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}