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
    public class OrganizingEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizingEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrganizingEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrganizingEntity.ToListAsync());
        }

        // GET: OrganizingEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizingEntity = await _context.OrganizingEntity
                .SingleOrDefaultAsync(m => m.OrganizingEntityID == id);
            if (organizingEntity == null)
            {
                return NotFound();
            }

            return View(organizingEntity);
        }

        // GET: OrganizingEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrganizingEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizingEntityID,Name,TypeOfEntity")] OrganizingEntity organizingEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizingEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizingEntity);
        }

        // GET: OrganizingEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizingEntity = await _context.OrganizingEntity.SingleOrDefaultAsync(m => m.OrganizingEntityID == id);
            if (organizingEntity == null)
            {
                return NotFound();
            }
            return View(organizingEntity);
        }

        // POST: OrganizingEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrganizingEntityID,Name,TypeOfEntity")] OrganizingEntity organizingEntity)
        {
            if (id != organizingEntity.OrganizingEntityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizingEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizingEntityExists(organizingEntity.OrganizingEntityID))
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
            return View(organizingEntity);
        }

        // GET: OrganizingEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizingEntity = await _context.OrganizingEntity
                .SingleOrDefaultAsync(m => m.OrganizingEntityID == id);
            if (organizingEntity == null)
            {
                return NotFound();
            }

            return View(organizingEntity);
        }

        // POST: OrganizingEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizingEntity = await _context.OrganizingEntity.SingleOrDefaultAsync(m => m.OrganizingEntityID == id);
            _context.OrganizingEntity.Remove(organizingEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizingEntityExists(int id)
        {
            return _context.OrganizingEntity.Any(e => e.OrganizingEntityID == id);
        }
    }
}
