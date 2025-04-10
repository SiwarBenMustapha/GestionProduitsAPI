using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionProduitsAPI.Models;

public partial class Commande
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Column("order_date", TypeName = "datetime")]
    public DateTime? OrderDate { get; set; }

    [Column("customer_name")]
    [StringLength(255)]
    [Unicode(false)]
    public string CustomerName { get; set; } = null!;

    [Column("total_amount", TypeName = "decimal(10, 2)")]
    public decimal TotalAmount { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<DetailsCommande> DetailsCommandes { get; set; } = new List<DetailsCommande>();

    [InverseProperty("Order")]
    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
}
