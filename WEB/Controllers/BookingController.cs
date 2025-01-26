using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Booking());
        }

        [HttpPost]
        public IActionResult Index(Booking booking)
        {
            if (ModelState.IsValid)
            {
                // Расчет стоимости поездки
                booking.Total = CalculateFare(booking.FarePrice);

                // Применение скидки, если промокод корректен
                if (!string.IsNullOrEmpty(booking.PromoCode) && IsValidPromoCode(booking.PromoCode))
                {
                    booking.Total *= 0.9m; // Скидка 10%
                }

                return View("Confirmation", booking);
            }
            return View(booking);
        }

        private decimal CalculateFare(string fareOption)
        {
            return fareOption switch
            {
                "0-10" => 5.00m,
                "0-10-return" => 10.00m,
                "11-20" => 10.00m,
                "11-20-return" => 20.00m,
                "21-40" => 25.00m,
                "21-40-return" => 50.00m,
                _ => 0.00m
            };
        }

        private bool IsValidPromoCode(string promoCode)
        {
            return promoCode == "DISCOUNT10"; 
        }
    }
}
