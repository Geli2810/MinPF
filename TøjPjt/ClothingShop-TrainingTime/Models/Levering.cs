using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop_TrainingTime.Models;

[Table("Levering")]
public partial class Levering
{
    [Key]
    [Column("LeveringID")]
    public int LeveringId { get; set; }

    [Column("OrdreID")]
    public int? OrdreId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LeveringsStatus { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TrackingNummer { get; set; }

    public DateOnly? ForventetLeveringDato { get; set; }

    [ForeignKey("OrdreId")]
    [InverseProperty("Leverings")]
    public virtual Ordrer? Ordre { get; set; }
}
