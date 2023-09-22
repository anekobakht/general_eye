using Microsoft.EntityFrameworkCore;
using general_eye.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<general_eyeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("general_eyeContext") ?? throw new InvalidOperationException("Connection string 'general_eyeContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

//session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddProgressiveWebApp();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(100000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//session
app.UseSession();


//app.UseBrowserLink();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=login}/{id?}");

app.Run();

