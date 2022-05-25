using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DogShowCompanionAPI.Data;
using DogShowCompanionAPI.Models;

namespace DogShowCompanionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KennelsController : ControllerBase
    {
        private readonly DataContext _context;

        public KennelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Kennels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kennel>>> GetKennels()
        {
          if (_context.Kennels == null)
          {
              return NotFound();
          }
            return await _context.Kennels.ToListAsync();
        }

        // GET: api/Kennels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kennel>> GetKennel(int id)
        {
          if (_context.Kennels == null)
          {
              return NotFound();
          }
            var kennel = await _context.Kennels.FindAsync(id);

            if (kennel == null)
            {
                return NotFound();
            }

            return kennel;
        }

        // PUT: api/Kennels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKennel(int id, Kennel kennel)
        {
            if (id != kennel.Id)
            {
                return BadRequest();
            }

            _context.Entry(kennel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KennelExists(id))
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

        // POST: api/Kennels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kennel>> PostKennel(Kennel kennel)
        {
          if (_context.Kennels == null)
          {
              return Problem("Entity set 'DataContext.Kennels'  is null.");
          }
            _context.Kennels.Add(kennel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKennel", new { id = kennel.Id }, kennel);
        }

        // DELETE: api/Kennels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKennel(int id)
        {
            if (_context.Kennels == null)
            {
                return NotFound();
            }
            var kennel = await _context.Kennels.FindAsync(id);
            if (kennel == null)
            {
                return NotFound();
            }

            _context.Kennels.Remove(kennel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KennelExists(int id)
        {
            return (_context.Kennels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
