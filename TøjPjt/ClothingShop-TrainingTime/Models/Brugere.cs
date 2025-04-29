using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop_TrainingTime.Models;

[Table("Brugere")]
public partial class Brugere
{
    [Key]
    [Column("BrugerID")]
    public int BrugerId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Brugernavn { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Adgangskode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Rolle { get; set; }
}
