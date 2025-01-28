using Microsoft.EntityFrameworkCore;
using WEB.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Настройка подключения к базе данных
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-4P5CV14\\SQLEXPRESS;Database=TaxiDb;Trusted_Connection=True;TrustServerCertificate=True;");
});

// Добавление поддержки сессий
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Время жизни сессии
    options.Cookie.HttpOnly = true; // Защита от XSS-атак
    options.Cookie.IsEssential = true; // Требование для работы с GDPR
});

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

// Включение middleware для сессий
app.UseSession();

app.UseAuthorization();

// Настройка маршрутов
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "help",
    pattern: "Help/GetHelpForm",
    defaults: new { controller = "Home", action = "GetHelpForm" });

app.Run();