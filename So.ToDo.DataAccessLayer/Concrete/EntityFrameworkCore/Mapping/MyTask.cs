using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Mapping
{
    public class MyTask : IEntityTypeConfiguration<SO.ToDo.Entities.Concrete.MyTask>
    {
        public void Configure(EntityTypeBuilder<SO.ToDo.Entities.Concrete.MyTask> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).HasMaxLength(200);

            builder.Property(x => x.Description).HasColumnType("ntext");

        }
    }
}
