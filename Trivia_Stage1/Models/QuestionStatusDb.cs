using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

[Table("questionStatusDB")]
public partial class QuestionStatusDb
{
    [Key]
    [Column("QuestionStatusID")]
    public int QuestionStatusId { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = null!;

    [InverseProperty("QuestionStatus")]
    public virtual ICollection<QuestionsDb> QuestionsDbs { get; set; } = new List<QuestionsDb>();
}
