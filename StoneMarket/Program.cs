
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using StoneMarket.AccessLayer.Context;
using StoneMarket.Context;
using StoneMarket.Core.Classes;
using StoneMarket.Core.Interfaces;
using StoneMarket.Core.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/Accounts/Login";
    options.LogoutPath = "/Accounts/LogOut";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
});
// Add services to the container.
var conn = builder.Configuration.GetSection("mysqlDbString").Value;

builder.Services.AddDbContext<StoneMarketContext>(options => options
       .UseMySQL(conn));

builder.Services.AddTransient<IUser, UserService>();
builder.Services.AddTransient<IAccount, AccountService>();
builder.Services.AddTransient<IAdmin, AdminService>();
builder.Services.AddTransient<IViewRenderService, RenderToString>();
builder.Services.AddScoped<PanelLayoutScope>();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
using var db = new StoneMarketContext();
db.Database.MigrateAsync();

app.UseAuthentication();
//app.UseAuthorization();
app.UseMvcWithDefaultRoute();

app.UseRouting();
app.UseStaticFiles();



app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Hello World!");
    });
});

bool recreateDatabase = builder.Configuration.GetValue("recreateDatabase", false);
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<StoneMarketContext>();
if (recreateDatabase)
{
    await dbContext.Database.EnsureCreatedAsync();
}
else
{
    await dbContext.Database.MigrateAsync();

}

app.Run();
