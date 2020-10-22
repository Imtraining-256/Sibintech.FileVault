using FileVault.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileVault.DAL
{
    public partial class VaultFileContext : DbContext
    {
        public VaultFileContext(DbContextOptions<VaultFileContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<UploadFile> UploadFiles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.Hash).IsRequired();
            });

            modelBuilder.Entity<UploadFile>(entity =>
            {
                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UploadDate).HasColumnType("datetime");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.UploadFiles)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UploadFiles_Files");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UploadFiles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UploadFiles_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
