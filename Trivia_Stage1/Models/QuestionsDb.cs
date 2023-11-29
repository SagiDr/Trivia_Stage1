using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

[Table("questionsDB")]
public partial class QuestionsDb
{
    [Key]
    [Column("QuestionID")]
    public int QuestionId { get; set; }

    [Column("QuestionStatusID")]
    public int QuestionStatusId { get; set; }

    [Column("USerID")]
    public int UserId { get; set; }

    [Column("SubjectID")]
    public int SubjectId { get; set; }

    [StringLength(200)]
    public string Text { get; set; } = null!;

    [StringLength(200)]
    public string CorrectAns { get; set; } = null!;

    [StringLength(200)]
    public string WrongAns1 { get; set; } = null!;

    [StringLength(200)]
    public string WrongAns2 { get; set; } = null!;

    [StringLength(200)]
    public string WrongAns3 { get; set; } = null!;

    [ForeignKey("QuestionStatusId")]
    [InverseProperty("QuestionsDbs")]
    public virtual QuestionStatusDb QuestionStatus { get; set; } = null!;

    [ForeignKey("SubjectId")]
    [InverseProperty("QuestionsDbs")]
    public virtual SubjectDb Subject { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("QuestionsDbs")]
    public virtual UserDb User { get; set; } = null!;
}
