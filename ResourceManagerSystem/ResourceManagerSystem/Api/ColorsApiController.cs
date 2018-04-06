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
    [Route("api/ColorsApi")]
    public class ColorsApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColorsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ColorsApi
        [HttpGet]
        public IEnumerable<Color> GetColor()
        {
            return _context.Color;
        }

        // GET: api/ColorsApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColor( string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var color = await _context.Color.SingleOrDefaultAsync(m => m.ColorName == id);

            if (color == null)
            {
                return NotFound();
            }

            return Ok(color);
        }

        // PUT: api/ColorsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor( string id,  Color color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != color.ColorName)
            {
                return BadRequest();
            }

            _context.Entry(color).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(id))
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

        // POST: api/ColorsApi
        [HttpPost]
        public async Task<IActionResult> PostColor( Color color)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Color.Add(color);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ColorExists(color.ColorName))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetColor", new { id = color.ColorName }, color);
        }

        // DELETE: api/ColorsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor( string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var color = await _context.Color.SingleOrDefaultAsync(m => m.ColorName == id);
            if (color == null)
            {
                return NotFound();
            }

            _context.Color.Remove(color);
            await _context.SaveChangesAsync();

            return Ok(color);
        }

        private bool ColorExists(string id)
        {
            return _context.Color.Any(e => e.ColorName == id);
        }
    }
}