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
    public class DogTraitsController : ControllerBase
    {
        private readonly DataContext _context;

        public DogTraitsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DogTraits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogTrait>>> GetDogTraits()
        {
          if (_context.DogTraits == null)
          {
              return NotFound();
          }
            return await _context.DogTraits.ToListAsync();
        }

        // GET: api/DogTraits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogTrait>> GetDogTrait(int id)
        {
          if (_context.DogTraits == null)
          {
              return NotFound();
          }
            var dogTrait = await _context.DogTraits.FindAsync(id);

            if (dogTrait == null)
            {
                return NotFound();
            }

            return dogTrait;
        }

        // PUT: api/DogTraits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogTrait(int id, DogTrait dogTrait)
        {
            if (id != dogTrait.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogTrait).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogTraitExists(id))
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

        // POST: api/DogTraits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogTrait>> PostDogTrait(DogTrait dogTrait)
        {
          if (_context.DogTraits == null)
          {
              return Problem("Entity set 'DataContext.DogTraits'  is null.");
          }
            _context.DogTraits.Add(dogTrait);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogTrait", new { id = dogTrait.Id }, dogTrait);
        }

        // DELETE: api/DogTraits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogTrait(int id)
        {
            if (_context.DogTraits == null)
            {
                return NotFound();
            }
            var dogTrait = await _context.DogTraits.FindAsync(id);
            if (dogTrait == null)
            {
                return NotFound();
            }

            _context.DogTraits.Remove(dogTrait);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogTraitExists(int id)
        {
            return (_context.DogTraits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
