using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceManagerSystem.Data;
using ResourceManagerSystem.Models;

namespace ResourceManagerSystem.Api
{
    [Produces("application/json")]
    [Route("api/SizesApi")]
    public class SizesApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SizesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SizesApi
        [HttpGet]
        public IEnumerable<Size> GetSize()
        {
            return _context.Size;
        }

        // GET: api/SizesApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSize( string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var size = await _context.Size.SingleOrDefaultAsync(m => m.SizeName == id);

            if (size == null)
            {
                return NotFound();
            }

            return Ok(size);
        }

        // PUT: api/SizesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSize( string id,  Size size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != size.SizeName)
            {
                return BadRequest();
            }

            _context.Entry(size).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeExists(id))
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

        // POST: api/SizesApi
        [HttpPost]
        public async Task<IActionResult> PostSize( Size size)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Size.Add(size);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SizeExists(size.SizeName))
                {
                    
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSize", new { id = size.SizeName }, size);
        }

        // DELETE: api/SizesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSize( string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var size = await _context.Size.SingleOrDefaultAsync(m => m.SizeName == id);
            if (size == null)
            {
                return NotFound();
            }

            _context.Size.Remove(size);
            await _context.SaveChangesAsync();

            return Ok(size);
        }

        private bool SizeExists(string id)
        {
            return _context.Size.Any(e => e.SizeName == id);
        }
    }
}