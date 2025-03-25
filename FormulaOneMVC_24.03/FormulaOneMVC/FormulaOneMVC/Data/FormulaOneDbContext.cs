using System;
using System.Collections.Generic;
using FormulaOneMVC.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneMVC.Data;

public partial class FormulaOneDbContext : DbContext
{
    public FormulaOneDbContext()
    {
    }

    public FormulaOneDbContext(DbContextOptions<FormulaOneDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<RaceResult> RaceResults { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-VI3C6PQ\\SQLEXPRESS;Initial Catalog=FormulaOneDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PK__Drivers__A411C5BDC41AC481");

            entity.HasOne(d => d.Team).WithMany(p => p.Drivers)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Drivers__team_id__38996AB5");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.RaceId).HasName("PK__Races__1C8FE2F910FEA0B9");
        });

        modelBuilder.Entity<RaceResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Race_Res__AFB3C3163CA0D0ED");

            entity.HasOne(d => d.Driver).WithMany(p => p.RaceResults)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Race_Resu__drive__3E52440B");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceResults)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Race_Resu__race___3D5E1FD2");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Teams__F82DEDBC9A897305");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
