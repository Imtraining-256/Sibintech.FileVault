using FileVault.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FileVault.DAL
{
    public partial class VaultFileContext : DbContext
    {
        public VaultFileContext()
        {
        }

        public VaultFileContext(DbContextOptions<VaultFileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<UploadFile> UploadFiles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-T2VAC1E\\SQLEXPRESS;Initial Catalog=VaultFile;Integrated Security=True");
            }
        }

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
