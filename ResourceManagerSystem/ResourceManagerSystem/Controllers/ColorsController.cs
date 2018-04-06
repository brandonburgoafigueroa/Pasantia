using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using ResourceManagerSystem.Data;
using ResourceManagerSystem.Models;

namespace ResourceManagerSystem.Controllers
{
    public class ColorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        protected readonly IToastNotification _toastNotification;
        public ColorsController(ApplicationDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }

        // GET: Colors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Color.ToListAsync());
        }

        // GET: Colors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await _context.Color
                .SingleOrDefaultAsync(m => m.ColorName == id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // GET: Colors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColorName")] Color color)
        {

            if (ModelState.IsValid && !_context.Color.Select(x=>x.ColorName).ToList().Contains(color.ColorName))
            {
                _context.Add(color);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Color creado exitosamente");
                return RedirectToAction(nameof(Index));

            }
            _toastNotification.AddErrorToastMessage("El color "+color.ColorName+" ya existe");
            return View(color);
        }

        // GET: Colors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await _context.Color.SingleOrDefaultAsync(m => m.ColorName == id);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }

        // POST: Colors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ColorName")] Color color)
        {
            if (id != color.ColorName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(color);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorExists(color.ColorName))
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
            return View(color);
        }

        // GET: Colors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await _context.Color
                .SingleOrDefaultAsync(m => m.ColorName == id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var color = await _context.Color.SingleOrDefaultAsync(m => m.ColorName == id);
            _context.Color.Remove(color);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColorExists(string id)
        {
            return _context.Color.Any(e => e.ColorName == id);
        }
    }
}
