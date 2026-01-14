using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceProvidingCompany.Models;
using System.Diagnostics;

namespace ServiceProvidingCompany.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        //========================================== Home Index ===============================================
        public IActionResult Index()
        {
            // Ensure SignUps DbSet
            var signUps = _context.SignUps?.ToList() ?? new List<ServiceProvidingCompany.Models.SignUp>();

            // Customer count
            int customerCount = signUps
                .Count(x => !string.IsNullOrEmpty(x.User_Role) &&
                            x.User_Role.IndexOf("Consumer", StringComparison.OrdinalIgnoreCase) >= 0);
            ViewBag.CustomerCount = customerCount;

            // Provider count
            int providerCount = signUps
                .Count(x => !string.IsNullOrEmpty(x.User_Role) &&
                            x.User_Role.IndexOf("Provider", StringComparison.OrdinalIgnoreCase) >= 0);
            ViewBag.ProviderCount = providerCount;

            // Avg Rating (overall)
            var ratings = _context.ServiceBookings
                .Where(b => b.Rating.HasValue)   // ignore unrated bookings
                .Select(b => b.Rating.Value)
                .ToList();

            var avgRating = ratings.Any()
                ? Math.Round(ratings.Average(), 1).ToString("0.0")
                : "0.0";

            ViewBag.AverageRating = avgRating;

            //Total bookings
            ViewBag.CompletedBookings = _context.ServiceBookings.Count();

            //====================Popular categories==============================
            ViewBag.CategoryRatings = _context.ServiceBookings
     .Where(sb => sb.Rating.HasValue)
     .Join(_context.CategoryTables,
         sb => sb.Service_Category,
         ct => ct.Category_name,
         (sb, ct) => new
         {
             CategoryId = ct.Category_Id,      // Add this
             CategoryName = ct.Category_name,
             CategoryImage = ct.Category_images,
             Rating = sb.Rating.Value
         })
     .GroupBy(x => new { x.CategoryId, x.CategoryName, x.CategoryImage })
     .Select(g => new
     {
         CategoryId = g.Key.CategoryId,      // Add this
         CategoryName = g.Key.CategoryName,
         CategoryImage = g.Key.CategoryImage,
         AvgRating = Math.Round(g.Average(x => x.Rating), 1)
     })
     .OrderByDescending(x => x.AvgRating)
     .Take(8)
     .ToList();

            //=====================Most booked services==========================
            var popularServices = _context.ServiceBookings
    .GroupBy(sb => sb.Service_Id)
    .Select(g => new
    {
        ServiceId = g.Key,
        BookingCount = g.Count()
    })
    .OrderByDescending(x => x.BookingCount)
    .Take(10)
    .ToList();
            var result = popularServices
                .Select(ps =>
                {
                    var service = _context.ServiceInfos
                        .FirstOrDefault(s => s.Service_Id == ps.ServiceId);

                    var ratings = _context.ServiceBookings
                        .Where(sb => sb.Service_Id == ps.ServiceId && sb.Rating > 0)
                        .Select(sb => sb.Rating)
                        .ToList();

                    double avgRating = (ratings?.Any() ?? false)
     ? Math.Round((double)ratings.Average(), 1)
     : 0;

                    return new
                    {
                        ServiceId = ps.ServiceId,
                        ServiceName = service?.ServiceName ?? "Service",
                        Category = service?.Category ?? "",
                        ImagePath = service?.ImagePath ?? "/images/default.jpg",
                        Price = service?.Pricing ?? "0",
                        BookingCount = ps.BookingCount,
                        AvgRating = avgRating
                    };
                })
                .OrderByDescending(x => x.BookingCount)
                .Take(10)
                .ToList();

            ViewBag.PopularServices = result;

            //==============================All services========================
            // Get all services ordered by name
            var services = _context.ServiceInfos
                .OrderBy(s => s.ServiceName)
                .ToList();

            // Get all bookings in memory
            var bookings = _context.ServiceBookings.ToList();

            // Calculate top 10 services by average rating
            var allServiceResult = services.Select(s =>
            {
                // Get ratings directly from ServiceBookings
                var ratings = bookings
                    .Where(sb => sb.Service_Id == s.Service_Id && sb.Rating > 0)
                    .Select(sb => sb.Rating)
                    .ToList();

                double avgRating = 0;
                if (ratings.Count > 0)
                {
                    avgRating = Math.Round((double)ratings.Average(), 1);
                }

                return new
                {
                    Id = s.Service_Id,
                    ServiceName = s.ServiceName,
                    AvgRating = avgRating,
                    Price = s.Pricing
                };
            })
            .OrderByDescending(x => x.AvgRating)
            .Take(8)
            .ToList();

            ViewBag.Services = allServiceResult;

            //View return
            return View();
        }


        //========================================== All Service View ===============================================
        public IActionResult AllServiceView()
        {
            var allServices = _context.ServiceInfos
                .OrderBy(s => s.ServiceName)
                .Select(s => new
                {
                    ServiceId = s.Service_Id,
                    s.ServiceName,
                    s.ImagePath,
                    s.Pricing,
                    s.Category,

                    // ✅ Total bookings for this service
                    TotalBookings = _context.ServiceBookings
                        .Count(sb => sb.Service_Id == s.Service_Id),

                    // ✅ Average rating (ignore null / 0)
                    AvgRating = _context.ServiceBookings
                        .Where(sb =>
                            sb.Service_Id == s.Service_Id &&
                            sb.Rating.HasValue &&
                            sb.Rating.Value > 0)
                        .Select(sb => sb.Rating.Value)
                        .Any()
                        ? Math.Round(
                            _context.ServiceBookings
                                .Where(sb =>
                                    sb.Service_Id == s.Service_Id &&
                                    sb.Rating.HasValue &&
                                    sb.Rating.Value > 0)
                                .Average(sb => sb.Rating.Value),
                            1)
                        : 0
                })
                .ToList();

            ViewBag.AllServices = allServices;
            return View();
        }

        public IActionResult ServiceMoreInfo(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return RedirectToAction(nameof(AllServiceView));
            var service = _context.ServiceInfos
                .FirstOrDefault(s => s.Service_Id == id);
            if (service == null)
                return RedirectToAction(nameof(AllServiceView));

            /* ⭐ Average Rating (ignore null/0) */
            var avgRating = _context.ServiceBookings
                .Where(sb =>
                    sb.Service_Id == id &&
                    sb.Rating.HasValue &&
                    sb.Rating.Value > 0)
                .Select(sb => sb.Rating.Value)
                .Any()
                ? Math.Round(
                    _context.ServiceBookings
                        .Where(sb =>
                            sb.Service_Id == id &&
                            sb.Rating.HasValue &&
                            sb.Rating.Value > 0)
                        .Average(sb => sb.Rating.Value),
                    1)
                : 0;

            /* 📦 Total Bookings */
            var totalBookings = _context.ServiceBookings
                .Count(sb => sb.Service_Id == id);

            /* 💬 Feedback with Consumer Name */
            var feedbacks =
                (from sb in _context.ServiceBookings
                 join u in _context.SignUps
                    on sb.Consumer_Email equals u.Email
                 where sb.Service_Id == id
                       && !string.IsNullOrEmpty(sb.Customer_Feedback)
                 orderby sb.Booking_Completed_Date descending
                 select new
                 {
                     ConsumerName = u.Full_Name,
                     sb.Rating,
                     sb.Customer_Feedback
                 }).ToList();

            ViewBag.AvgRating = avgRating;
            ViewBag.TotalBookings = totalBookings;
            ViewBag.Feedbacks = feedbacks;

            return View(service);

        }

        //========================================== Search View ===============================================
        [HttpGet]
        public async Task<IActionResult> SearchView(string? search)
        {
            var query = from service in _context.ServiceInfos
                        join booking in _context.ServiceBookings
                            on service.Service_Id equals booking.Service_Id into bookingsGroup
                        from booking in bookingsGroup.DefaultIfEmpty() // LEFT JOIN
                        group booking by new
                        {
                            service.Service_Id,
                            service.ServiceName,
                            service.Pricing,
                            service.ImagePath,
                            service.Category
                        } into g
                        select new
                        {
                            g.Key.Service_Id,
                            g.Key.ServiceName,
                            g.Key.Pricing,
                            g.Key.ImagePath,
                            g.Key.Category,
                            TotalBookings = g.Count(b => b != null),
                            AvgRating = g.Where(b => b != null && b.Rating != null).Any()
                                        ? g.Where(b => b != null && b.Rating != null).Average(b => b.Rating.Value)
                                        : 0
                        };

            // Optional search filter
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                query = query.Where(s => s.ServiceName.ToLower().Contains(search) ||
                                         s.Category.ToLower().Contains(search));
            }

            var services = await query.ToListAsync();

            return View(services);
        }

        //=================================All Category View=============================================
        public IActionResult AllCategoryView()
        {
            var data = _context.CategoryTables
                .Select(c => new
                {
                    CategoryId = c.Category_Id,
                    CategoryName = c.Category_name,
                    CategoryImage = c.Category_images,

                    AvgRating = _context.ServiceBookings
                        .Where(sb =>
                            sb.Service_Category == c.Category_name &&   // ✅ REAL LINK
                            sb.Rating.HasValue &&
                            sb.Rating.Value > 0)
                        .Select(sb => sb.Rating.Value)
                        .Any()
                        ? _context.ServiceBookings
                            .Where(sb =>
                                sb.Service_Category == c.Category_name &&
                                sb.Rating.HasValue &&
                                sb.Rating.Value > 0)
                            .Average(sb => sb.Rating.Value)
                        : 0
                })
                .OrderBy(x => x.CategoryName)
                .ToList();

            ViewBag.Categories = data;
            return View();
        }

        //=================================================Category More Info==============================================
        public IActionResult CategoryMoreInfo(string id) // id = Category_Id
        {
            if (string.IsNullOrWhiteSpace(id))
                return RedirectToAction(nameof(AllCategoryView));

            // Get category info by ID
            var category = _context.CategoryTables.FirstOrDefault(c => c.Category_Id == id);
            if (category == null)
                return RedirectToAction(nameof(AllCategoryView));

            // Filter services where Service.Category_name matches category.Category_name
            var services = _context.ServiceInfos
                .Where(s => s.Category == category.Category_name)
                .OrderBy(s => s.ServiceName)
                .ToList();

            ViewBag.Category = category;
            ViewBag.Services = services;

            return View();
        }

        //========================================== Error ===============================================
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
