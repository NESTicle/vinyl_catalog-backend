using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;
using VinylCollection.Data.Models.Parameters;

namespace VinylCollection.Data.Models.Mappings.Models
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        void IEntityTypeConfiguration<Country>.Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries", "Parameters");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasIndex(x => new { x.Id, x.Name }).IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }

    public class GenreMap : IEntityTypeConfiguration<Genre>
    {
        void IEntityTypeConfiguration<Genre>.Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genres", "Parameters");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasIndex(x => new { x.Id, x.Name }).IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }

    public class SubGenreMap : IEntityTypeConfiguration<SubGenre>
    {
        void IEntityTypeConfiguration<SubGenre>.Configure(EntityTypeBuilder<SubGenre> builder)
        {
            builder.ToTable("SubGenres", "Parameters");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasIndex(x => new { x.Id, x.Name }).IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Genre)
                .WithMany(x => x.SubGenres)
                .HasForeignKey(x => x.Id_Genre);
        }
    }
}
