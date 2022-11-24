using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleBid2.Data;
using SampleBid2.Models;

namespace SampleBid2.Controllers
{
    public class BidingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BidingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bidings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bidings.Include(b => b.Player);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bidings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bidings == null)
            {
                return NotFound();
            }

            var biding = await _context.Bidings
                .Include(b => b.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biding == null)
            {
                return NotFound();
            }

            return View(biding);
        }

        // GET: Bidings/Create
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.players, "Id", "Id");
            return View();
        }

        // POST: Bidings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BidPrice,Date,PlayerId")] Biding biding)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.players, "Id", "Id", biding.PlayerId);
            return View(biding);
        }

        // GET: Bidings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bidings == null)
            {
                return NotFound();
            }

            var biding = await _context.Bidings.FindAsync(id);
            if (biding == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.players, "Id", "Id", biding.PlayerId);
            return View(biding);
        }

        // POST: Bidings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BidPrice,Date,PlayerId")] Biding biding)
        {
            if (id != biding.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BidingExists(biding.Id))
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
            ViewData["PlayerId"] = new SelectList(_context.players, "Id", "Id", biding.PlayerId);
            return View(biding);
        }

        // GET: Bidings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bidings == null)
            {
                return NotFound();
            }

            var biding = await _context.Bidings
                .Include(b => b.Player)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biding == null)
            {
                return NotFound();
            }

            return View(biding);
        }

        // POST: Bidings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bidings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bidings'  is null.");
            }
            var biding = await _context.Bidings.FindAsync(id);
            if (biding != null)
            {
                _context.Bidings.Remove(biding);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BidingExists(int id)
        {
          return _context.Bidings.Any(e => e.Id == id);
        }
    }
}
