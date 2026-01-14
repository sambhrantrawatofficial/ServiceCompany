using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceProvidingCompany.Models;

namespace ServiceProvidingCompany.Controllers
{
    public class CartController : Controller
    {

        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(string serviceId)
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("consumer", StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access this page.";
                return RedirectToAction("Index", "Login");
            }
            var userEmail = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Login");
            }
            var cartItem = new CartInfo
            {
                Cart_Id = Guid.NewGuid().ToString(),
                Consumer_Email = userEmail,
                Service_Id = serviceId.ToString()
            };
            _context.CartInfos.Add(cartItem);
            _context.SaveChanges();
            return Redirect(Request.Headers["Referer"].ToString());
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveFromCart(string cartId)
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("consumer", StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access this page.";
                return RedirectToAction("Index", "Login");
            }
            var userEmail = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Login");
            }

            var item = _context.CartInfos
                .FirstOrDefault(x => x.Cart_Id == cartId && x.Consumer_Email == userEmail);

            if (item != null)
            {
                _context.CartInfos.Remove(item);
                _context.SaveChanges();
            }

            return RedirectToAction("CartHome");
        }

        [Authorize]
        public IActionResult CartHome()
        {
            var role = Request.Cookies["UserRole"];
            if (!role?.Contains("consumer", StringComparison.OrdinalIgnoreCase) ?? true)
            {
                TempData["UnauthorisedAccess"] = "You are not authorized to access this page.";
                return RedirectToAction("Index", "Login");
            }
            var userEmail = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToAction("Index", "Login");
            }
            var cartServices = (from c in _context.CartInfos
                                join s in _context.ServiceInfos
                                on c.Service_Id equals s.Service_Id
                                where c.Consumer_Email == userEmail
                                select new
                                {
                                    c.Cart_Id,
                                    s.Service_Id,
                                    s.ServiceName,
                                    s.Pricing,
                                    s.Category,
                                    s.ImagePath
                                })
                                .AsEnumerable()
                                .Select(x =>
                                {
                                    decimal price = 0;
                                    decimal.TryParse(x.Pricing, out price);
                                    return new
                                    {
                                        x.Cart_Id,
                                        x.Service_Id,
                                        x.ServiceName,
                                        x.Category,
                                        x.ImagePath,
                                        Price = price
                                    };
                                })
                                .ToList();
            ViewBag.CartItems = cartServices;
            ViewBag.TotalPrice = cartServices.Sum(x => x.Price);
            return View();
        }


        //
    }
}