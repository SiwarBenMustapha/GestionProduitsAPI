using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionProduitsAPI.Models;

public partial class Achat
{
    [Key]
    [Column("achat_id")]
    public int AchatId { get; set; }

    [Column("produit_id")]
    public int? ProduitId { get; set; }

    [Column("fournisseur_id")]
    public int? FournisseurId { get; set; }

    [Column("quantite")]
    public int Quantite { get; set; }

    [Column("prix_achat", TypeName = "decimal(10, 2)")]
    public decimal PrixAchat { get; set; }

    [Column("date_achat", TypeName = "datetime")]
    public DateTime? DateAchat { get; set; }

    [ForeignKey("FournisseurId")]
    [InverseProperty("Achats")]
    public virtual Fournisseur? Fournisseur { get; set; }

    [ForeignKey("ProduitId")]
    [InverseProperty("Achats")]
    public virtual Produit? Produit { get; set; }
}
