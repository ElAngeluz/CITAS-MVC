using citas.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var builderConnection = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));

builder.Services.AddDbContext<CitasContext>(options =>
{
    options.UseSqlServer(builderConnection.ConnectionString);
},
            ServiceLifetime.Transient
            );

builder.Services.AddDbContextFactory<CitasContext>(options =>
{
    options.UseSqlServer(builderConnection.ConnectionString);
}, ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
