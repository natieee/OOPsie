

using Microsoft.AspNetCore.Identity;
using main.Data.Entities;
using Microsoft.EntityFrameworkCore;
using main.Data;

using main.Components;
var builder = WebApplication.CreateBuilder(args);

// 1. Get the connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "Data Source=app.db"; // Fallback to "app.db" if not in config

// 2. Register the DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));


// Register the password hasher for our User entity
builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();