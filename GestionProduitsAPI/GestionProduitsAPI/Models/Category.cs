using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionProduitsAPI.Models;

public partial class Category
{
    [Key]
    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("category_name")]
    [StringLength(1)]
    [Unicode(false)]
    public string? CategoryName { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();
}
