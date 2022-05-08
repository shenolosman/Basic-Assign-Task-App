using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Mapping
{
    public class RapportMap : IEntityTypeConfiguration<Rapport>
    {
        public void Configure(EntityTypeBuilder<Rapport> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).HasMaxLength(100);
            builder.Property(x => x.Details).HasColumnType("ntext");

            builder.HasOne(x => x.MyTask).WithMany(x => x.Rapports).HasForeignKey(x => x.MyTaskId);
        }
    }

}
