using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RatingPage.Data;
using RatingPage.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RatingPageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RatingPageContext") ?? throw new InvalidOperationException("Connection string 'RatingPageContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<RateService>();

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
    pattern: "{controller=Rates}/{action=Index}/{id?}");

app.Run();
