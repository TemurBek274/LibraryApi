    using eBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryApi.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id)
                .IsRequired();

                builder.Property(s => s.Title)
                .HasMaxLength(200);

                builder.Property(d => d.Author)
                .HasMaxLength(100);

                builder.Property(p => p.PublishedYear)
                .IsRequired();

                builder.Property(i => i.ISBN)
                .HasMaxLength(13)
                .IsRequired(true);

                builder.Property(i => i.Price)
                .IsRequired()
                .HasColumnType("decimal(18)");

                builder.Property(g => g.Genre)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<Genre>());
            }); 
        }
    }
}
