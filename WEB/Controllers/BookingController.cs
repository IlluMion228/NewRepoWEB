using Microsoft.AspNetCore.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Extras = _context.Extras.ToList();
            return View(new Booking());
        }

        [HttpPost]
        public async Task<IActionResult> Index(Booking booking, int[] selectedExtras)
        {
            ViewBag.Extras = _context.Extras.ToList();

            if (ModelState.IsValid)
            {
                booking.Total = CalculateFare(booking.FarePrice);

                if (!string.IsNullOrEmpty(booking.PromoCode) && IsValidPromoCode(booking.PromoCode))
                {
                    booking.Total *= 0.9m; 
                }

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                if (selectedExtras != null && selectedExtras.Length > 0)
                {
                    foreach (var extraId in selectedExtras)
                    {
                        var bookingExtra = new BookingExtra
                        {
                            BookingId = booking.BookingId,
                            ExtraId = extraId
                        };
                        _context.BookingExtras.Add(bookingExtra);
                    }
                    await _context.SaveChangesAsync();
                }

                booking.ExtraFeatures = _context.Extras
                                                 .Where(e => _context.BookingExtras
                                                                      .Any(be => be.BookingId == booking.BookingId && be.ExtraId == e.ExtraId))
                                                 .Select(e => e.Name)
                                                 .ToList();

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
