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
            ViewData["ProviderID"] = new SelectList(_context.Provider, "ProviderID", "CompleteName", null, "City");
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
                return RedirectToAction(nameof(CreateItemsQuestion), new { id=lot.LotID});
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
        public IActionResult CreateItemsQuestion(string id)
        {
            List<string> Params = new List<string>() { id };
            return View(Params);
        }
        public IActionResult VerifyProductsAvaiable(string lot)
        {
            IEnumerable<string> ReppsAvaiable = _context.REPPS.GroupBy(x => x.Name).Select(x => x.FirstOrDefault()).Select(x => x.Name);
            IEnumerable<string> ColorsAvaiable = _context.Color.ToList().Select(x => x.ColorName);
            IEnumerable<string> SizesAvaiables= _context.Size.ToList().Select(x => x.SizeName);
            IEnumerable<string> InfoAditional = new List<string>() {
               lot
            };
            ViewData["ColorName"] = new SelectList(_context.Color, "ColorName", "ColorName");
            ViewData["SizeName"] = new SelectList(_context.Size, "SizeName", "SizeName");
            Dictionary<string, IEnumerable<string>> ComponentsAvaiable = new Dictionary<string, IEnumerable<string>> 
            {
                { "Repps", ReppsAvaiable },
                { "Colors", ColorsAvaiable },
                { "Sizes", SizesAvaiables },
                { "Lot", InfoAditional }
            };
            return View(ComponentsAvaiable);
        }
        public IActionResult AddItems(int quantity, string lot)
        {

            ViewData["ReppID"] = new SelectList(_context.REPPS.GroupBy(x=>x.Name).Select(x=>x.FirstOrDefault()), "ReppID", "Name");
            ViewData["ColorName"] = new SelectList(_context.Color, "ColorName", "ColorName");
            ViewData["SizeName"] = new SelectList(_context.Size, "SizeName", "SizeName");
            List<DeliveryModelView> model = new List<DeliveryModelView>();
            for (int i = 0; i < quantity; i++)
            {
                model.Add(new DeliveryModelView() { LotID=lot});
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
                foreach (var item in model)
                {
                  await AddItemAsync(item);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private async Task AddItemAsync(DeliveryModelView item)
        {
            REPP ReppExist = await GetInfoOfReppAsync(item);
            await AddDeliveryAsync(item, ReppExist);
            await AddQuantityToStockAsync(item, ReppExist);
        }

        private async Task AddQuantityToStockAsync(DeliveryModelView item, REPP ReppExist)
        {
            Stock stockExist = _context.Stock.ToList().Find(x => x.ReppID == ReppExist.ReppID && x.ColorName==item.ColorName && x.SizeName==item.SizeName);
            if (stockExist == null)
            {
                _context.Stock.Add(new Stock() { ReppID = ReppExist.ReppID, Quantity = item.Quantity, ColorName = item.ColorName, SizeName = item.SizeName });
                await _context.SaveChangesAsync();
            }
            else
            {
                var stock = _context.Stock.ToList().Find(x=>x.StockID==stockExist.StockID);
                stock.Quantity += item.Quantity;
                await _context.SaveChangesAsync();
            }
        }

        private async Task AddDeliveryAsync(DeliveryModelView item, REPP ReppExist)
        {
            Delivery delivery = new Delivery() {Brand=item.Brand, ReppID = ReppExist.ReppID, LotID = item.LotID, Description = item.Description, Quantity = item.Quantity };
            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();
        }

        private async Task<REPP> GetInfoOfReppAsync(DeliveryModelView item)
        {
            REPP reference = _context.REPPS.Find(item.ReppID);
            REPP repp = new REPP() {Name = reference.Name };
            REPP ReppExist = _context.REPPS.ToList().Find(x => x.Name == repp.Name);
            if (ReppExist == null)
            {
                _context.REPPS.Add(repp);
                await _context.SaveChangesAsync();
            }
            ReppExist = _context.REPPS.ToList().Find(x => x.Name == repp.Name);
            return ReppExist;
        }

        private bool LotExists(string id)
        {
            return _context.Lot.Any(e => e.LotID == id);
        }
    }
}
