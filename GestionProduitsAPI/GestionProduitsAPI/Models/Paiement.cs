using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionProduitsAPI.Models;

public partial class Paiement
{
    [Key]
    [Column("paiement_id")]
    public int PaiementId { get; set; }

    [Column("order_id")]
    public int? OrderId { get; set; }

    [Column("montant", TypeName = "decimal(10, 2)")]
    public decimal Montant { get; set; }

    [Column("date_paiement", TypeName = "datetime")]
    public DateTime? DatePaiement { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Paiements")]
    public virtual Commande? Order { get; set; }
}
