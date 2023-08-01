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
    public class OrdersController : Controller
    {
        private readonly DatabaseContext _context;

        public OrdersController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
              return _context.Orders != null ? 
                          View(await _context.Orders.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.Orders'  is null.");
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,ContactEmail,PhoneNumber,StreetName,BuildingNumber,HomeNumber,Country,PostalCode")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.ExecutionDate = DateTime.Now;
                order.isSent = false;
                order.TotalCost = 0;

                _context.Add(order);
                await _context.SaveChangesAsync();

                //delete cookies

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

                        if (id > 1000)
                        {
                            id = id - 1000;
                            var myKit = _context.Kits.First(k => k.ID == id);

                            kit = "Kit";
                            name = myKit.Name;
                            price = myKit.CurrentPrice;
                            sumPrice = price * amount;
                            link = "https://localhost:7180/Kits/Details/" + id;

                            totalPrice += sumPrice;


                            var kitsOnly = new KitsOnly()
                            {
                                KitID = id,
                                Quantity = amount,
                                OrderID = order.ID
                            };
                            _context.Add(kitsOnly);

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


                            var sweetsOnly = new SweetsOnly()
                            {
                                SweetnessID = id,
                                Quantity = amount,
                                OrderID = order.ID
                            };
                            _context.Add(sweetsOnly);
                        }

                        Response.Cookies.Delete(cookie.Key);
                    }
                }

                _context.Orders.First(o => order.ID == o.ID).TotalCost = totalPrice;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ExecutionDate,TotalCost,isSent,FirstName,LastName,ContactEmail,PhoneNumber,StreetName,BuildingNumber,HomeNumber,Country,PostalCode")] Order order)
        {
            if (id != order.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.ID))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'DatabaseContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
