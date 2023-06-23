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
    public class SweetsOnlyController : Controller
    {
        private readonly DatabaseContext _context;

        public SweetsOnlyController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: SweetsOnly
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.SweetsOnly.Include(s => s.Order).Include(s => s.Sweetness);
            return View(await databaseContext.ToListAsync());
        }

        // GET: SweetsOnly/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SweetsOnly == null)
            {
                return NotFound();
            }

            var sweetsOnly = await _context.SweetsOnly
                .Include(s => s.Order)
                .Include(s => s.Sweetness)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sweetsOnly == null)
            {
                return NotFound();
            }

            return View(sweetsOnly);
        }

        // GET: SweetsOnly/Create
        public IActionResult Create()
        {
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID");
            ViewData["SweetnessID"] = new SelectList(_context.Sweets, "ID", "ID");
            return View();
        }

        // POST: SweetsOnly/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Quantity,SweetnessID,OrderID")] SweetsOnly sweetsOnly)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sweetsOnly);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID", sweetsOnly.OrderID);
            ViewData["SweetnessID"] = new SelectList(_context.Sweets, "ID", "ID", sweetsOnly.SweetnessID);
            return View(sweetsOnly);
        }

        // GET: SweetsOnly/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SweetsOnly == null)
            {
                return NotFound();
            }

            var sweetsOnly = await _context.SweetsOnly.FindAsync(id);
            if (sweetsOnly == null)
            {
                return NotFound();
            }
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID", sweetsOnly.OrderID);
            ViewData["SweetnessID"] = new SelectList(_context.Sweets, "ID", "ID", sweetsOnly.SweetnessID);
            return View(sweetsOnly);
        }

        // POST: SweetsOnly/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantity,SweetnessID,OrderID")] SweetsOnly sweetsOnly)
        {
            if (id != sweetsOnly.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sweetsOnly);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SweetsOnlyExists(sweetsOnly.ID))
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
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID", sweetsOnly.OrderID);
            ViewData["SweetnessID"] = new SelectList(_context.Sweets, "ID", "ID", sweetsOnly.SweetnessID);
            return View(sweetsOnly);
        }

        // GET: SweetsOnly/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SweetsOnly == null)
            {
                return NotFound();
            }

            var sweetsOnly = await _context.SweetsOnly
                .Include(s => s.Order)
                .Include(s => s.Sweetness)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sweetsOnly == null)
            {
                return NotFound();
            }

            return View(sweetsOnly);
        }

        // POST: SweetsOnly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SweetsOnly == null)
            {
                return Problem("Entity set 'DatabaseContext.SweetsOnly'  is null.");
            }
            var sweetsOnly = await _context.SweetsOnly.FindAsync(id);
            if (sweetsOnly != null)
            {
                _context.SweetsOnly.Remove(sweetsOnly);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SweetsOnlyExists(int id)
        {
          return (_context.SweetsOnly?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
