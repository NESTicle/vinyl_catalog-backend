using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.HasOne(x => x.User)
                .WithMany(x => x.Vinyls)
                .HasForeignKey(x => x.Id_User);

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Vinyls)
                .HasForeignKey(x => x.Id_Country);
        }
    }
}
