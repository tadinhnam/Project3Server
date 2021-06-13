﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Server.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AllPerson> AllPeople { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswerQuestion> AnswerQuestions { get; set; }
        public virtual DbSet<Img> Imgs { get; set; }
        public virtual DbSet<PerformenSeminar> PerformenSeminars { get; set; }
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionSurvey> QuestionSurveys { get; set; }
        public virtual DbSet<RegisterSeminar> RegisterSeminars { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Seminar> Seminars { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<AllPerson>(entity =>
            {
                entity.HasKey(e => e.IdPerson)
                    .HasName("PK__AllPeopl__A5D4E15B0FA66F5E");

                entity.Property(e => e.IdPerson).HasMaxLength(250);

                entity.Property(e => e.Class).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Img).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("NAME");

                entity.Property(e => e.Position).HasMaxLength(50);
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.Answer1)
                    .HasMaxLength(250)
                    .HasColumnName("Answer");

                entity.Property(e => e.Updated).HasColumnType("date");
            });

            modelBuilder.Entity<AnswerQuestion>(entity =>
            {
                entity.HasKey(e => new { e.IdQuestion, e.IdAnswer })
                    .HasName("PK__AnswerQu__26B60F1D231907EA");

                entity.ToTable("AnswerQuestion");

                entity.HasOne(d => d.IdAnswerNavigation)
                    .WithMany(p => p.AnswerQuestions)
                    .HasForeignKey(d => d.IdAnswer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QS_Answer");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.AnswerQuestions)
                    .HasForeignKey(d => d.IdQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AQ_Question");
            });

            modelBuilder.Entity<Img>(entity =>
            {
                entity.ToTable("Img");

                entity.Property(e => e.Path).HasMaxLength(250);

                entity.HasOne(d => d.IdSeminarNavigation)
                    .WithMany(p => p.Imgs)
                    .HasForeignKey(d => d.IdSeminar)
                    .HasConstraintName("FK_Img_Serminar");
            });

            modelBuilder.Entity<PerformenSeminar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PerformenSeminar");

                entity.HasOne(d => d.IdPerformentNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPerforment)
                    .HasConstraintName("FK_PerformenSeminar_Performer");

                entity.HasOne(d => d.IdSeminarNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSeminar)
                    .HasConstraintName("FK_PerformenSeminar_Seminar");
            });

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.ToTable("Performer");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Img).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.Question1)
                    .HasMaxLength(250)
                    .HasColumnName("Question");

                entity.Property(e => e.Updated).HasColumnType("date");
            });

            modelBuilder.Entity<QuestionSurvey>(entity =>
            {
                entity.HasKey(e => new { e.IdQuestion, e.IdSurvey })
                    .HasName("PK__Question__E1194D417FEDCB14");

                entity.ToTable("QuestionSurvey");

                entity.Property(e => e.Updated).HasColumnType("date");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.QuestionSurveys)
                    .HasForeignKey(d => d.IdQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QS_Question");

                entity.HasOne(d => d.IdSurveyNavigation)
                    .WithMany(p => p.QuestionSurveys)
                    .HasForeignKey(d => d.IdSurvey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QS_Survey");
            });

            modelBuilder.Entity<RegisterSeminar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RegisterSeminar");

                entity.HasOne(d => d.IdAccNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAcc)
                    .HasConstraintName("FK_RegisterSeminar_Account");

                entity.HasOne(d => d.IdSeminarNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSeminar)
                    .HasConstraintName("FK_RegisterSeminar_Seminar");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Score");

                entity.Property(e => e.Score1).HasColumnName("Score");

                entity.HasOne(d => d.IdAccNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAcc)
                    .HasConstraintName("FK_Score_Account");

                entity.HasOne(d => d.IdSurveyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSurvey)
                    .HasConstraintName("FK_Score_Survey");
            });

            modelBuilder.Entity<Seminar>(entity =>
            {
                entity.ToTable("Seminar");

                entity.Property(e => e.Day).HasColumnType("date");

                entity.Property(e => e.Descriptoin).HasMaxLength(500);

                entity.Property(e => e.Img).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Place).HasMaxLength(1);

                entity.Property(e => e.Presenters).HasMaxLength(250);

                entity.HasOne(d => d.IdTopicNavigation)
                    .WithMany(p => p.Seminars)
                    .HasForeignKey(d => d.IdTopic)
                    .HasConstraintName("FK_Seminar_Topic");

                entity.HasOne(d => d.PresentersNavigation)
                    .WithMany(p => p.Seminars)
                    .HasForeignKey(d => d.Presenters)
                    .HasConstraintName("FK_Seminar_AllPeople");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Updated).HasColumnType("date");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.Topic1)
                    .HasMaxLength(50)
                    .HasColumnName("Topic");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}