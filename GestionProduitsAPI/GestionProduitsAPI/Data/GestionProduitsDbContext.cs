using System;
using System.Collections.Generic;
using GestionProduitsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionProduitsAPI.Data;

public partial class GestionProduitsDbContext : DbContext
{
    public GestionProduitsDbContext()
    {
    }

    public GestionProduitsDbContext(DbContextOptions<GestionProduitsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achat> Achats { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Commande> Commandes { get; set; }

    public virtual DbSet<DetailsCommande> DetailsCommandes { get; set; }

    public virtual DbSet<Fournisseur> Fournisseurs { get; set; }

    public virtual DbSet<Paiement> Paiements { get; set; }

    public virtual DbSet<Produit> Produits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        { 
            optionsBuilder.UseSqlServer("Server=tcp:gestionproduits-server.database.windows.net,1433;Database=GestionProduitsDB;User Id=adminazure;Password=Siwar*2025;Encrypt=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achat>(entity =>
        {
            entity.HasKey(e => e.AchatId).HasName("PK__Achats__E7FF291662BB997D");

            entity.Property(e => e.DateAchat).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Fournisseur).WithMany(p => p.Achats).HasConstraintName("FK__Achats__fourniss__10566F31");

            entity.HasOne(d => d.Produit).WithMany(p => p.Achats).HasConstraintName("FK__Achats__produit___0F624AF8");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__D54EE9B4E57AABF8");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__BF21A4244BCAC740");
        });

        modelBuilder.Entity<Commande>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Commande__4659622907854C0D");

            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DetailsCommande>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__Details___022945F647970F1E");

            entity.HasOne(d => d.Order).WithMany(p => p.DetailsCommandes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details_C__order__08B54D69");

            entity.HasOne(d => d.Product).WithMany(p => p.DetailsCommandes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Details_C__produ__09A971A2");
        });

        modelBuilder.Entity<Fournisseur>(entity =>
        {
            entity.HasKey(e => e.FournisseurId).HasName("PK__Fourniss__BDBA7AF087FC390F");
        });

        modelBuilder.Entity<Paiement>(entity =>
        {
            entity.HasKey(e => e.PaiementId).HasName("PK__Paiement__6C6B0C31C8D7361F");

            entity.Property(e => e.DatePaiement).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Order).WithMany(p => p.Paiements).HasConstraintName("FK__Paiements__order__14270015");
        });

        modelBuilder.Entity<Produit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produits__3214EC07A5F3CB2C");

            entity.HasOne(d => d.Category).WithMany(p => p.Produits).HasConstraintName("FK_Produit_Category");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
