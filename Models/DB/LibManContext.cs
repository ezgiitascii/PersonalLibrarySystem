using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibMan.Models.DB
{
    public partial class LibManContext : DbContext
    {
        public LibManContext()
        {
        }

        public LibManContext(DbContextOptions<LibManContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<User> User { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-SNK2N3MT;Database=LibMan;Trusted_Connection=True; ");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.Author).HasMaxLength(100);

                entity.Property(e => e.Categories).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Publisher).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Translator).HasMaxLength(100);

                entity.Property(e => e.BookId).HasColumnName("BookId");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.Property(e => e.Cover).HasColumnType("image");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.BirthDate).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Password);

                entity.Property(e => e.UserId).HasColumnName("UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
