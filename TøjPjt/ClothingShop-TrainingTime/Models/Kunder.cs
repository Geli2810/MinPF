using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop_TrainingTime.Models;

[Table("Kunder")]
public partial class Kunder
{
    [Key]
    [Column("KundeID")]
    public int KundeId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Navn { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefon { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Adresse { get; set; }

    [InverseProperty("Kunde")]
    public virtual ICollection<Ordrer> Ordrers { get; set; } = new List<Ordrer>();
}
