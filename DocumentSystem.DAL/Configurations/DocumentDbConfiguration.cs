using DocumentSystem.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentSystem.DAL.Configurations
{
    public class DocumentDbConfiguration : IEntityTypeConfiguration<DocumentEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentEntity> builder) 
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).IsRequired();
            builder.Property(d => d.Status).IsRequired();

            builder.HasOne(x => x.ActiveTask);

            builder.HasMany(x => x.Tasks).WithOne().HasForeignKey(x => x.PreviousTaskID);

        }
    }
}
