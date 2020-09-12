using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VinylCollection.Data.Models.Security;

namespace VinylCollection.Data.Models.Mappings.Models
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "Security");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired();

            builder.HasIndex(x => x.Id).IsUnique();
        }
    }
}
