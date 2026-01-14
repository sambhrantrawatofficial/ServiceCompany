using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceProvidingCompany.Models;
using System.Linq;

namespace ServiceProvidingCompany.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        // ================== PROFILE VIEW ==================
        [Authorize]
        public IActionResult Index()
        {
            var email = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Index", "Login");

            var user = _context.SignUps.FirstOrDefault(u => u.Email == email);
            if (user == null)
                return RedirectToAction("Index", "Login");

            // ✅ Sirf ek view return karo
            return View("Index", user);
        }

        // ================== EDIT PROFILE ==================
        [Authorize]
        public IActionResult Edit()
        {
            var email = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login", "Account");

            var user = _context.SignUps.FirstOrDefault(u => u.Email == email);
            if (user == null)
                return RedirectToAction("Login", "Account");

            return View(user);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfile(SignUp model)
        {
            var email = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login", "Account");

            var user = _context.SignUps.FirstOrDefault(u => u.Email == email);
            if (user == null)
                return RedirectToAction("Login", "Account");

            // ✅ Allow only these fields to change
            user.Full_Name = model.Full_Name;
            user.Phone_Number = model.Phone_Number;

            _context.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }


        // ================== DELETE PROFILE ==================
        [Authorize]
        public IActionResult Delete()
        {
            var email = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Index", "Login");

            var user = _context.SignUps.FirstOrDefault(u => u.Email == email);
            if (user == null)
                return RedirectToAction("Index", "Login");

            return View(user);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed()
        {
            var email = Request.Cookies["UserEmail"];
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Index", "Login");

            var user = _context.SignUps.FirstOrDefault(u => u.Email == email);
            if (user == null)
                return RedirectToAction("Index", "Login");

            _context.SignUps.Remove(user);
            _context.SaveChanges();

            Response.Cookies.Delete("UserEmail");

            return RedirectToAction("Index", "Login");
        }

    }
}


