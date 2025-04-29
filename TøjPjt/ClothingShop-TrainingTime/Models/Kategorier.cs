using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClothingShop_TrainingTime.Models;

[Table("Kategorier")]
public partial class Kategorier
{
    [Key]
    [Column("KategoriID")]
    public int KategoriId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Navn { get; set; }

    [InverseProperty("Kategori")]
    public virtual ICollection<Produkter> Produkters { get; set; } = new List<Produkter>();
}
