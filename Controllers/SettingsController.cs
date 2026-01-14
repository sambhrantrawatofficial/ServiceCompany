using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceProvidingCompany.Models;
using System;
using System.Collections.Generic;

namespace ServiceProvidingCompany.Controllers
{
    public class SettingsController : Controller
    {
        private readonly AppDbContext _context;
        public SettingsController(AppDbContext context)
        {
            _context = context;
        }

        //Setting Home page
        [Authorize]
        [HttpGet]
        public IActionResult SettingsHome()
        {
            return View();
        }

        //My orders
        [Authorize]
        public IActionResult MyOrders()
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("consumer",
                    StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access the this page.";
                return RedirectToAction("Index", "Login");
            }
            var userEmail = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(userEmail))
                return RedirectToAction("Index", "Login");

            var bookings = (from b in _context.Bookings
                            join s in _context.ServiceInfos
                            on b.Service_Id equals s.Service_Id
                            where b.Consumer_Email == userEmail
                            select new
                            {
                                b.Initial_Book_Id,
                                b.Service_Id,
                                ServiceName = s.ServiceName,
                                b.Date,
                                b.PreferredTimeSlot1,
                                b.PreferredTimeSlot2,
                                b.Payment,
                                b.Address,
                                b.Phone,
                                s.Pricing,
                                Notes = string.IsNullOrEmpty(b.Notes) ? "No notes given" : b.Notes,
                                b.Booking_Status
                            }).ToList();

            // Pass as dynamic list
            return View(bookings.Cast<dynamic>().ToList());
        }

        //Contact
        [Authorize]
        public IActionResult ContactUs()
        {
            var contactInfos = _context.ContactInfos.ToList();
            var vm = new ContactUsViewModel
            {
                QueryForm = new QueryModel(),
                ContactInfos = contactInfos
            };
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Query(ContactUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Saves form submission
                _context.QueryModels.Add(model.QueryForm);
                await _context.SaveChangesAsync();

                TempData["ContactUsSuccess"] = "Message sent successfully!";
                return RedirectToAction("ContactUs");
            }

            // If the model is invalid, reload contact infos
            model.ContactInfos = _context.ContactInfos.ToList();
            return View(model);
        }

    }
}