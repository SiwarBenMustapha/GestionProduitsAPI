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
    public class DetailsCommandesController : ControllerBase
    {
        private readonly GestionProduitsDbContext _context;

        public DetailsCommandesController(GestionProduitsDbContext context)
        {
            _context = context;
        }

        // GET: api/DetailsCommandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailsCommande>>> GetDetailsCommandes()
        {
            return await _context.DetailsCommandes.ToListAsync();
        }

        // GET: api/DetailsCommandes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailsCommande>> GetDetailsCommande(int id)
        {
            var detailsCommande = await _context.DetailsCommandes.FindAsync(id);

            if (detailsCommande == null)
            {
                return NotFound();
            }

            return detailsCommande;
        }

        // PUT: api/DetailsCommandes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailsCommande(int id, DetailsCommande detailsCommande)
        {
            if (id != detailsCommande.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(detailsCommande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailsCommandeExists(id))
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

        // POST: api/DetailsCommandes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetailsCommande>> PostDetailsCommande(DetailsCommande detailsCommande)
        {
            _context.DetailsCommandes.Add(detailsCommande);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DetailsCommandeExists(detailsCommande.OrderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetailsCommande", new { id = detailsCommande.OrderId }, detailsCommande);
        }

        // DELETE: api/DetailsCommandes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailsCommande(int id)
        {
            var detailsCommande = await _context.DetailsCommandes.FindAsync(id);
            if (detailsCommande == null)
            {
                return NotFound();
            }

            _context.DetailsCommandes.Remove(detailsCommande);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailsCommandeExists(int id)
        {
            return _context.DetailsCommandes.Any(e => e.OrderId == id);
        }
    }
}
