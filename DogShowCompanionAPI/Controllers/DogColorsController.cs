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
    public class DogColorsController : ControllerBase
    {
        private readonly DataContext _context;

        public DogColorsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DogColors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogColor>>> GetDogColors()
        {
          if (_context.DogColors == null)
          {
              return NotFound();
          }
            return await _context.DogColors.ToListAsync();
        }

        // GET: api/DogColors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogColor>> GetDogColor(int id)
        {
          if (_context.DogColors == null)
          {
              return NotFound();
          }
            var dogColor = await _context.DogColors.FindAsync(id);

            if (dogColor == null)
            {
                return NotFound();
            }

            return dogColor;
        }

        // PUT: api/DogColors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogColor(int id, DogColor dogColor)
        {
            if (id != dogColor.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogColorExists(id))
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

        // POST: api/DogColors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogColor>> PostDogColor(DogColor dogColor)
        {
          if (_context.DogColors == null)
          {
              return Problem("Entity set 'DataContext.DogColors'  is null.");
          }
            _context.DogColors.Add(dogColor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogColor", new { id = dogColor.Id }, dogColor);
        }

        // DELETE: api/DogColors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogColor(int id)
        {
            if (_context.DogColors == null)
            {
                return NotFound();
            }
            var dogColor = await _context.DogColors.FindAsync(id);
            if (dogColor == null)
            {
                return NotFound();
            }

            _context.DogColors.Remove(dogColor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogColorExists(int id)
        {
            return (_context.DogColors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
