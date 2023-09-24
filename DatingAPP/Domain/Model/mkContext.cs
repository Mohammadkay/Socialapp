using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatingAPP
{
    public partial class mkContext : DbContext
    {
        public mkContext()
        {
        }

        public mkContext(DbContextOptions<mkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Photo> Photos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=ConnectionStrings:ctor", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("photo");

                entity.HasIndex(e => e.UserId, "userId");

                entity.Property(e => e.PublicId)
                    .HasMaxLength(255)
                    .HasColumnName("publicId");

                entity.Property(e => e.Url).HasMaxLength(255);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("photo_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.DateofBarth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Gender).HasMaxLength(255);

                entity.Property(e => e.HashPassword).HasMaxLength(255);

                entity.Property(e => e.Interests).HasMaxLength(255);

                entity.Property(e => e.Introduction).HasMaxLength(255);

                entity.Property(e => e.Lastactive).HasColumnType("datetime");

                entity.Property(e => e.Lokingfor).HasMaxLength(255);

                entity.Property(e => e.Saltpassword).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
