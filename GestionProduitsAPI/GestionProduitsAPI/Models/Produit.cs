using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionProduitsAPI.Models;

public partial class Produit
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nom { get; set; } = null!;

    [StringLength(255)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Prix { get; set; }

    public int QuantiteStock { get; set; }

    [Column("category_id")]
    public int? CategoryId { get; set; }

    [InverseProperty("Produit")]
    public virtual ICollection<Achat> Achats { get; set; } = new List<Achat>();

    [ForeignKey("CategoryId")]
    [InverseProperty("Produits")]
    public virtual Category? Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<DetailsCommande> DetailsCommandes { get; set; } = new List<DetailsCommande>();
}
