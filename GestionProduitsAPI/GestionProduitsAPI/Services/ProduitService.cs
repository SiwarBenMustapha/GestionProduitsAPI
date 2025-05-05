using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionProduitsAPI.Data;  
using GestionProduitsAPI.Models;
using GestionProduitsAPI.Services.Interfaces;

namespace GestionProduitsAPI.Services
{
    public class ProduitService : IProduitService
    {
        private readonly GestionProduitsDbContext _context;

        public ProduitService(GestionProduitsDbContext context)
        {
            _context = context;
        }

        // Créer un produit
      /*  public async Task<Produit> AjouterProduitAsync(Produit produit)
        {
            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();
            return produit;
        }
      */

        // Validation avant ajout
        public async Task<Produit> AjouterProduitAsync(Produit produit)
        {
            if (produit.Prix <= 0)
            {
                throw new ArgumentException("Le prix doit être positif.");
            }

            if (produit.QuantiteStock < 0)
            {
                throw new ArgumentException("La quantité en stock ne peut pas être négative.");
            }

            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();
            return produit;
        }

        // Récupérer tous les produits
        public async Task<List<Produit>> GetAllProduitsAsync()
        {
            return await _context.Produits.ToListAsync();
        }

        // Récupérer un produit par son ID
        public async Task<Produit> GetProduitByIdAsync(int id)
        {
            return await _context.Produits.FindAsync(id);
        }

        // Mettre à jour un produit
        public async Task<Produit> UpdateProduitAsync(int id, Produit produit)
        {
            var produitExist = await _context.Produits.FindAsync(id);
            if (produitExist == null)
            {
                return null; // Ou tu peux lever une exception si nécessaire
            }

            produitExist.Nom = produit.Nom;
            produitExist.Description = produit.Description;
            produitExist.Prix = produit.Prix;
            produitExist.QuantiteStock = produit.QuantiteStock;

            await _context.SaveChangesAsync();
            return produitExist;
        }

        // Supprimer un produit
        public async Task<bool> DeleteProduitAsync(int id)
        {
            var produitExist = await _context.Produits.FindAsync(id);
            if (produitExist == null)
            {
                return false;
            }

            _context.Produits.Remove(produitExist);
            await _context.SaveChangesAsync();
            return true;
        }



      


    }
}
