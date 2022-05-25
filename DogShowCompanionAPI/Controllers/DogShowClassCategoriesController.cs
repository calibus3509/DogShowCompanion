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
    public class DogShowClassCategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public DogShowClassCategoriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DogShowClassCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogShowClassCategory>>> GetDogShowClassCategories()
        {
          if (_context.DogShowClassCategories == null)
          {
              return NotFound();
          }
            return await _context.DogShowClassCategories.ToListAsync();
        }

        // GET: api/DogShowClassCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogShowClassCategory>> GetDogShowClassCategory(int id)
        {
          if (_context.DogShowClassCategories == null)
          {
              return NotFound();
          }
            var dogShowClassCategory = await _context.DogShowClassCategories.FindAsync(id);

            if (dogShowClassCategory == null)
            {
                return NotFound();
            }

            return dogShowClassCategory;
        }

        // PUT: api/DogShowClassCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogShowClassCategory(int id, DogShowClassCategory dogShowClassCategory)
        {
            if (id != dogShowClassCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogShowClassCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogShowClassCategoryExists(id))
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

        // POST: api/DogShowClassCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogShowClassCategory>> PostDogShowClassCategory(DogShowClassCategory dogShowClassCategory)
        {
          if (_context.DogShowClassCategories == null)
          {
              return Problem("Entity set 'DataContext.DogShowClassCategories'  is null.");
          }
            _context.DogShowClassCategories.Add(dogShowClassCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogShowClassCategory", new { id = dogShowClassCategory.Id }, dogShowClassCategory);
        }

        // DELETE: api/DogShowClassCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogShowClassCategory(int id)
        {
            if (_context.DogShowClassCategories == null)
            {
                return NotFound();
            }
            var dogShowClassCategory = await _context.DogShowClassCategories.FindAsync(id);
            if (dogShowClassCategory == null)
            {
                return NotFound();
            }

            _context.DogShowClassCategories.Remove(dogShowClassCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogShowClassCategoryExists(int id)
        {
            return (_context.DogShowClassCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
