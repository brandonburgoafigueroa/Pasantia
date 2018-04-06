using System;
using ResourceManagerSystem.Data;
using ResourceManagerSystem.Models;

namespace ResourceManagerSystem.Controllers
{
    internal class SaveCollection
    {

        /* public async Task<IActionResult> Create([Bind("CollectionREPPID,ReppID,OperativeID")] CollectionREPP collectionREPP)
        {
            var items = Request.Form["SelectedRepp"];
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.CollectionsREPP ON");
            if (ModelState.IsValid)
            {
                foreach (var item in items)
                {
                    int reppID = Convert.ToInt32(item);
                    if (!CollectionREPPExists(collectionREPP.OperativeID, reppID))
                    {
                        CollectionREPP c = new CollectionREPP() { ReppID = reppID, OperativeID = collectionREPP.OperativeID };
                        _context.CollectionsREPP.Add(c);
                    }
                    
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OperativeID"] = new SelectList(_context.Operative, "OperativeID", "Name", collectionREPP.OperativeID);
            ViewData["ReppID"] = new SelectList(_context.REPPS, "ReppID", "Name", collectionREPP.ReppID);
            return View(collectionREPP);
        }
          private bool CollectionREPPExists(int idOperative, int idRepp)
        {
            return _context.CollectionsREPP.Any(e => e.OperativeID == idOperative && e.ReppID == idRepp);
        }
         */
    }
}