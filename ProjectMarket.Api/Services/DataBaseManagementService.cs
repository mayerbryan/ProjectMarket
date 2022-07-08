using Microsoft.EntityFrameworkCore;
using ProjectMarket.Api.Data;

namespace WebApiTemplate.Api.Services
{
    public static class DataBaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider.GetService<ProjectMarketDbContext>();
                serviceDb.Database.Migrate();
            }
        }

    }
}
