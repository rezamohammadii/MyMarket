
using Microsoft.EntityFrameworkCore;
using StoneMarket.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
// Add services to the container.
var conn = builder.Configuration.GetSection("mysqlDbString").Value;

//builder.Services.AddDbContext<StoneMarketContext>(options => options
//       .UseMySql(conn, ServerVersion.AutoDetect(conn)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//bool recreateDatabase = builder.Configuration.GetValue("recreateDatabase", false);
//using var scope = app.Services.CreateScope();
//var dbContext = scope.ServiceProvider.GetRequiredService<StoneMarketContext>();


//await dbContext.Database.MigrateAsync();


app.Run();
