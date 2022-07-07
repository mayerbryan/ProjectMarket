using System.Data.Entity.SqlServer;
using Microsoft.EntityFrameworkCore;
using ProjectMarket.Application.Models;

namespace ProjectMarket.Api.Data
{
    public class ProjectMarketDbContext : DbContext
    {
        //Constructor
        public ProjectMarketDbContext(DbContextOptions<ProjectMarketDbContext> options) : base(options) { }


        //Models
        public DbSet<UserClientModel> UserClient { get; set; }



    }
}
