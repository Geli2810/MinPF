using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop_TrainingTime.Models;

[Table("Annoncer")]
public partial class Annoncer
{
    [Key]
    [Column("AnnonceID")]
    public int AnnonceId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Titel { get; set; }

    [Column(TypeName = "text")]
    public string? Beskrivelse { get; set; }

    public DateOnly? StartDato { get; set; }

    public DateOnly? SlutDato { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? KampagnePris { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? RabatProcent { get; set; }

    public bool? IsAktiv { get; set; }

    [Column("ProduktID")]
    public int? ProduktId { get; set; }

    [Column("BrugerID")]
    public int? BrugerId { get; set; }

    [Column("BilledeURL")]
    [StringLength(255)]
    [Unicode(false)]
    public string? BilledeUrl { get; set; }
}
