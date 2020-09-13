using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VinylCollection.Data.Models.Vinyls;

namespace VinylCollection.Data.Models.Mappings.Models
{
    public class VinylMap : IEntityTypeConfiguration<Vinyl>
    {
        void IEntityTypeConfiguration<Vinyl>.Configure(EntityTypeBuilder<Vinyl> builder)
        {
            builder.ToTable("Vinyl", "Vinyl");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(x => x.Price)
                .HasColumnType("Money");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Vinyls)
                .HasForeignKey(x => x.Id_User);

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Vinyls)
                .HasForeignKey(x => x.Id_Country);

            builder.HasOne(x => x.SubGenre)
                .WithMany(x => x.Vinyls)
                .HasForeignKey(x => x.Id_SubGenre);

            builder.HasOne(x => x.VinylFormat)
                .WithMany(x => x.Vinyls)
                .HasForeignKey(x => x.Id_VinylFormat);
        }
    }

    public class VinylFormatMap : IEntityTypeConfiguration<VinylFormat>
    {
        void IEntityTypeConfiguration<VinylFormat>.Configure(EntityTypeBuilder<VinylFormat> builder)
        {
            builder.ToTable("VinylFormats", "Vinyl");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
