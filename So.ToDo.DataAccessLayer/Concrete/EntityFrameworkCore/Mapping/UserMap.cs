using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(50).IsRequired(false);

            builder.HasMany(x => x.Works).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            //.OnDelete(DeleteBehavior.Cascade);  this one comes as based  => deletes whole nodes for that user 

        }
    }
}
