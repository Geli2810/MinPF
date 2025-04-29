using System;
using System.Collections.Generic;
using ClothingShop_TrainingTime.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop_TrainingTime.Data;

public partial class ClothDBContext : DbContext
{
    public ClothDBContext()
    {
    }

    public ClothDBContext(DbContextOptions<ClothDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Betalinger> Betalingers { get; set; }

    public virtual DbSet<Brugere> Brugeres { get; set; }

    public virtual DbSet<Kategorier> Kategoriers { get; set; }

    public virtual DbSet<Kunder> Kunders { get; set; }

    public virtual DbSet<Levering> Leverings { get; set; }

    public virtual DbSet<OrdreLinjer> OrdreLinjers { get; set; }

    public virtual DbSet<Ordrer> Ordrers { get; set; }

    public virtual DbSet<Produkter> Produkters { get; set; }
    public virtual DbSet<Annoncer> Annoncers { get; set; }

    public virtual DbSet<Adresse> Adresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ChlothingDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Betalinger>(entity =>
        {
            entity.HasKey(e => e.BetalingId).HasName("PK__Betaling__8D28AE9589B25846");

            entity.Property(e => e.BetalingsDato).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Ordre).WithMany(p => p.Betalingers).HasConstraintName("FK__Betalinge__Ordre__45F365D3");
        });

        modelBuilder.Entity<Brugere>(entity =>
        {
            entity.HasKey(e => e.BrugerId).HasName("PK__Brugere__6FA2FB3029D58A44");
        });

        modelBuilder.Entity<Kategorier>(entity =>
        {
            entity.HasKey(e => e.KategoriId).HasName("PK__Kategori__1782CC92370758EB");
        });

        modelBuilder.Entity<Kunder>(entity =>
        {
            entity.HasKey(e => e.KundeId).HasName("PK__Kunder__7F871DE10A3CAF99");
        });

        modelBuilder.Entity<Levering>(entity =>
        {
            entity.HasKey(e => e.LeveringId).HasName("PK__Levering__1713251872BAFBBF");

            entity.HasOne(d => d.Ordre).WithMany(p => p.Leverings).HasConstraintName("FK__Levering__OrdreI__48CFD27E");
        });

        modelBuilder.Entity<OrdreLinjer>(entity =>
        {
            entity.HasKey(e => e.OrdreLinjeId).HasName("PK__OrdreLin__EFA5281CC09B84E3");

            entity.HasOne(d => d.Ordre).WithMany(p => p.OrdreLinjers).HasConstraintName("FK__OrdreLinj__Ordre__3E52440B");

            entity.HasOne(d => d.Produkt).WithMany(p => p.OrdreLinjers).HasConstraintName("FK__OrdreLinj__Produ__3F466844");
        });

        modelBuilder.Entity<Ordrer>(entity =>
        {
            entity.HasKey(e => e.OrdreId).HasName("PK__Ordrer__1B4D5C76136808F8");

            entity.Property(e => e.Dato).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Kunde).WithMany(p => p.Ordrers).HasConstraintName("FK__Ordrer__KundeID__3B75D760");
        });

        modelBuilder.Entity<Produkter>(entity =>
        {
            entity.HasKey(e => e.ProduktId).HasName("PK__Produkte__F1FF3022206AB4A5");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Produkters).HasConstraintName("FK__Produkter__Kateg__4222D4EF");
        });

        modelBuilder.Entity<Annoncer>(entity =>
        {
            entity.HasKey(e => e.AnnonceId).HasName("PK__Annoncer__853EBAE93D6C1B3D");

        });

        modelBuilder.Entity<Adresse>(entity =>
        {
            entity.HasKey(e => e.AdresseId).HasName("PK__Adresse__C3F7F1947704292B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
