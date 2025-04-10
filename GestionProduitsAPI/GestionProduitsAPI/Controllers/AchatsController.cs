using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionProduitsAPI.Data;
using GestionProduitsAPI.Models;

namespace GestionProduitsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchatsController : ControllerBase
    {
        private readonly GestionProduitsDbContext _context;

        public AchatsController(GestionProduitsDbContext context)
        {
            _context = context;
        }

        // GET: api/Achats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Achat>>> GetAchats()
        {
            return await _context.Achats.ToListAsync();
        }

        // GET: api/Achats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Achat>> GetAchat(int id)
        {
            var achat = await _context.Achats.FindAsync(id);

            if (achat == null)
            {
                return NotFound();
            }

            return achat;
        }

        // PUT: api/Achats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAchat(int id, Achat achat)
        {
            if (id != achat.AchatId)
            {
                return BadRequest();
            }

            _context.Entry(achat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AchatExists(id))
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

        // POST: api/Achats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Achat>> PostAchat(Achat achat)
        {
            _context.Achats.Add(achat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAchat", new { id = achat.AchatId }, achat);
        }

        // DELETE: api/Achats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAchat(int id)
        {
            var achat = await _context.Achats.FindAsync(id);
            if (achat == null)
            {
                return NotFound();
            }

            _context.Achats.Remove(achat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AchatExists(int id)
        {
            return _context.Achats.Any(e => e.AchatId == id);
        }
    }
}
