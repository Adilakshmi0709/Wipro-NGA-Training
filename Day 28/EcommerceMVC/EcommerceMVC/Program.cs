using EcommerceMVC.Data;       // Correct namespace for DbContext
using EcommerceMVC.Filters;    // ✅ Fixed: was EcommerceApp.Filters
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add MVC and Log Filter
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LogActionFilter>();
});

// ✅ Add EF Core DbContext
builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Add Session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  // Session expires in 30 mins
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add HttpContextAccessor for session use in controllers
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Enable middleware
app.UseStaticFiles();
app.UseRouting();
app.UseSession();   // ✅ Must be before Authorization
app.UseAuthorization();

// Default route → go to Login first
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
