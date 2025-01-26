using Microsoft.AspNetCore.Http;
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
                booking.Total = CalculateFare(booking.FarePrice);
                return View("Confirmation",booking);
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
    }
}
