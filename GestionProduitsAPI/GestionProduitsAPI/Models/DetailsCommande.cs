using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionProduitsAPI.Models;

[PrimaryKey("OrderId", "ProductId")]
[Table("Details_Commandes")]
public partial class DetailsCommande
{
    [Key]
    [Column("order_id")]
    public int OrderId { get; set; }

    [Key]
    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("price", TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("DetailsCommandes")]
    public virtual Commande Order { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("DetailsCommandes")]
    public virtual Produit Product { get; set; } = null!;
}
