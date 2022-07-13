using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ProjectMarket.Api.Data.Mappings;
using ProjectMarket.Application.Models;

namespace ProjectMarket.Api.Data
{
    public class ProjectMarketDbContext : DbContext
    {
        //Constructor
        public ProjectMarketDbContext(DbContextOptions<ProjectMarketDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.Ignore<Notification>();
        }

        //Models
        public DbSet<UserModel> User { get; set; }



    }
}
