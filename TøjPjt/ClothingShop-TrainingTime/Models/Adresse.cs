using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop_TrainingTime.Models;

[Table("Adresse")]
public partial class Adresse
{
    [Key]
    [Column("AdresseID")]
    public int AdresseId { get; set; }

    [StringLength(100)]
    public string Vejnavn { get; set; } = null!;

    [StringLength(10)]
    public string Postnummer { get; set; } = null!;

    [StringLength(50)]
    public string City { get; set; } = null!;

    [Column("BrugerID")]
    public int BrugerId { get; set; }
}
