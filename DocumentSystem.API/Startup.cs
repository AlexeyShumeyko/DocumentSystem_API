using DocumentSystem.Application.Interfaces;
using DocumentSystem.Application.Services;
using DocumentSystem.Core.Contract;
using DocumentSystem.DAL;
using Microsoft.EntityFrameworkCore;

namespace DocumentSystem.API
{
    public static class Startup
    {
        internal static void AddServices(WebApplicationBuilder builder) 
        { 
            RegisterDAL(builder);

            RegisterService(builder.Services);
        }

        private static void RegisterDAL(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("Sqlite");

            builder.Services.AddTransient(provider =>
            {
                var builder = new DbContextOptionsBuilder<DocumentSystemDbContext>();

                builder.UseSqlite(connectionString);

                return builder.Options;
            });

            builder.Services.AddScoped<DbContext, DocumentSystemDbContext>();

            builder.Services.AddScoped<IUnitOfWork>(prov =>
            {
                var context = prov.GetRequiredService<DbContext>();

                return new UnitOfWork(context);
            });
        }

        private static void RegisterService(IServiceCollection services)
        {
            services.AddScoped<IDocumentService, DocumentService>();

            services.AddScoped<ITaskService, TaskService>();
        }
    }
}
