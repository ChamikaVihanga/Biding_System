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
    public class TrophiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrophiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trophies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trophies.Include(t => t.Team);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trophies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trophies == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophies
                .Include(t => t.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trophy == null)
            {
                return NotFound();
            }

            return View(trophy);
        }

        // GET: Trophies/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "TeamName");
            return View();
        }

        // POST: Trophies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Trop_Name,StartDate,Duration,TeamId")] Trophy trophy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trophy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", trophy.TeamId);
            return View(trophy);
        }

        // GET: Trophies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trophies == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophies.FindAsync(id);
            if (trophy == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", trophy.TeamId);
            return View(trophy);
        }

        // POST: Trophies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Trop_Name,StartDate,Duration,TeamId")] Trophy trophy)
        {
            if (id != trophy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trophy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrophyExists(trophy.Id))
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
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Id", trophy.TeamId);
            return View(trophy);
        }

        // GET: Trophies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trophies == null)
            {
                return NotFound();
            }

            var trophy = await _context.Trophies
                .Include(t => t.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trophy == null)
            {
                return NotFound();
            }

            return View(trophy);
        }

        // POST: Trophies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trophies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trophies'  is null.");
            }
            var trophy = await _context.Trophies.FindAsync(id);
            if (trophy != null)
            {
                _context.Trophies.Remove(trophy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrophyExists(int id)
        {
          return _context.Trophies.Any(e => e.Id == id);
        }
    }
}
