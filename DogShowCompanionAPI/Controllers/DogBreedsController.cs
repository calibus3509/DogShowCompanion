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
    public class DogBreedsController : ControllerBase
    {
        private readonly DataContext _context;

        public DogBreedsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DogBreeds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogBreed>>> GetDogBreeds()
        {
          if (_context.DogBreeds == null)
          {
              return NotFound();
          }
            return await _context.DogBreeds.ToListAsync();
        }

        // GET: api/DogBreeds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogBreed>> GetDogBreed(int id)
        {
          if (_context.DogBreeds == null)
          {
              return NotFound();
          }
            var dogBreed = await _context.DogBreeds.FindAsync(id);

            if (dogBreed == null)
            {
                return NotFound();
            }

            return dogBreed;
        }

        // PUT: api/DogBreeds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogBreed(int id, DogBreed dogBreed)
        {
            if (id != dogBreed.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogBreed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogBreedExists(id))
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

        // POST: api/DogBreeds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogBreed>> PostDogBreed(DogBreed dogBreed)
        {
          if (_context.DogBreeds == null)
          {
              return Problem("Entity set 'DataContext.DogBreeds'  is null.");
          }
            _context.DogBreeds.Add(dogBreed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogBreed", new { id = dogBreed.Id }, dogBreed);
        }

        // DELETE: api/DogBreeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogBreed(int id)
        {
            if (_context.DogBreeds == null)
            {
                return NotFound();
            }
            var dogBreed = await _context.DogBreeds.FindAsync(id);
            if (dogBreed == null)
            {
                return NotFound();
            }

            _context.DogBreeds.Remove(dogBreed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogBreedExists(int id)
        {
            return (_context.DogBreeds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
