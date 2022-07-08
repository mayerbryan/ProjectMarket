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
else
{
    builder.Services.AddDbContext<ProjectMarketDbContext>(options => options.
    UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection"),
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
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

