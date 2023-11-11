using Microsoft.EntityFrameworkCore;
using sageb.Data;
using sageb.Repositorio;
using sageb.Repositorio.Interface;

var builder = WebApplication.CreateBuilder(args);

//Configuring database SQLite
var rootPathASString = builder.Environment.WebRootPath;
var options = new DbContextOptionsBuilder<SqliteDbContext>().UseSqlite(connectionString: "Data source =" +rootPathASString + "/database.db").Options;
builder.Services.AddSingleton(new SqliteDbContext(options));

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
