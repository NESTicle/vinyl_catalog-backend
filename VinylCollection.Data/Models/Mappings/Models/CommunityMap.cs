using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylCollection.Data.Models.Communities;

namespace VinylCollection.Data.Models.Mappings.Models
{
    public class CommunityMap : IEntityTypeConfiguration<Community>
    {
        void IEntityTypeConfiguration<Community>.Configure(EntityTypeBuilder<Community> builder)
        {
            builder.ToTable("Communities", "Community");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(x => x.Description)
                .HasMaxLength(2000);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Communities)
                .HasForeignKey(x => x.Id_User);
        }
    }
}
