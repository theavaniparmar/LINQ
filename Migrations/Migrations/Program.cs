using Microsoft.EntityFrameworkCore;
using Migrations.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configure PostgreSQL Database Connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=Migrations;Username=postgres;Password=Welcome@123"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Students}/{action=Index}/{id?}");
app.Run();
