using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CAMPUSproject.Data;
using CAMPUSproject.Areas.Identity.Data;
using CAMPUSproject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TeamUpSpace.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IndentityDbContextContextConnection") ?? throw new InvalidOperationException("Connection string 'IndentityDbContextContextConnection' not found.");

builder.Services.AddDbContext<CAMPUSproject.Data.IdentityDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ProjectDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddIdentity<MyProjectUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddEntityFrameworkStores<CAMPUSproject.Data.IdentityDbContext>()
        .AddDefaultTokenProviders()
        .AddDefaultUI();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddMvc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
