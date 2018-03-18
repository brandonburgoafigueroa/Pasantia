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
    public class CollectionREPPsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollectionREPPsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CollectionREPPs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CollectionsREPP.Include(c => c.Operative).Include(c => c.REEP);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CollectionREPPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectionREPP = await _context.CollectionsREPP
                .Include(c => c.Operative)
                .Include(c => c.REEP)
                .SingleOrDefaultAsync(m => m.CollectionREPPID == id);
            if (collectionREPP == null)
            {
                return NotFound();
            }

            return View(collectionREPP);
        }

        // GET: CollectionREPPs/Create
        public IActionResult Create()
        {
            ViewData["OperativeID"] = new SelectList(_context.Operative, "OperativeID", "Name");
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "Brand");
            return View();
        }

        // POST: CollectionREPPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollectionREPPID,ReppID,OperativeID")] CollectionREPP collectionREPP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collectionREPP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OperativeID"] = new SelectList(_context.Operative, "OperativeID", "Name", collectionREPP.OperativeID);
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "Brand", collectionREPP.ReppID);
            return View(collectionREPP);
        }

        // GET: CollectionREPPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectionREPP = await _context.CollectionsREPP.SingleOrDefaultAsync(m => m.CollectionREPPID == id);
            if (collectionREPP == null)
            {
                return NotFound();
            }
            ViewData["OperativeID"] = new SelectList(_context.Operative, "OperativeID", "Name", collectionREPP.OperativeID);
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "Brand", collectionREPP.ReppID);
            return View(collectionREPP);
        }

        // POST: CollectionREPPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollectionREPPID,ReppID,OperativeID")] CollectionREPP collectionREPP)
        {
            if (id != collectionREPP.CollectionREPPID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collectionREPP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectionREPPExists(collectionREPP.CollectionREPPID))
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
            ViewData["OperativeID"] = new SelectList(_context.Operative, "OperativeID", "Name", collectionREPP.OperativeID);
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "Brand", collectionREPP.ReppID);
            return View(collectionREPP);
        }

        // GET: CollectionREPPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectionREPP = await _context.CollectionsREPP
                .Include(c => c.Operative)
                .Include(c => c.REEP)
                .SingleOrDefaultAsync(m => m.CollectionREPPID == id);
            if (collectionREPP == null)
            {
                return NotFound();
            }

            return View(collectionREPP);
        }

        // POST: CollectionREPPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collectionREPP = await _context.CollectionsREPP.SingleOrDefaultAsync(m => m.CollectionREPPID == id);
            _context.CollectionsREPP.Remove(collectionREPP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectionREPPExists(int id)
        {
            return _context.CollectionsREPP.Any(e => e.CollectionREPPID == id);
        }
    }
}
