using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GatesAPI.Models
{
    public partial class GatesGrantsContext : DbContext
    {
        public GatesGrantsContext()
        {
        }

        public GatesGrantsContext(DbContextOptions<GatesGrantsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Grant> Grant { get; set; }
        public virtual DbSet<GrantRegion> GrantRegion { get; set; }
        public virtual DbSet<GrantTopic> GrantTopic { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<TopicGroup> TopicGroup { get; set; }
        public virtual DbSet<Years> Years { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=GatesGrants;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "e408");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Grant>(entity =>
            {
                entity.ToTable("Grant", "e408");

                entity.Property(e => e.OpportunityId)
                    .IsRequired()
                    .HasColumnName("OpportunityID")
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
                
            });

            modelBuilder.Entity<GrantRegion>(entity =>
            {
                entity.ToTable("GrantRegion", "e408");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.GrantRegion)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrantRegion_Region");
            });

            modelBuilder.Entity<GrantTopic>(entity =>
            {
                entity.ToTable("GrantTopic", "e408");

             
                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.GrantTopic)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrantTopic_Topic");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization", "e408");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region", "e408");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic", "e408");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.TopicGroup)
                    .WithMany(p => p.Topic)
                    .HasForeignKey(d => d.TopicGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Topic_TopicGroup");
            });

            modelBuilder.Entity<TopicGroup>(entity =>
            {
                entity.ToTable("TopicGroup", "e408");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Years>(entity =>
            {
                entity.ToTable("Years", "e408");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
