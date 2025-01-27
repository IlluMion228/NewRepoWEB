using Microsoft.AspNetCore.Mvc;
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


        // Display Register/Login page
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Handle Registration and Login form submissions
        [HttpPost]
        public IActionResult Index(UserModel user)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(user.FName) && !string.IsNullOrEmpty(user.LName))
                {
                    // Handle the registration process (saving to a database, etc.)
                    // For example, save user to database (pseudo code):
                    // _context.Users.Add(user);
                    // _context.SaveChanges();

                    TempData["Message"] = "Registration successful!";
                    return RedirectToAction("Index"); // Redirect back to the same page
                }
                else
                {
                    // Handle login logic here
                    // For example, verify the user credentials from the database
                    // if (user.Email == "existing@example.com" && user.Password == "correctpassword")
                    //{
                    //   TempData["Message"] = "Login successful!";
                    //   return RedirectToAction("Home");
                    //}

                    TempData["Message"] = "Login failed. Please check your credentials.";
                }
            }
            return View(user);
        }
    }
}
