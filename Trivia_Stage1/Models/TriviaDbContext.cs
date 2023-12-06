using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Trivia_Stage1.Models;

public partial class TriviaDbContext : DbContext
{
    public TriviaDbContext()
    {
    }

    public TriviaDbContext(DbContextOptions<TriviaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<QuestionStatusDb> QuestionStatusDbs { get; set; }

    public virtual DbSet<QuestionsDb> QuestionsDbs { get; set; }

    public virtual DbSet<SubjectDb> SubjectDbs { get; set; }

    public virtual DbSet<UserDb> UserDbs { get; set; }

    public virtual DbSet<UserRankDb> UserRankDbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = LAB2-12\\SQLEXPRESS; Database=Trivia; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuestionStatusDb>(entity =>
        {
            entity.HasKey(e => e.QuestionStatusId).HasName("PK__question__9F1C4AD5D7365968");

            entity.Property(e => e.QuestionStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<QuestionsDb>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__question__0DC06F8CAD399E44");

            entity.HasOne(d => d.QuestionStatus).WithMany(p => p.QuestionsDbs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__questions__Quest__2E1BDC42");

            entity.HasOne(d => d.Subject).WithMany(p => p.QuestionsDbs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__questions__Subje__300424B4");

            entity.HasOne(d => d.User).WithMany(p => p.QuestionsDbs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__questions__USerI__2F10007B");
        });

        modelBuilder.Entity<SubjectDb>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__subjectD__AC1BA388937DD48A");

            entity.Property(e => e.SubjectId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UserDb>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__userDB__1788CC4CB73AC16A");

            entity.Property(e => e.UserName).IsFixedLength();

            entity.HasOne(d => d.UserRank).WithMany(p => p.UserDbs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__userDB__UserRank__2B3F6F97");
        });

        modelBuilder.Entity<UserRankDb>(entity =>
        {
            entity.HasKey(e => e.UserRankId).HasName("PK__userRank__9D71D33193860416");

            entity.Property(e => e.UserRankId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
