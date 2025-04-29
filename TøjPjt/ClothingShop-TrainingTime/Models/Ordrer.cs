using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop_TrainingTime.Models;

[Table("Ordrer")]
public partial class Ordrer
{
    [Key]
    [Column("OrdreID")]
    public int OrdreId { get; set; }

    [Column("KundeID")]
    public int? KundeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Dato { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? TotalPris { get; set; }

    [InverseProperty("Ordre")]
    public virtual ICollection<Betalinger> Betalingers { get; set; } = new List<Betalinger>();

    [ForeignKey("KundeId")]
    [InverseProperty("Ordrers")]
    public virtual Kunder? Kunde { get; set; }

    [InverseProperty("Ordre")]
    public virtual ICollection<Levering> Leverings { get; set; } = new List<Levering>();

    [InverseProperty("Ordre")]
    public virtual ICollection<OrdreLinjer> OrdreLinjers { get; set; } = new List<OrdreLinjer>();
}
