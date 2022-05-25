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
    public class DogShowsController : ControllerBase
    {
        private readonly DataContext _context;

        public DogShowsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DogShows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogShow>>> GetDogShows()
        {
          if (_context.DogShows == null)
          {
              return NotFound();
          }

          return await _context.DogShows.Include(d => d.Address).ToListAsync();
        }

        // GET: api/DogShows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogShow>> GetDogShow(int id)
        {
          if (_context.DogShows == null)
          {
              return NotFound();
          }
            var dogShow = await _context.DogShows
                .Include(d => d.Address)
                .FirstOrDefaultAsync(dog => dog.Id == id);


            if (dogShow == null)
            {
                return NotFound();
            }

            return dogShow;
        }

        // PUT: api/DogShows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogShow(int id, DogShow dogShow)
        {
            if (id != dogShow.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogShow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogShowExists(id))
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

        // POST: api/DogShows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogShow>> PostDogShow(DogShow dogShow)
        {
          if (_context.DogShows == null)
          {
              return Problem("Entity set 'DataContext.DogShows'  is null.");
          }
            _context.DogShows.Add(dogShow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogShow", new { id = dogShow.Id }, dogShow);
        }

        // DELETE: api/DogShows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogShow(int id)
        {
            if (_context.DogShows == null)
            {
                return NotFound();
            }
            var dogShow = await _context.DogShows.FindAsync(id);
            if (dogShow == null)
            {
                return NotFound();
            }

            _context.DogShows.Remove(dogShow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogShowExists(int id)
        {
            return (_context.DogShows?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
