using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

[Table("subjectDB")]
public partial class SubjectDb
{
    [Key]
    [Column("SubjectID")]
    public int SubjectId { get; set; }

    [StringLength(20)]
    public string Subject { get; set; } = null!;

    [InverseProperty("Subject")]
    public virtual ICollection<QuestionsDb> QuestionsDbs { get; set; } = new List<QuestionsDb>();
}
