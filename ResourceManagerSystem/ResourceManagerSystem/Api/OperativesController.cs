using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResourceManagerSystem.Data;
using ResourceManagerSystem.Models;

namespace ResourceManagerSystem.Api
{
    public class OperativesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OperativesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Operatives
        public async Task<IActionResult> Index()
        {
            return View(await _context.Operative.ToListAsync());
        }

        // GET: Operatives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operative = await _context.Operative
                .SingleOrDefaultAsync(m => m.OperativeID == id);
            if (operative == null)
            {
                return NotFound();
            }

            return View(operative);
        }

        // GET: Operatives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operatives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OperativeID,Name")] Operative operative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operative);
        }

        // GET: Operatives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operative = await _context.Operative.SingleOrDefaultAsync(m => m.OperativeID == id);
            if (operative == null)
            {
                return NotFound();
            }
            return View(operative);
        }

        // POST: Operatives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OperativeID,Name")] Operative operative)
        {
            if (id != operative.OperativeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperativeExists(operative.OperativeID))
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
            return View(operative);
        }

        // GET: Operatives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operative = await _context.Operative
                .SingleOrDefaultAsync(m => m.OperativeID == id);
            if (operative == null)
            {
                return NotFound();
            }

            return View(operative);
        }

        // POST: Operatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operative = await _context.Operative.SingleOrDefaultAsync(m => m.OperativeID == id);
            _context.Operative.Remove(operative);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperativeExists(int id)
        {
            return _context.Operative.Any(e => e.OperativeID == id);
        }
    }
}
