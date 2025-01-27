using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace WEB.Controllers
{
    public class HelpController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HelpController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Help/GetHelpForm
        public IActionResult GetHelpForm()
        {
            return View("~/Views/Help/GetHelpForm");
        }

        // POST: Help/SubmitHelpForm
        [HttpPost]
        public async Task<IActionResult> SubmitHelpForm(Help model)
        {
            if (ModelState.IsValid)
            {
                // Добавляем запрос в базу данных
                model.RequestDate = DateTime.Now; // Устанавливаем текущую дату запроса
                _context.HelpRequests.Add(model);
                await _context.SaveChangesAsync(); // Сохраняем запрос в базе данных

                // Передаем данные на страницу подтверждения
                TempData["FirstName"] = model.FName;
                TempData["LastName"] = model.LName;

                // Редирект на страницу подтверждения
                return RedirectToAction("HelpConfirmation");
            }

            // Если модель невалидна, возвращаем на форму с ошибками
            ModelState.AddModelError("", "Произошла ошибка при отправке запроса. Пожалуйста, проверьте форму и попробуйте снова.");
            return View("GetHelpForm");  // Возвращаем на форму с ошибками
        }

        // GET: Help/HelpConfirmation
        public IActionResult HelpConfirmation()
        {
            // Выводим данные из TempData (если переданы)
            ViewBag.FirstName = TempData["FirstName"];
            ViewBag.LastName = TempData["LastName"];

            // Отображаем страницу подтверждения
            return View();
        }
    }
}