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
    public class DogShowClassesController : ControllerBase
    {
        private readonly DataContext _context;

        public DogShowClassesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DogShowClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogShowClass>>> GetDogShowClasses()
        {
          if (_context.DogShowClasses == null)
          {
              return NotFound();
          }
            return await _context.DogShowClasses.ToListAsync();
        }

        // GET: api/DogShowClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogShowClass>> GetDogShowClass(int id)
        {
          if (_context.DogShowClasses == null)
          {
              return NotFound();
          }
            var dogShowClass = await _context.DogShowClasses.FindAsync(id);

            if (dogShowClass == null)
            {
                return NotFound();
            }

            return dogShowClass;
        }

        // PUT: api/DogShowClasses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogShowClass(int id, DogShowClass dogShowClass)
        {
            if (id != dogShowClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogShowClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogShowClassExists(id))
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

        // POST: api/DogShowClasses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogShowClass>> PostDogShowClass(DogShowClass dogShowClass)
        {
          if (_context.DogShowClasses == null)
          {
              return Problem("Entity set 'DataContext.DogShowClasses'  is null.");
          }
            _context.DogShowClasses.Add(dogShowClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogShowClass", new { id = dogShowClass.Id }, dogShowClass);
        }

        // DELETE: api/DogShowClasses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogShowClass(int id)
        {
            if (_context.DogShowClasses == null)
            {
                return NotFound();
            }
            var dogShowClass = await _context.DogShowClasses.FindAsync(id);
            if (dogShowClass == null)
            {
                return NotFound();
            }

            _context.DogShowClasses.Remove(dogShowClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogShowClassExists(int id)
        {
            return (_context.DogShowClasses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
