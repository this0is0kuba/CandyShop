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
    public class KitsOnlyController : Controller
    {
        private readonly DatabaseContext _context;

        public KitsOnlyController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: KitsOnly
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.KitsOnly.Include(k => k.Kit).Include(k => k.Order);
            return View(await databaseContext.ToListAsync());
        }

        // GET: KitsOnly/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KitsOnly == null)
            {
                return NotFound();
            }

            var kitsOnly = await _context.KitsOnly
                .Include(k => k.Kit)
                .Include(k => k.Order)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kitsOnly == null)
            {
                return NotFound();
            }

            return View(kitsOnly);
        }

        // GET: KitsOnly/Create
        public IActionResult Create()
        {
            ViewData["KitID"] = new SelectList(_context.Kits, "ID", "ID");
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID");
            return View();
        }

        // POST: KitsOnly/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Quantity,KitID,OrderID")] KitsOnly kitsOnly)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitsOnly);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KitID"] = new SelectList(_context.Kits, "ID", "ID", kitsOnly.KitID);
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID", kitsOnly.OrderID);
            return View(kitsOnly);
        }

        // GET: KitsOnly/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KitsOnly == null)
            {
                return NotFound();
            }

            var kitsOnly = await _context.KitsOnly.FindAsync(id);
            if (kitsOnly == null)
            {
                return NotFound();
            }
            ViewData["KitID"] = new SelectList(_context.Kits, "ID", "ID", kitsOnly.KitID);
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID", kitsOnly.OrderID);
            return View(kitsOnly);
        }

        // POST: KitsOnly/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantity,KitID,OrderID")] KitsOnly kitsOnly)
        {
            if (id != kitsOnly.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitsOnly);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitsOnlyExists(kitsOnly.ID))
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
            ViewData["KitID"] = new SelectList(_context.Kits, "ID", "ID", kitsOnly.KitID);
            ViewData["OrderID"] = new SelectList(_context.Orders, "ID", "ID", kitsOnly.OrderID);
            return View(kitsOnly);
        }

        // GET: KitsOnly/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KitsOnly == null)
            {
                return NotFound();
            }

            var kitsOnly = await _context.KitsOnly
                .Include(k => k.Kit)
                .Include(k => k.Order)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kitsOnly == null)
            {
                return NotFound();
            }

            return View(kitsOnly);
        }

        // POST: KitsOnly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KitsOnly == null)
            {
                return Problem("Entity set 'DatabaseContext.KitsOnly'  is null.");
            }
            var kitsOnly = await _context.KitsOnly.FindAsync(id);
            if (kitsOnly != null)
            {
                _context.KitsOnly.Remove(kitsOnly);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitsOnlyExists(int id)
        {
          return (_context.KitsOnly?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
