using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RailwayStation.Data.Models;

public partial class RailwayStationDbContext : DbContext
{
    public RailwayStationDbContext()
    {
    }

    public RailwayStationDbContext(DbContextOptions<RailwayStationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RailwayStationDB;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F24B794AF");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("position");
            entity.Property(e => e.TrainId).HasColumnName("train_id");

            entity.HasOne(d => d.Train).WithMany(p => p.Employees)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Employees__train__440B1D61");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Routes__3213E83F5A34410F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArrivalStation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("arrival_station");
            entity.Property(e => e.ArrivalTime)
                .HasColumnType("datetime")
                .HasColumnName("arrival_time");
            entity.Property(e => e.DepartureStation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("departure_station");
            entity.Property(e => e.DepartureTime)
                .HasColumnType("datetime")
                .HasColumnName("departure_time");
            entity.Property(e => e.TrainId).HasColumnName("train_id");

            entity.HasOne(d => d.Train).WithMany(p => p.Routes)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Routes__train_id__398D8EEE");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets__3213E83F1ADFDD72");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PassengerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("passenger_name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.RouteId).HasColumnName("route_id");
            entity.Property(e => e.SeatNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("seat_number");
            entity.Property(e => e.TrainId).HasColumnName("train_id");

            entity.HasOne(d => d.Route).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.RouteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__route_i__412EB0B6");

            entity.HasOne(d => d.Train).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TrainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__train_i__403A8C7D");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tracks__3213E83F19C63513");

            entity.HasIndex(e => e.TrackNumber, "UQ__Tracks__1C93872808FC8891").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("station_name");
            entity.Property(e => e.TrackNumber).HasColumnName("track_number");
            entity.Property(e => e.TrainId).HasColumnName("train_id");

            entity.HasOne(d => d.Train).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.TrainId)
                .HasConstraintName("FK__Tracks__train_id__3D5E1FD2");
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trains__3213E83FD37F4776");

            entity.HasIndex(e => e.TrainNumber, "UQ__Trains__55C242D1594B881A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.TrainNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("train_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
