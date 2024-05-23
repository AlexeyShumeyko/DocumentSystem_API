using DocumentSystem.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DocumentSystem.DAL
{
    public class DocumentSystemDbContext(
        DbContextOptions<DocumentSystemDbContext> options)
        : DbContext(options)
    {
        public DbSet<DocumentEntity> Documents { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentSystemDbContext).Assembly);
        }
    }
}
