using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Model;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageLocationsController : ControllerBase
    {
        private readonly DataContext _context;

        public StorageLocationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/StorageLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageLocation>>> GetStorageLocations()
        {
            return await _context.StorageLocations.ToListAsync();
        }

        // GET: api/StorageLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StorageLocation>> GetStorageLocation(int id)
        {
            var storageLocation = await _context.StorageLocations.FindAsync(id);

            if (storageLocation == null)
            {
                return NotFound();
            }

            return storageLocation;
        }

        // PUT: api/StorageLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorageLocation(int id, StorageLocation storageLocation)
        {
            if (id != storageLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(storageLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageLocationExists(id))
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

        // POST: api/StorageLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StorageLocation>> PostStorageLocation(StorageLocation storageLocation)
        {
            _context.StorageLocations.Add(storageLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStorageLocation", new { id = storageLocation.Id }, storageLocation);
        }

        // DELETE: api/StorageLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageLocation(int id)
        {
            var storageLocation = await _context.StorageLocations.FindAsync(id);
            if (storageLocation == null)
            {
                return NotFound();
            }

            _context.StorageLocations.Remove(storageLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StorageLocationExists(int id)
        {
            return _context.StorageLocations.Any(e => e.Id == id);
        }
    }
}
