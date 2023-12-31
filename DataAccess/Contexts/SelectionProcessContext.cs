﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PandaPeAPI.Domain.Entities.SelectionProcessEntities;

namespace PandaPeAPI.DataAccess.Contexts
{
    public partial class SelectionProcessContext : DbContext
    {
        public SelectionProcessContext()
        {
        }

        public SelectionProcessContext(DbContextOptions<SelectionProcessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CandidateExperiences> CandidateExperiences { get; set; } = null!;
        public virtual DbSet<Candidates> Candidates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateExperiences>(entity =>
            {
                entity.HasKey(e => e.IdCandidateExperience)
                    .HasName("PK__Candidat__D9A60D6582F03617");

                entity.Property(e => e.IdCandidateExperience).ValueGeneratedNever();

                entity.Property(e => e.BeginDate).HasColumnType("datetime");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifyDate).HasColumnType("datetime");

                entity.Property(e => e.Salary).HasColumnType("numeric(8, 2)");

                entity.HasOne(d => d.IdCandidateNavigation)
                    .WithMany(p => p.CandidateExperiences)
                    .HasForeignKey(d => d.IdCandidate)
                    .HasConstraintName("FK__Candidate__IdCan__38996AB5");
            });

            modelBuilder.Entity<Candidates>(entity =>
            {
                entity.HasKey(e => e.IdCandidate)
                    .HasName("PK__Candidat__D559897353F901F1");

                entity.HasIndex(e => e.Email, "UQ__Candidat__A9D10534CAA76520")
                    .IsUnique();

                entity.Property(e => e.IdCandidate).ValueGeneratedNever();

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
