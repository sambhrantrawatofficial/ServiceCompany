using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceProvidingCompany.Models;

namespace ServiceProvidingCompany.Controllers
{
    public class ViewBookingController : Controller
    {
        private readonly AppDbContext _context;
        public ViewBookingController(AppDbContext context)
        {
            _context = context;
        }

        //View Booking page
        [Authorize]
        public IActionResult ViewBookingHome()
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("provider",
                    StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access the this page.";
                return RedirectToAction("Index", "Login");
            }

            // getting provider email 
            var providerEmail = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(providerEmail))
                return RedirectToAction("Index", "Login");

            //bookings
            var bookings = (from b in _context.Bookings
                            join s in _context.ServiceInfos
                                on b.Service_Id equals s.Service_Id
                            where s.Email == providerEmail
                            select new
                            {
                                b.Initial_Book_Id,
                                s.ServiceName,
                                b.Consumer_Email,
                                b.Address,
                                b.Date,
                                b.PreferredTimeSlot1,
                                b.PreferredTimeSlot2,
                                b.Booking_Status
                            }).ToList<dynamic>();

            return View(bookings);
        }

        //View Booking Details page
        [Authorize]
        public IActionResult ViewBookingGetInfo(string id)
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("provider", StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access this page.";
                return RedirectToAction("Index", "Login");
            }

            var providerEmail = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(providerEmail))
                return RedirectToAction("Index", "Login");

            // join service info and booking cs
            var booking = (from b in _context.Bookings
                           join s in _context.ServiceInfos
                               on b.Service_Id equals s.Service_Id
                           join u in _context.SignUps
                               on b.Consumer_Email equals u.Email
                           where b.Initial_Book_Id == id && s.Email == providerEmail
                           select new
                           {
                               b.Initial_Book_Id,
                               u.Full_Name,
                               u.Email,
                               u.Phone_Number,
                               b.Address,
                               b.Landmark,
                               b.Date,
                               b.PreferredTimeSlot1,
                               b.PreferredTimeSlot2,
                               b.Notes,
                               b.Payment,
                               b.Booking_Status,
                               s.Service_Id,
                               s.ServiceName,
                               s.Category,
                               s.Pricing
                           }).FirstOrDefault();

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        //Accept booking
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AcceptBooking(string id)
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("provider", StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access this page.";
                return RedirectToAction("Index", "Login");
            }

            var providerEmail = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(providerEmail))
                return RedirectToAction("Index", "Login");

            var booking = _context.Bookings.FirstOrDefault(b => b.Initial_Book_Id == id);
            if (booking == null)
                return NotFound();

            var service = _context.ServiceInfos.FirstOrDefault(s => s.Service_Id == booking.Service_Id);
            if (service == null || service.Email != providerEmail)
                return Unauthorized();

            // booking status
            booking.Booking_Status = "Accepted";
            _context.SaveChanges();

            TempData["Success"] = "Booking accepted and updated everywhere.";
            return RedirectToAction("ViewBookingHome", "ViewBooking");
        }


        //Reject Booking
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RejectBooking(string id)
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("provider", StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access this page.";
                return RedirectToAction("Index", "Login");
            }

            var providerEmail = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(providerEmail))
                return RedirectToAction("Index", "Login");

            var booking = _context.Bookings.FirstOrDefault(b => b.Initial_Book_Id == id);
            if (booking == null)
                return NotFound();

            var service = _context.ServiceInfos.FirstOrDefault(s => s.Service_Id == booking.Service_Id);
            if (service == null || service.Email != providerEmail)
                return Unauthorized();

            booking.Booking_Status = "Rejected";
            _context.SaveChanges();

            TempData["Success"] = "Booking rejected.";
            return RedirectToAction("ViewBookingHome");
        }

        //Complete Booking Action
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompleteBooking(string id)
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("provider", StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access this page.";
                return RedirectToAction("Index", "Login");
            }
            var providerEmail = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(providerEmail))
            {
                return RedirectToAction("Index", "Login");
            }
            var booking = _context.Bookings.FirstOrDefault(b => b.Initial_Book_Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            if (!booking.Booking_Status.Equals("Accepted", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Only accepted bookings can be completed.");
            }

            var service = _context.ServiceInfos.FirstOrDefault(s => s.Service_Id == booking.Service_Id);
            if (service == null || service.Email != providerEmail)
            {
                return Unauthorized();
            }

            booking.Booking_Status = "Completed";

            // ServiceBookings 1
            var serviceBooking = new ServiceBookings
            {
                Booking_Id = Guid.NewGuid().ToString(),
                Initial_Book_Id = booking.Initial_Book_Id,
                Consumer_Email = booking.Consumer_Email,
                Provider_Email = providerEmail,
                Service_Id = booking.Service_Id,
                Service_Category = service.Category,
                Booking_Completed_Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
            _context.ServiceBookings.Add(serviceBooking);

            // Save changes in db
            _context.SaveChanges();

            TempData["Success"] = "Booking marked as completed.";
            return RedirectToAction("ViewBookingHome");
        }


        //
    }
}