using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionProduitsAPI.Models;

public partial class Fournisseur
{
    [Key]
    [Column("fournisseur_id")]
    public int FournisseurId { get; set; }

    [Column("nom")]
    [StringLength(255)]
    [Unicode(false)]
    public string Nom { get; set; } = null!;

    [Column("adresse", TypeName = "text")]
    public string? Adresse { get; set; }

    [InverseProperty("Fournisseur")]
    public virtual ICollection<Achat> Achats { get; set; } = new List<Achat>();
}
