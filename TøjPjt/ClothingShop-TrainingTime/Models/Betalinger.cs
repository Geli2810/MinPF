using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop_TrainingTime.Models;

[Table("Betalinger")]
public partial class Betalinger
{
    [Key]
    [Column("BetalingID")]
    public int BetalingId { get; set; }

    [Column("OrdreID")]
    public int? OrdreId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BetalingsMetode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BetalingsDato { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Beløb { get; set; }

    [ForeignKey("OrdreId")]
    [InverseProperty("Betalingers")]
    public virtual Ordrer? Ordre { get; set; }
}
