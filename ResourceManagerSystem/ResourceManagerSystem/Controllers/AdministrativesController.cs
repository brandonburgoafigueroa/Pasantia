using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResourceManagerSystem.Data;
using ResourceManagerSystem.Models;

namespace ResourceManagerSystem.Controllers
{
    public class AdministrativesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdministrativesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administratives
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Administrative.Include(a => a.Region);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Administratives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrative = await _context.Administrative
                .Include(a => a.Region)
                .SingleOrDefaultAsync(m => m.AdministrativeID == id);
            if (administrative == null)
            {
                return NotFound();
            }

            return View(administrative);
        }

        // GET: Administratives/Create
        public IActionResult Create()
        {
            ViewData["RegionID"] = new SelectList(_context.Region, "RegionID", "Name");
            return View();
        }

        // POST: Administratives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdministrativeID,Name,RegionID")] Administrative administrative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionID"] = new SelectList(_context.Region, "RegionID", "Name", administrative.RegionID);
            return View(administrative);
        }

        // GET: Administratives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrative = await _context.Administrative.SingleOrDefaultAsync(m => m.AdministrativeID == id);
            if (administrative == null)
            {
                return NotFound();
            }
            ViewData["RegionID"] = new SelectList(_context.Region, "RegionID", "Name", administrative.RegionID);
            return View(administrative);
        }

        // POST: Administratives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdministrativeID,Name,RegionID")] Administrative administrative)
        {
            if (id != administrative.AdministrativeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrativeExists(administrative.AdministrativeID))
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
            ViewData["RegionID"] = new SelectList(_context.Region, "RegionID", "Name", administrative.RegionID);
            return View(administrative);
        }

        // GET: Administratives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrative = await _context.Administrative
                .Include(a => a.Region)
                .SingleOrDefaultAsync(m => m.AdministrativeID == id);
            if (administrative == null)
            {
                return NotFound();
            }

            return View(administrative);
        }

        // POST: Administratives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrative = await _context.Administrative.SingleOrDefaultAsync(m => m.AdministrativeID == id);
            _context.Administrative.Remove(administrative);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrativeExists(int id)
        {
            return _context.Administrative.Any(e => e.AdministrativeID == id);
        }
    }
}
