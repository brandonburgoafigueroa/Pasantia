using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ResourceManagerSystem.Data;

namespace ResourceManagerSystem.Models
{
    public class REPPsController : Controller
    {
        private readonly ApplicationDbContext _context;
        protected readonly IToastNotification _toastNotification;
        public REPPsController(ApplicationDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: REPPs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.REPPS.Include(r => r.Color).Include(r => r.Size);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: REPPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEPP = await _context.REPPS
                .Include(r => r.Color)
                .Include(r => r.Size)
                .SingleOrDefaultAsync(m => m.ReppID == id);
            if (rEPP == null)
            {
                return NotFound();
            }

            return View(rEPP);
        }

        // GET: REPPs/Create
        public IActionResult Create()
        {
            ViewData["ColorName"] = new SelectList(_context.Color, "ColorName", "ColorName");
            ViewData["SizeName"] = new SelectList(_context.Size, "SizeName", "SizeName");
            return View();
        }

        // POST: REPPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReppID,Name,SizeName,ColorName")] REPP rEPP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rEPP);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Repp creado exitosamente");
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorName"] = new SelectList(_context.Color, "ColorName", "ColorName", rEPP.ColorName);
            ViewData["SizeName"] = new SelectList(_context.Size, "SizeName", "SizeName", rEPP.SizeName);
            return View(rEPP);
        }

        // GET: REPPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEPP = await _context.REPPS.SingleOrDefaultAsync(m => m.ReppID == id);
            if (rEPP == null)
            {
                return NotFound();
            }
            ViewData["ColorName"] = new SelectList(_context.Color, "ColorName", "ColorName", rEPP.ColorName);
            ViewData["SizeName"] = new SelectList(_context.Size, "SizeName", "SizeName", rEPP.SizeName);
            return View(rEPP);
        }

        // POST: REPPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReppID,Name,SizeName,ColorName")] REPP rEPP)
        {
            if (id != rEPP.ReppID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rEPP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!REPPExists(rEPP.ReppID))
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
            ViewData["ColorName"] = new SelectList(_context.Color, "ColorName", "ColorName", rEPP.ColorName);
            ViewData["SizeName"] = new SelectList(_context.Size, "SizeName", "SizeName", rEPP.SizeName);
            return View(rEPP);
        }

        // GET: REPPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rEPP = await _context.REPPS
                .Include(r => r.Color)
                .Include(r => r.Size)
                .SingleOrDefaultAsync(m => m.ReppID == id);
            if (rEPP == null)
            {
                return NotFound();
            }

            return View(rEPP);
        }

        // POST: REPPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rEPP = await _context.REPPS.SingleOrDefaultAsync(m => m.ReppID == id);
            _context.REPPS.Remove(rEPP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool REPPExists(int id)
        {
            return _context.REPPS.Any(e => e.ReppID == id);
        }
    }
}
