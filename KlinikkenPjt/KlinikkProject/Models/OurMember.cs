using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KlinikkProject.Models;

[Table("OurMembers")]
public partial class OurMember
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string MemberName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string MemberLastName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string MemberEmail { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string MemberPassword { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string MemberAddress { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string MemberCity { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string MemberZipCode { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string MemberPhone { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string MemberSituation { get; set; } = null!;

    [Column("Lægerne_Id")]
    public int? LægerneId { get; set; }
    [ForeignKey("LægerneId")]
    [InverseProperty("OurMembers")]
    public virtual Lægerne? Lægerne { get; set; }
}
