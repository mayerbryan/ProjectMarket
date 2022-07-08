using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectMarket.Api.Data;
using WebApiTemplate.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

if (builder.Environment.IsDevelopment())
{
    
    DotNetEnv.Env.Load();

    var connectionString = $"Server={Environment.GetEnvironmentVariable("SERVER")}, " +
        $"{Environment.GetEnvironmentVariable("DATABASE_PORT")}; " +
        $"Initial Catalog={Environment.GetEnvironmentVariable("DATABASE_NAME")};" +
        $"User ID={Environment.GetEnvironmentVariable("DATABASE_USER")}; " +
        $"Password={Environment.GetEnvironmentVariable("DATABASE_PASSWORD")}";

    builder.Services.AddDbContext<ProjectMarketDbContext>(options => options.UseSqlServer(connectionString));

    builder.Services.AddDbContext<ProjectMarketDbContext>();

}
if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<ProjectMarketDbContext>(options => options.
    UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null);
    }));
}





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    DataBaseManagementService.MigrationInitialisation(app);    
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

