using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceManagerSystem.Data;
using ResourceManagerSystem.Models;

namespace ResourceManagerSystem.Controllers
{
    [Produces("application/json")]
    [Route("api/REPPApi")]
    public class REPPApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public REPPApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/REPPApi
        [HttpGet]
        public IEnumerable<REPP> GetREPPS()
        {
            return _context.REPPS;
        }

        // GET: api/REPPApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetREPP( int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rEPP = await _context.REPPS.SingleOrDefaultAsync(m => m.ReppID == id);

            if (rEPP == null)
            {
                return NotFound();
            }

            return Ok(rEPP);
        }

        // PUT: api/REPPApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutREPP( int id,  REPP rEPP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rEPP.ReppID)
            {
                return BadRequest();
            }

            _context.Entry(rEPP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!REPPExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/REPPApi
        [HttpPost]
        public async Task<IActionResult> PostREPP(REPP rEPP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.REPPS.Add(rEPP);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/REPPApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteREPP( int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rEPP = await _context.REPPS.SingleOrDefaultAsync(m => m.ReppID == id);
            if (rEPP == null)
            {
                return NotFound();
            }

            _context.REPPS.Remove(rEPP);
            await _context.SaveChangesAsync();

            return Ok(rEPP);
        }

        private bool REPPExists(int id)
        {
            return _context.REPPS.Any(e => e.ReppID == id);
        }
    }
}