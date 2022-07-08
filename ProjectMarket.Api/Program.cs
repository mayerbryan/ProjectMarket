using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectMarket.Api.Data;
using WebApiTemplate.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProjectMarketDbContext>(options => options.UseSqlServer(connectionString));


//if (builder.Environment.IsDevelopment())
//{


//}
//if (builder.Environment.IsProduction())
//{
//    builder.Services.AddDbContext<ProjectMarketDbContext>(options => options.
//    UseSqlServer(enderecoconexao,
//    sqlServerOptionsAction: sqlOptions =>
//    {
//        sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,
//            maxRetryDelay: TimeSpan.FromSeconds(5),
//            errorNumbersToAdd: null);
//    }));
//}






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

