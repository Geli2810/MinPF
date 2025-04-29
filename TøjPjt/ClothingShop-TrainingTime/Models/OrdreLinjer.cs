using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop_TrainingTime.Models;

[Table("OrdreLinjer")]
public partial class OrdreLinjer
{
    [Key]
    [Column("OrdreLinjeID")]
    public int OrdreLinjeId { get; set; }

    [Column("OrdreID")]
    public int? OrdreId { get; set; }

    [Column("ProduktID")]
    public int? ProduktId { get; set; }

    public int? Antal { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Pris { get; set; }

    [ForeignKey("OrdreId")]
    [InverseProperty("OrdreLinjers")]
    public virtual Ordrer? Ordre { get; set; }

    [ForeignKey("ProduktId")]
    [InverseProperty("OrdreLinjers")]
    public virtual Produkter? Produkt { get; set; }
}
