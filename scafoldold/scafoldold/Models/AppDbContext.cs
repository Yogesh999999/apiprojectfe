using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace scafoldold.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<ProjCountry> ProjCountries { get; set; }

    public virtual DbSet<ProjDistrict> ProjDistricts { get; set; }

    public virtual DbSet<ProjId> ProjIds { get; set; }

    public virtual DbSet<ProjState> ProjStates { get; set; }

    public virtual DbSet<Order> Ord { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySql("server=localhost;port=3306;database=datas;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.44-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ProjCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PRIMARY");

            entity.ToTable("proj_country");

            entity.Property(e => e.CountryId).HasColumnName("country_Id");
            entity.Property(e => e.CountryNames)
                .HasMaxLength(100)
                .HasColumnName("country_names");
        });

        modelBuilder.Entity<ProjDistrict>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PRIMARY");

            entity.ToTable("proj_district");

            entity.HasIndex(e => e.StateId, "state_id");

            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.DistrictNames)
                .HasMaxLength(100)
                .HasColumnName("district_names");
            entity.Property(e => e.StateId).HasColumnName("state_id");

            entity.HasOne(d => d.State).WithMany(p => p.ProjDistricts)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("proj_district_ibfk_1");
        });

        modelBuilder.Entity<ProjId>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proj_id");

            entity.HasIndex(e => e.CountryId, "country_id");

            entity.HasIndex(e => e.DistrictId, "district_id");

            entity.HasIndex(e => e.StateId, "state_id");

            entity.HasIndex(e => e.UsersId, "users_id");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.StateId).HasColumnName("state_id");
            entity.Property(e => e.UsersId).HasColumnName("users_id");

            entity.HasOne(d => d.Country).WithMany(p => p.ProjIds)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("proj_id_ibfk_2");

            entity.HasOne(d => d.State).WithMany(p => p.ProjIds)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("proj_id_ibfk_3");
        });

        modelBuilder.Entity<ProjState>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PRIMARY");

            entity.ToTable("proj_state");

            entity.HasIndex(e => e.CountryId, "country_id");

            entity.Property(e => e.StateId)
                .ValueGeneratedNever()
                .HasColumnName("state_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.StateNames)
                .HasMaxLength(100)
                .HasColumnName("state_names");

            entity.HasOne(d => d.Country).WithMany(p => p.ProjStates)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("proj_state_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
