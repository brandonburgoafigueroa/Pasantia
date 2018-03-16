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
                .SingleOrDefaultAsync(m => m.ID == id);
            if (collectionREPP == null)
            {
                return NotFound();
            }

            return View(collectionREPP);
        }

        // GET: CollectionREPPs/Create
        public IActionResult Create()
        {
            ViewData["OperativeID"] = new SelectList(_context.Set<Operative>(), "OperativeID", "OperativeID");
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "ReppID");
            return View();
        }

        // POST: CollectionREPPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ReppID,OperativeID")] CollectionREPP collectionREPP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collectionREPP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OperativeID"] = new SelectList(_context.Set<Operative>(), "OperativeID", "OperativeID", collectionREPP.OperativeID);
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "ReppID", collectionREPP.ReppID);
            return View(collectionREPP);
        }

        // GET: CollectionREPPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectionREPP = await _context.CollectionsREPP.SingleOrDefaultAsync(m => m.ID == id);
            if (collectionREPP == null)
            {
                return NotFound();
            }
            ViewData["OperativeID"] = new SelectList(_context.Set<Operative>(), "OperativeID", "OperativeID", collectionREPP.OperativeID);
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "ReppID", collectionREPP.ReppID);
            return View(collectionREPP);
        }

        // POST: CollectionREPPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ReppID,OperativeID")] CollectionREPP collectionREPP)
        {
            if (id != collectionREPP.ID)
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
                    if (!CollectionREPPExists(collectionREPP.ID))
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
            ViewData["OperativeID"] = new SelectList(_context.Set<Operative>(), "OperativeID", "OperativeID", collectionREPP.OperativeID);
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "ReppID", collectionREPP.ReppID);
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
                .SingleOrDefaultAsync(m => m.ID == id);
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
            var collectionREPP = await _context.CollectionsREPP.SingleOrDefaultAsync(m => m.ID == id);
            _context.CollectionsREPP.Remove(collectionREPP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectionREPPExists(int id)
        {
            return _context.CollectionsREPP.Any(e => e.ID == id);
        }
    }
}
