using DocumentSystem.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentSystem.DAL.Configurations
{
    public class TaskDbConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Name).IsRequired();

            builder.Property(t => t.PreviousTaskID).IsRequired(false);
        }
    }
}
