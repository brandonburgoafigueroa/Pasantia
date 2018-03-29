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
    public class LotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lots
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lot.Include(l => l.Provider);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Lots/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lot = await _context.Lot
                .Include(l => l.Provider)
                .SingleOrDefaultAsync(m => m.LotID == id);
            if (lot == null)
            {
                return NotFound();
            }

            return View(lot);
        }

        // GET: Lots/Create
        public IActionResult Create()
        {
            ViewData["ProviderID"] = new SelectList(_context.Provider, "ProviderID", "Address");
            return View();
        }

        // POST: Lots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LotID,ProviderID,Description")] Lot lot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProviderID"] = new SelectList(_context.Provider, "ProviderID", "Address", lot.ProviderID);
            return View(lot);
        }

        // GET: Lots/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lot = await _context.Lot.SingleOrDefaultAsync(m => m.LotID == id);
            if (lot == null)
            {
                return NotFound();
            }
            ViewData["ProviderID"] = new SelectList(_context.Provider, "ProviderID", "Address", lot.ProviderID);
            return View(lot);
        }

        // POST: Lots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LotID,ProviderID,Description")] Lot lot)
        {
            if (id != lot.LotID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LotExists(lot.LotID))
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
            ViewData["ProviderID"] = new SelectList(_context.Provider, "ProviderID", "Address", lot.ProviderID);
            return View(lot);
        }

        // GET: Lots/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lot = await _context.Lot
                .Include(l => l.Provider)
                .SingleOrDefaultAsync(m => m.LotID == id);
            if (lot == null)
            {
                return NotFound();
            }

            return View(lot);
        }

        // POST: Lots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var lot = await _context.Lot.SingleOrDefaultAsync(m => m.LotID == id);
            _context.Lot.Remove(lot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddItems()
        {
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "Name",null, "ColorName");
            ViewData["ColorName"] = new SelectList(_context.Color, "ColorName", "ColorName");
            ViewData["SizeName"] = new SelectList(_context.Size, "SizeName", "SizeName");
            List<DeliveryModelView> model = new List<DeliveryModelView>();
            for (int i = 0; i < 5; i++)
            {
                model.Add(new DeliveryModelView() { LotID=1});
            }
            return View(model);
        }

        // POST: Lots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItems(List<DeliveryModelView> model)
        {
            if (ModelState.IsValid)
            {
             //   _context.Add(Items);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
          //  ViewData["ProviderID"] = new SelectList(_context.Provider, "ProviderID", "Address", lot.ProviderID);
            return View();
        }

        private bool LotExists(string id)
        {
            return _context.Lot.Any(e => e.LotID == id);
        }
    }
}
