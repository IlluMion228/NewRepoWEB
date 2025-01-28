using Microsoft.EntityFrameworkCore;
using WEB.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ��������� ����������� � ���� ������
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-4P5CV14\\SQLEXPRESS;Database=TaxiDb;Trusted_Connection=True;TrustServerCertificate=True;");
});

// ���������� ��������� ������
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // ����� ����� ������
    options.Cookie.HttpOnly = true; // ������ �� XSS-����
    options.Cookie.IsEssential = true; // ���������� ��� ������ � GDPR
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

// ��������� middleware ��� ������
app.UseSession();

app.UseAuthorization();

// ��������� ���������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "help",
    pattern: "Help/GetHelpForm",
    defaults: new { controller = "Home", action = "GetHelpForm" });

app.Run();