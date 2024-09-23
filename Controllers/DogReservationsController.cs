using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSSD_725_Week_4_Project.Models;

namespace MSSD_725_Week_4_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogReservationsController : ControllerBase
    {
        private readonly DogReservationContext _context;

        public DogReservationsController(DogReservationContext context)
        {
            _context = context;
        }

        // GET: api/DogReservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogReservation>>> GetDogReservations()
        {
            return await _context.DogReservations.ToListAsync();
        }

        // GET: api/DogReservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DogReservation>> GetDogReservation(int id)
        {
            var dogReservation = await _context.DogReservations.FindAsync(id);

            if (dogReservation == null)
            {
                return NotFound();
            }

            return dogReservation;
        }

        // PUT: api/DogReservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogReservation(int id, DogReservation dogReservation)
        {
            if (id != dogReservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(dogReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogReservationExists(id))
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

        // POST: api/DogReservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DogReservation>> PostDogReservation(DogReservation dogReservation)
        {
            _context.DogReservations.Add(dogReservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogReservation", new { id = dogReservation.Id }, dogReservation);
        }

        // DELETE: api/DogReservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogReservation(int id)
        {
            var dogReservation = await _context.DogReservations.FindAsync(id);
            if (dogReservation == null)
            {
                return NotFound();
            }

            _context.DogReservations.Remove(dogReservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogReservationExists(int id)
        {
            return _context.DogReservations.Any(e => e.Id == id);
        }
    }
}
