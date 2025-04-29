using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KlinikkProject.Models;

[Table("Tider")]
public partial class Tider
{
    [Key]
    public int Id { get; set; }

    public DateOnly Dato { get; set; }

    public TimeOnly Tidspunkt { get; set; }

    [Column("Lægerne_Id")]
    public int? LægerneId { get; set; }

    [ForeignKey("LægerneId")]
    [InverseProperty("Tiders")]
    public virtual Lægerne? Lægerne { get; set; }
}
