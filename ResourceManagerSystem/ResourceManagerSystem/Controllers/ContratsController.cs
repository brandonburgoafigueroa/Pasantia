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
    public class ContratsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContratsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Contrats
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Contrat.Include(c => c.Administrative).Include(c => c.Employee).Include(c => c.Operative);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Contrats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrat
                .Include(c => c.Administrative)
                .Include(c => c.Employee)
                .Include(c => c.Operative)
                .SingleOrDefaultAsync(m => m.ContratID == id);
            if (contrat == null)
            {
                return NotFound();
            }

            return View(contrat);
        }

        // GET: Contrats/Create
        public IActionResult Create()
        {
            ViewData["AdministrativeID"] = new SelectList(_context.Administrative, "AdministrativeID", "Name");
            ViewData["CI"] = new SelectList(_context.Employee, "CI", "CI");
            ViewData["OperativeID"] = new SelectList(_context.Operative, "OperativeID", "Name");
            return View();
        }

        // POST: Contrats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratID,CI,OperativeID,AdministrativeID,TypeContrat,DateStart,DateEnd")] Contrat contrat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdministrativeID"] = new SelectList(_context.Administrative, "AdministrativeID", "Name", contrat.AdministrativeID);
            ViewData["CI"] = new SelectList(_context.Employee, "CI", "CI", contrat.CI);
            ViewData["OperativeID"] = new SelectList(_context.Operative, "OperativeID", "Name", contrat.OperativeID);
            return View(contrat);
        }

        // GET: Contrats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrat.SingleOrDefaultAsync(m => m.ContratID == id);
            if (contrat == null)
            {
                return NotFound();
            }
            ViewData["AdministrativeID"] = new SelectList(_context.Administrative, "AdministrativeID", "Name", contrat.AdministrativeID);
            ViewData["CI"] = new SelectList(_context.Employee, "CI", "CI", contrat.CI);
            ViewData["OperativeID"] = new SelectList(_context.Operative, "OperativeID", "Name", contrat.OperativeID);
            return View(contrat);
        }

        // POST: Contrats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratID,CI,OperativeID,AdministrativeID,TypeContrat,DateStart,DateEnd")] Contrat contrat)
        {
            if (id != contrat.ContratID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratExists(contrat.ContratID))
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
            ViewData["AdministrativeID"] = new SelectList(_context.Administrative, "AdministrativeID", "Name", contrat.AdministrativeID);
            ViewData["CI"] = new SelectList(_context.Employee, "CI", "CI", contrat.CI);
            ViewData["OperativeID"] = new SelectList(_context.Operative, "OperativeID", "Name", contrat.OperativeID);
            return View(contrat);
        }

        // GET: Contrats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrat
                .Include(c => c.Administrative)
                .Include(c => c.Employee)
                .Include(c => c.Operative)
                .SingleOrDefaultAsync(m => m.ContratID == id);
            if (contrat == null)
            {
                return NotFound();
            }

            return View(contrat);
        }

        // POST: Contrats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contrat = await _context.Contrat.SingleOrDefaultAsync(m => m.ContratID == id);
            _context.Contrat.Remove(contrat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratExists(int id)
        {
            return _context.Contrat.Any(e => e.ContratID == id);
        }
    }
}
