using Xunit;
using GestionProduitsAPI.Models;
using GestionProduitsAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GestionProduitsAPI.Data;

public class ProduitServiceTests
{
    private readonly ProduitService _produitService;
    private readonly GestionProduitsDbContext _context;

    public ProduitServiceTests()
    {
        // 1. Configuration de la base en mémoire
        var options = new DbContextOptionsBuilder<GestionProduitsDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        // 2. Création du contexte
        _context = new GestionProduitsDbContext(options);

        // 3. Création du service à tester
        _produitService = new ProduitService(_context);
    }

    [Fact]
    public async Task AjouterProduitAsync_AjouteLeProduitAvecSuccès()
    {
        // Arrange
        var produit = new Produit
        {
            Nom = "TestProduit",
            Description = "Description Test",
            Prix = 99.99m,
            QuantiteStock = 10
        };

        // Act
        await _produitService.AjouterProduitAsync(produit);

        // Assert
        var produitDansDb = await _context.Produits.FirstOrDefaultAsync(p => p.Nom == "TestProduit");
        Assert.NotNull(produitDansDb);
        Assert.Equal(99.99m, produitDansDb.Prix);
    }
}
