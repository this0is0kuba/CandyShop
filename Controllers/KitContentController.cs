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
    public class KitContentController : Controller
    {
        private readonly DatabaseContext _context;

        public KitContentController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: KitContent
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.KitContent.Include(k => k.Kit).Include(k => k.Sweetness);
            return View(await databaseContext.ToListAsync());
        }

        // GET: KitContent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KitContent == null)
            {
                return NotFound();
            }

            var kitContent = await _context.KitContent
                .Include(k => k.Kit)
                .Include(k => k.Sweetness)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kitContent == null)
            {
                return NotFound();
            }

            return View(kitContent);
        }

        // GET: KitContent/Create
        public IActionResult Create()
        {
            ViewData["KitId"] = new SelectList(_context.Kits, "ID", "ID");
            ViewData["SweetnessID"] = new SelectList(_context.Sweets, "ID", "ID");
            return View();
        }

        // POST: KitContent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Quantity,KitId,SweetnessID")] KitContent kitContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KitId"] = new SelectList(_context.Kits, "ID", "ID", kitContent.KitID);
            ViewData["SweetnessID"] = new SelectList(_context.Sweets, "ID", "ID", kitContent.SweetnessID);
            return View(kitContent);
        }

        // GET: KitContent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KitContent == null)
            {
                return NotFound();
            }

            var kitContent = await _context.KitContent.FindAsync(id);
            if (kitContent == null)
            {
                return NotFound();
            }
            ViewData["KitId"] = new SelectList(_context.Kits, "ID", "ID", kitContent.KitID);
            ViewData["SweetnessID"] = new SelectList(_context.Sweets, "ID", "ID", kitContent.SweetnessID);
            return View(kitContent);
        }

        // POST: KitContent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantity,KitId,SweetnessID")] KitContent kitContent)
        {
            if (id != kitContent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitContentExists(kitContent.ID))
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
            ViewData["KitId"] = new SelectList(_context.Kits, "ID", "ID", kitContent.KitID);
            ViewData["SweetnessID"] = new SelectList(_context.Sweets, "ID", "ID", kitContent.SweetnessID);
            return View(kitContent);
        }

        // GET: KitContent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KitContent == null)
            {
                return NotFound();
            }

            var kitContent = await _context.KitContent
                .Include(k => k.Kit)
                .Include(k => k.Sweetness)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kitContent == null)
            {
                return NotFound();
            }

            return View(kitContent);
        }

        // POST: KitContent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KitContent == null)
            {
                return Problem("Entity set 'DatabaseContext.KitContent'  is null.");
            }
            var kitContent = await _context.KitContent.FindAsync(id);
            if (kitContent != null)
            {
                _context.KitContent.Remove(kitContent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitContentExists(int id)
        {
          return (_context.KitContent?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
