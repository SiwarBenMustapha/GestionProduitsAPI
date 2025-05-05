using System.Collections.Generic;
using System.Threading.Tasks;
using GestionProduitsAPI.Models;

namespace GestionProduitsAPI.Services.Interfaces
{
    public interface IProduitService
    {
        Task<Produit> AjouterProduitAsync(Produit produit);
        Task<List<Produit>> GetAllProduitsAsync();
        Task<Produit> GetProduitByIdAsync(int id);
        Task<Produit> UpdateProduitAsync(int id, Produit produit);
        Task<bool> DeleteProduitAsync(int id);
    }
}
