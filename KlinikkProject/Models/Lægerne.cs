using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KlinikkProject.Models;

[Table("Lægerne")]
public partial class Lægerne
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Navn { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string? Telefonnr { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Adresse { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? PostNr { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Afdeling { get; set; }

    [InverseProperty("Lægerne")]
    public virtual ICollection<Tider> Tiders { get; set; } = new List<Tider>();

    [InverseProperty("Lægerne")]
    public virtual ICollection<OurMember> OurMembers { get; set; } = new List<OurMember>();



}
