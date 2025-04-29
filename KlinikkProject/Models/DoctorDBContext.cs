using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KlinikkProject.Models;

public partial class DoctorDBContext : DbContext
{
    public DoctorDBContext()
    {
    }

    public DoctorDBContext(DbContextOptions<DoctorDBContext> options)
        : base(options)
    {
    }



    public virtual DbSet<Lægerne> Lægernes { get; set; }
    public virtual DbSet<Tider> Tiders { get; set; }
    public virtual DbSet<OurMember> OurMembers { get; set; }
    public virtual DbSet<Administrador> Administradors { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lægerne>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lægerne__3214EC07622B4B68");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tider__3214EC075521F444");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Lægerne).WithMany(p => p.Tiders).HasConstraintName("FK__Tider__Lægerne_I__267ABA7A");
        });
        modelBuilder.Entity<OurMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OurMembe__3214EC07F88291CD");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.HasOne(o => o.Lægerne).WithMany(o => o.OurMembers).HasConstraintName("FK__OurMember__Læger__36B12243");
        });
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Administ__3214EC07C437C507");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
