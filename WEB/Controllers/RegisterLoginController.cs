using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB.Models;

namespace WEB.Controllers
{
    public class RegisterLoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterLoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверка, существует ли пользователь с таким Email
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    TempData["Message"] = "A user with this email already exists.";
                    return RedirectToAction("Privacy", "Home");
                }

                // Добавление пользователя в базу данных
                _context.Users.Add(model);
                await _context.SaveChangesAsync();

                // Сохраняем User_ID в сессии после регистрации
                HttpContext.Session.SetInt32("UserID", model.UserId);

                TempData["Message"] = "Registration successful!";
                return RedirectToAction("Index", "Home"); // Переход на страницу Index.cshtml
            }

            TempData["Message"] = "Registration failed. Please check the input data.";
            return RedirectToAction("Privacy", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Проверяем, существует ли пользователь с таким email и паролем
            var user = await _context.Users
                                      .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Сохраняем User_ID в сессии
                HttpContext.Session.SetInt32("UserID", user.UserId);

                // Пользователь найден, можно перенаправить на главную страницу
                TempData["Message"] = $"Welcome back, {user.FName}!";
                return RedirectToAction("Index", "Home"); // Переход на главную страницу
            }

            // Если пользователь не найден, добавляем ошибку в ModelState
            ModelState.AddModelError("", "Invalid email or password. Please try again.");

            // Возвращаем пользователя на страницу логина с ошибкой
            return View("~/Views/Home/Privacy.cshtml");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Очистка сессии при выходе пользователя
            HttpContext.Session.Clear();
            TempData["Message"] = "You have been logged out.";
            return RedirectToAction("Privacy", "Home"); // Переход на страницу входа
        }

        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View("~/Views/Home/Privacy.cshtml");
        }
    }
}