using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionProduitsAPI.Models;
using GestionProduitsAPI.Services;

namespace GestionProduitsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly ProduitService _produitService;

        // Injecte le service ProduitService
        public ProduitController(ProduitService produitService)
        {
            _produitService = produitService;
        }

        // GET: api/produit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produit>>> GetProduits()
        {
            var produits = await _produitService.GetAllProduitsAsync();
            return Ok(produits);
        }

        // GET: api/produit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produit>> GetProduit(int id)
        {
            var produit = await _produitService.GetProduitByIdAsync(id);
            if (produit == null)
            {
                return NotFound();
            }
            return Ok(produit);
        }

        // POST: api/produit
        [HttpPost]
        public async Task<ActionResult<Produit>> PostProduit(Produit produit)
        {
            var newProduit = await _produitService.AjouterProduitAsync(produit);
            return CreatedAtAction(nameof(GetProduit), new { id = newProduit.Id }, newProduit);
        }

        // PUT: api/produit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduit(int id, Produit produit)
        {
            var updatedProduit = await _produitService.UpdateProduitAsync(id, produit);
            if (updatedProduit == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/produit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduit(int id)
        {
            var result = await _produitService.DeleteProduitAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
