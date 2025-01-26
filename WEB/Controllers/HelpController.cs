using Microsoft.AspNetCore.Mvc;
using WEB.Models; // Импорт модели, если потребуется

public class HelpController : Controller
{
    [HttpPost]
    public IActionResult SubmitHelpForm(HelpFormModel model)
    {
        // Передаем данные в представление через ViewBag
        ViewBag.FirstName = model.FirstName;
        ViewBag.LastName = model.LastName;

        // Отображаем страницу HelpConfirmation
        return View("HelpConfirmation");
    }
}
