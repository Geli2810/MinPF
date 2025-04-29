using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop_TrainingTime.Models;

[Table("Produkter")]
public partial class Produkter
{
    [Key]
    [Column("ProduktID")]
    public int ProduktId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Navn { get; set; }

    [Column(TypeName = "text")]
    public string? Beskrivelse { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Pris { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Størrelse { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Farve { get; set; }

    public int? LagerAntal { get; set; }
    public string? BilledeUrl { get; set; }


    [Column("KategoriID")]
    public int? KategoriId { get; set; }

    [ForeignKey("KategoriId")]
    [InverseProperty("Produkters")]
    public virtual Kategorier? Kategori { get; set; }

    [InverseProperty("Produkt")]
    public virtual ICollection<OrdreLinjer> OrdreLinjers { get; set; } = new List<OrdreLinjer>();
}
