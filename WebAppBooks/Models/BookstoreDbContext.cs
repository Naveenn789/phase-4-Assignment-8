using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppBooks.Models
{
    public partial class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext()
        {
        }

        public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookCategory> BookCategories { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:naveen789.database.windows.net,1433;Initial Catalog=BookstoreDb;Persist Security Info=False;User ID=naveen789;Password=Prashanthi@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.WriterId)
                    .HasName("PK__Author__198537690E8CDC6C");

                entity.ToTable("Author");

                entity.Property(e => e.WriterId)
                    .ValueGeneratedNever()
                    .HasColumnName("writerId");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("bookId");

                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .HasColumnName("bookName");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .HasColumnName("category");

                entity.Property(e => e.Publisher).HasMaxLength(50);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK__book__category__6C190EBB");

                entity.HasOne(d => d.PublisherNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Publisher)
                    .HasConstraintName("FK__book__Publisher__6D0D32F4");
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.HasKey(e => e.CatName)
                    .HasName("PK__BookCate__9C61AB27AFAFDB02");

                entity.ToTable("BookCategory");

                entity.Property(e => e.CatName).HasMaxLength(50);

                entity.Property(e => e.CatId).HasColumnName("catId");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.Pname)
                    .HasName("PK__Publishe__42B460827584F596");

                entity.ToTable("Publisher");

                entity.Property(e => e.Pname)
                    .HasMaxLength(50)
                    .HasColumnName("PName");

                entity.Property(e => e.Paddress)
                    .HasMaxLength(50)
                    .HasColumnName("PAddress");

                entity.Property(e => e.Pid).HasColumnName("PId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
