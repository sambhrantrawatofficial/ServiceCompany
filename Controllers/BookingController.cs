using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceProvidingCompany.Models;

namespace ServiceProvidingCompany.Controllers
{

    public class BookingController : Controller
    {

        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("consumer",
                    StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access the this page.";
                return RedirectToAction("Index", "Login");
            }
            var email = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }
            var cartItems = _context.CartInfos.Where(c => c.Consumer_Email == email).ToList();
            if (!cartItems.Any())
            {
                return RedirectToAction("CartHome", "Cart");
            }
            return View(new Booking());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Booking(Booking booking, string PayPalOrderId)
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("consumer", StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access this page.";
                return RedirectToAction("Index", "Login");
            }

            var email = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Index", "Login");

            if (!ModelState.IsValid)
            {
                return View("Index", booking);
            }

            // 🔒 CARD PAYMENT VALIDATION
            if (booking.Payment == PaymentMethod.Card)
            {
                if (string.IsNullOrEmpty(PayPalOrderId))
                {
                    ModelState.AddModelError("", "Payment not completed");
                    return View("Index", booking);
                }

                booking.PaymentStatus = "Paid";
                booking.PayPalOrderId = PayPalOrderId;
            }
            else if (booking.Payment == PaymentMethod.CashOnDelivery)
            {
                booking.PaymentStatus = "COD";
            }
            else if (booking.Payment == PaymentMethod.UPI)
            {
                booking.PaymentStatus = "Pending";
            }

            var cartItems = _context.CartInfos
                .Where(c => c.Consumer_Email == email)
                .ToList();

            if (!cartItems.Any())
                return RedirectToAction("CartHome", "Cart");

            foreach (var item in cartItems)
            {
                _context.Bookings.Add(new Booking
                {
                    Initial_Book_Id = Guid.NewGuid().ToString(),
                    Consumer_Email = email,
                    Service_Id = item.Service_Id,

                    Address = booking.Address,
                    Landmark = booking.Landmark,
                    Phone = booking.Phone,
                    Date = booking.Date,
                    PreferredTimeSlot1 = booking.PreferredTimeSlot1,
                    PreferredTimeSlot2 = booking.PreferredTimeSlot2,
                    Notes = booking.Notes,

                    Payment = booking.Payment,
                    PaymentStatus = booking.PaymentStatus,
                    PayPalOrderId = booking.PayPalOrderId,

                    Booking_Status = "Pending"
                });
            }

            _context.CartInfos.RemoveRange(cartItems);
            _context.SaveChanges();

            return RedirectToAction("BookingSuccess", "Booking");
        }

        [Authorize]
        public IActionResult BookingSuccess()
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("consumer",
                    StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access the this page.";
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        //
    }
}