using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceProvidingCompany.Models;

namespace ServiceProvidingCompany.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext db;
        private readonly PasswordHasher<SignUp> _passwordHasher;

        public LoginController(AppDbContext context)
        {
            db = context;
            _passwordHasher = new PasswordHasher<SignUp>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SignUp model)
        {
            // Frontend data check
            if (string.IsNullOrWhiteSpace(model.Email) ||
                string.IsNullOrWhiteSpace(model.Password))
            {
                ViewBag.Error = "Email and Password are required.";
                return View(model);
            }

            // Check email exists
            var user = db.SignUps.FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                ViewBag.Error = "Invalid credentials.";
                return View(model);
            }

            // Verify password
            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.Password,
                model.Password
            );
            if (result != PasswordVerificationResult.Success)
            {
                ViewBag.Error = "Invalid credentials.";
                return View(model);
            }

            // Determine role
            string finalRole =
                !string.IsNullOrEmpty(user.User_Role) &&
                user.User_Role.Contains("provider",
                    StringComparison.OrdinalIgnoreCase)
                ? "provider"
                : "consumer";

            // Set cookies (unchanged)
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // ✅ Set true in production
                SameSite = SameSiteMode.Lax,
                Expires = DateTimeOffset.Now.AddMinutes(30)
            };

            Response.Cookies.Append("UserEmail", user.Email!, cookieOptions);
            Response.Cookies.Append("UserName", user.Full_Name!, cookieOptions);
            Response.Cookies.Append("UserRole", finalRole, cookieOptions);

            // 🔐 FIX: Authorize for [Authorize] and antiforgery
            var identity = new System.Security.Claims.ClaimsIdentity(
                new[]
                {
                    // MUST have a unique Name claim for antiforgery
                    new System.Security.Claims.Claim(
                        System.Security.Claims.ClaimTypes.Name,
                        user.Email!)
                },
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var principal = new System.Security.Claims.ClaimsPrincipal(identity);

            // Create the auth cookie
            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal
            ).Wait();

            // Redirect to Home
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            // Remove auth cookie
            HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme
            ).Wait();

            // Remove custom cookies
            Response.Cookies.Delete("UserEmail");
            Response.Cookies.Delete("UserName");
            Response.Cookies.Delete("UserRole");

            // Optional: clear session
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}
