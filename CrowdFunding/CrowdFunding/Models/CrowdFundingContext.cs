using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CrowdFunding.Models;

namespace CrowdFunding.Models
{
    public partial class CrowdFundingContext : IdentityDbContext<Person, IdentityRole<long>, long>
    {
        public CrowdFundingContext()
        {
        }

        public CrowdFundingContext(DbContextOptions<CrowdFundingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PersonPackage> PersonPackage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProfileUrl).HasMaxLength(255);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PictureUrl).HasMaxLength(255);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_Category");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Project_Person");

                entity.ToTable("Project", "dbo");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.Property(e => e.DetailId).HasColumnName("DetailID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Detail)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Update_Project");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.PackageId).HasColumnName("PackageID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Package)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Package_Project");
            });

            modelBuilder.Entity<PersonPackage>(entity =>
            {
                entity.HasKey(e => new { e.PackageId, e.PersonId });

                entity.Property(e => e.PackageId).HasColumnName("PackageID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PersonPackage)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonPackage_Package");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PersonPackage)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonPackage_Person");
            });
        }
    }
}
