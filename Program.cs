using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sageb.Data;
using sageb.Database.Entities;

var builder = WebApplication.CreateBuilder(args);

//Configuring database SQLite
var rootPathASString = builder.Environment.WebRootPath;
var options = new DbContextOptionsBuilder<SqliteDbContext>().UseSqlite(connectionString: "Data source =" +rootPathASString + "/database.db").Options;
builder.Services.AddSingleton(new SqliteDbContext(options));

//Configuring authentication and authorization
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<SqliteDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 4;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.RequireUniqueEmail = true;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/AccessControl/Login";
    options.AccessDeniedPath = "/AccessControl/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
