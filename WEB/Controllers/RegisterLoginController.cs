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
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    TempData["Message"] = "A user with this email already exists.";
                    return RedirectToAction("Privacy", "Home");
                }

                _context.Users.Add(model);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetInt32("UserID", model.UserId);

                TempData["Message"] = "Registration successful!";
                return RedirectToAction("Index", "Home"); 
            }

            TempData["Message"] = "Registration failed. Please check the input data.";
            return RedirectToAction("Privacy", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _context.Users
                                      .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserID", user.UserId);

                TempData["Message"] = $"Welcome back, {user.FName}!";
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid email or password. Please try again.");

            return View("~/Views/Home/Privacy.cshtml");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "You have been logged out.";
            return RedirectToAction("Privacy", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Home/Privacy.cshtml");
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