using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

[Table("userRankDB")]
public partial class UserRankDb
{
    [Key]
    [Column("UserRankID")]
    public int UserRankId { get; set; }

    [StringLength(20)]
    public string RankName { get; set; } = null!;

    [InverseProperty("UserRank")]
    public virtual ICollection<UserDb> UserDbs { get; set; } = new List<UserDb>();
}
