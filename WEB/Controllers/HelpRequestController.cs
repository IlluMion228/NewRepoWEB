using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class HelpRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HelpRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitHelpForm(HelpRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Help/GetHelpForm.cshtml", model);
            }

            if (HttpContext.Session.GetInt32("UserId") is int userId)
            {
                model.UserId = userId;
            }
            else
            {
                TempData["Message"] = "Session expired. Please log in again.";
                return RedirectToAction("Login", "RegisterLogin");
            }

            _context.HelpRequests.Add(model);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Your request has been submitted successfully!";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult GetHelpForm()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HelpConfirmation()
        {
            return View(); 
        }
    }
}
