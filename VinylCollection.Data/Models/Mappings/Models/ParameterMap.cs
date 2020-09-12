using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
}
