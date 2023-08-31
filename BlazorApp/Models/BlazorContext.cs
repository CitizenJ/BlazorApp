using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BlazorApp.Models
{
    public partial class BlazorContext : DbContext
    {
        public BlazorContext()
        {
        }

        public BlazorContext(DbContextOptions<BlazorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Blazor;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Gender).HasColumnType("text");

                entity.Property(e => e.GivenName)
                    .HasColumnType("text")
                    .HasColumnName("Given Name");

                entity.Property(e => e.Nationality).HasColumnType("text");

                entity.Property(e => e.Surname).HasColumnType("text");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.InStock).HasColumnName("In stock");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.PageCount).HasColumnName("Page Count");

                entity.Property(e => e.PublicationDate)
                    .HasColumnType("date")
                    .HasColumnName("Publication Date");

                entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Authors");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Publishers");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Ceo)
                    .HasColumnType("text")
                    .HasColumnName("CEO");

                entity.Property(e => e.FoundIn)
                    .HasColumnType("date")
                    .HasColumnName("Found In");

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.Nationality).HasColumnType("text");

                entity.Property(e => e.Status).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
