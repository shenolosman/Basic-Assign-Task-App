using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SO.ToDo.Entities.Concrete;

namespace So.ToDo.DataAccessLayer.Concrete.EntityFrameworkCore.Mapping
{
    public class StateofUrgentMap : IEntityTypeConfiguration<StateOfUrgent>
    {
        public void Configure(EntityTypeBuilder<StateOfUrgent> builder)
        {
            builder.Property(x => x.Type).HasMaxLength(100);
        }
    }
}
