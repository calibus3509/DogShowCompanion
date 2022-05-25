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
    public class DogGroupsController : ControllerBase
    {
        private readonly DataContext _context;

        public DogGroupsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DogGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogGroup>>> GetDogGroup()
        {
          if (_context.DogGroup == null)
          {
              return NotFound();
          }
            return await _context.DogGroup.ToListAsync();
        }

        // GET: api/DogGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogGroup>> GetDogGroup(int id)
        {
          if (_context.DogGroup == null)
          {
              return NotFound();
          }
            var dogGroup = await _context.DogGroup.FindAsync(id);

            if (dogGroup == null)
            {
                return NotFound();
            }

            return dogGroup;
        }

        // PUT: api/DogGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogGroup(int id, DogGroup dogGroup)
        {
            if (id != dogGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogGroupExists(id))
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

        // POST: api/DogGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogGroup>> PostDogGroup(DogGroup dogGroup)
        {
          if (_context.DogGroup == null)
          {
              return Problem("Entity set 'DataContext.DogGroup'  is null.");
          }
            _context.DogGroup.Add(dogGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogGroup", new { id = dogGroup.Id }, dogGroup);
        }

        // DELETE: api/DogGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogGroup(int id)
        {
            if (_context.DogGroup == null)
            {
                return NotFound();
            }
            var dogGroup = await _context.DogGroup.FindAsync(id);
            if (dogGroup == null)
            {
                return NotFound();
            }

            _context.DogGroup.Remove(dogGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogGroupExists(int id)
        {
            return (_context.DogGroup?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
