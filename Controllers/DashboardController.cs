using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceProvidingCompany.Models;
using ServiceProvidingCompany.Models.ViewModels;

namespace ServiceProvidingCompany.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Dashboardview()
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("provider", StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access this page.";
                return RedirectToAction("Index", "Login");
            }
            string email = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login", "Login");

            var model = new DashboardViewModel();

            // Load provider bookings
            var providerBookings = await (
             from s in _context.ServiceInfos
             join b in _context.Bookings
                 on s.Service_Id equals b.Service_Id
             where s.Email == email
             // ✅ only completed bookings
             select new BookingItemViewModel
             {
                 ServiceId = s.Service_Id,
                 ServiceName = s.ServiceName,
                 Description = s.Description,
                 Pricing = Convert.ToInt32(s.Pricing),
                 Duration = s.Duration,
                 Category = s.Category,
                 City = s.City,
                 PinCode = s.PinCode,
                 ProviderName = s.FullName,
                 ProviderEmail = s.Email,
                 BusinessName = s.BusinessName,
                 Initial_Book_Id = b.Initial_Book_Id,
                 Consumer_Email = b.Consumer_Email,
                 Address = b.Address,
                 Landmark = b.Landmark,
                 Phone = b.Phone,
                 Date = b.Date,
                 PreferredTimeSlot1 = b.PreferredTimeSlot1.ToString(),
                 PreferredTimeSlot2 = b.PreferredTimeSlot2.ToString(),
                 Notes = b.Notes,
                 Payment = b.Payment.ToString(),
                 Booking_Status = b.Booking_Status
             }).ToListAsync();

            /* ---------------- COUNTS ---------------- */
            model.TotalServices = providerBookings
        .Select(x => x.ServiceId)
        .Distinct()
        .Count();

            model.TotalBookings = providerBookings.Count;

            /* ---------------- STATUS ---------------- */
            model.AcceptedBookings = providerBookings.Count(x => x.Booking_Status == "Accepted");
            model.PendingBookings = providerBookings.Count(x => x.Booking_Status == "Pending");
            model.RejectedBookings = providerBookings.Count(x => x.Booking_Status == "Rejected");
            model.CompeletedBookings = providerBookings.Count(x => x.Booking_Status == "Completed");
            /* ---------------- EARNINGS ---------------- */
            const decimal earningPerBooking = 500m;
            model.TotalEarnings = model.CompeletedBookings * earningPerBooking;
            model.PlatformDues = model.TotalEarnings * 0.10m;
            model.NetEarnings = model.TotalEarnings - model.PlatformDues;

            /* ---------------- RATINGS ---------------- */
            // Get all ratings from ServiceBookings
            var ratings = await _context.ServiceBookings
                .Where(sb => sb.Rating > 0)   // only positive ratings
                .Select(sb => sb.Rating)
                .ToListAsync();

            // Average rating
            model.AverageRating = ratings.Any()
                ? Math.Round((double)ratings.Average(), 1)
                : 0;

            // Breakdown by rating value
            model.RatingBreakdown = ratings
                .GroupBy(r => r)
                .Select(g => new RatingItem
                {
                    Rating = (int)g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Rating)
                .ToList();
            /* ---------------- MONTHLY BOOKINGS ---------------- */
            model.MonthlyBookings = providerBookings
        .GroupBy(b => Convert.ToDateTime(b.Date).Month)
        .Select(g => new MonthlyBookingItem
        {
            Month = g.Key,
            Count = g.Count()
        })
        .OrderBy(x => x.Month)
        .ToList();

            return View(model);
        }
    }
}
