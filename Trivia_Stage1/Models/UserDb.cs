using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

[Table("userDB")]
[Index("UserMail", Name = "UQ__userDB__52ABC69BE9A9F324", IsUnique = true)]
public partial class UserDb
{
    [Key]
    public int UserId { get; set; }

    [StringLength(30)]
    public string UserMail { get; set; } = null!;

    [StringLength(20)]
    public string UserName { get; set; } = null!;

    [Column("UserRankID")]
    public int UserRankId { get; set; }


    private int _score;
    public int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score += value;
            if (_score > 100)
            {
                _score = 100;
            }
        }
    }
    [Column("password")]
    [StringLength(50)]
    public string? Password { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<QuestionsDb> QuestionsDbs { get; set; } = new List<QuestionsDb>();

    [ForeignKey("UserRankId")]
    [InverseProperty("UserDbs")]
    public virtual UserRankDb UserRank { get; set; } = null!;
}
