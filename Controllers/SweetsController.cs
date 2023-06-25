using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CandyShop.Data;
using CandyShop.Models.DBModels;

namespace CandyShop.Controllers
{
    public class SweetsController : Controller
    {
        private readonly DatabaseContext _context;

        public SweetsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Sweets
        public async Task<IActionResult> Index()
        {
            if (_context.Sweets == null)
                return Problem("Sorry, there are no product that meet your request");

            return View(await _context.Sweets.ToListAsync());
        }

        public async Task<IActionResult> Category(CategoryName categoryName)
        {
            if (_context.Sweets == null)    
                return Problem("Sorry, there are no product that meet your request");

            ViewData["categoryName"] = categoryName;

            return View(await _context.Sweets.Where(s => s.CategoryName.Equals(categoryName)).ToListAsync());
        }

        // GET: Sweets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sweets == null)
                return NotFound();


            var sweetness = await _context.Sweets.FirstOrDefaultAsync(m => m.ID == id);
            if (sweetness == null)
                return NotFound();


            var mySweetness = await _context.Sweets.FirstOrDefaultAsync(s => s.ID == id);
            if(mySweetness == null)
                return NotFound();

            ViewData["name"] = mySweetness.Name;
            ViewData["description"] = mySweetness.Description;
            ViewData["price"] = mySweetness.CurrentPrice;
            ViewData["stockLevel"] = mySweetness.StockLevel;
            ViewData["vegan"] = mySweetness.IsVegan;
            ViewData["gluten"] = mySweetness.IsGluten;

            return View(sweetness);
        }

        // GET: Sweets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sweets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sweetness sweetness)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sweetness);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sweetness);
        }

        // GET: Sweets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sweets == null)
            {
                return NotFound();
            }

            var sweetness = await _context.Sweets.FindAsync(id);
            if (sweetness == null)
            {
                return NotFound();
            }
            return View(sweetness);
        }

        // POST: Sweets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,IsVegan,IsGluten,CurrentPrice,StockLevel,Discount,CategoryName")] Sweetness sweetness)
        {
            if (id != sweetness.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sweetness);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SweetnessExists(sweetness.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sweetness);
        }

        // GET: Sweets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sweets == null)
            {
                return NotFound();
            }

            var sweetness = await _context.Sweets
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sweetness == null)
            {
                return NotFound();
            }

            return View(sweetness);
        }

        // POST: Sweets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sweets == null)
            {
                return Problem("Entity set 'DatabaseContext.Sweets'  is null.");
            }
            var sweetness = await _context.Sweets.FindAsync(id);
            if (sweetness != null)
            {
                _context.Sweets.Remove(sweetness);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SweetnessExists(int id)
        {
          return (_context.Sweets?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
