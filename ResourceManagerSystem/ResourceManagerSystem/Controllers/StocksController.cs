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
    public class StocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Stock.Include(s => s.Color).Include(s => s.Repp).Include(s => s.Size);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.Color)
                .Include(s => s.Repp)
                .Include(s => s.Size)
                .SingleOrDefaultAsync(m => m.StockID == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            ViewData["ColorName"] = new SelectList(_context.Color, "ColorName", "ColorName");
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "Name");
            ViewData["SizeName"] = new SelectList(_context.Size, "SizeName", "SizeName");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockID,ReppID,Quantity,ColorName,SizeName")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorName"] = new SelectList(_context.Color, "ColorName", "ColorName", stock.ColorName);
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "Name", stock.ReppID);
            ViewData["SizeName"] = new SelectList(_context.Size, "SizeName", "SizeName", stock.SizeName);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.SingleOrDefaultAsync(m => m.StockID == id);
            if (stock == null)
            {
                return NotFound();
            }
            ViewData["ColorName"] = new SelectList(_context.Color, "ColorName", "ColorName", stock.ColorName);
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "Name", stock.ReppID);
            ViewData["SizeName"] = new SelectList(_context.Size, "SizeName", "SizeName", stock.SizeName);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockID,ReppID,Quantity,ColorName,SizeName")] Stock stock)
        {
            if (id != stock.StockID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.StockID))
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
            ViewData["ColorName"] = new SelectList(_context.Color, "ColorName", "ColorName", stock.ColorName);
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "Name", stock.ReppID);
            ViewData["SizeName"] = new SelectList(_context.Size, "SizeName", "SizeName", stock.SizeName);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.Color)
                .Include(s => s.Repp)
                .Include(s => s.Size)
                .SingleOrDefaultAsync(m => m.StockID == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stock = await _context.Stock.SingleOrDefaultAsync(m => m.StockID == id);
            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(int id)
        {
            return _context.Stock.Any(e => e.StockID == id);
        }
    }
}
