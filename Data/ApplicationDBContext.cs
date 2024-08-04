using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dotnet_webapi.Models;

namespace dotnet_webapi.Data;

public partial class ApplicationDBContext : DbContext
{
    public ApplicationDBContext()
    {
    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Destination> Destinations { get; set; }

    public virtual DbSet<Meeting> Meetings { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=tripbooking.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Meeting).WithMany(p => p.Bookings).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Trip).WithMany(p => p.Bookings).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasOne(d => d.Destination).WithMany(p => p.Trips).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
