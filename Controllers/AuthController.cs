using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceProvidingCompany.Models;

namespace ServiceProvidingCompany.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        // Service provider signup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUpServiceProvider(SignUp model1)
        {
            var existingUser = await _context.SignUps
                .FirstOrDefaultAsync(u => u.Email == model1.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email already exists");
                ViewData["Error"] = "User already exists";
                return View("SignUp", model1);
            }
            var newServiceProvider = new SignUp
            {
                Email = model1.Email,
                Full_Name = model1.Full_Name,
                Phone_Number = model1.Phone_Number,
                User_Role = "Service Provider"
            };
            var hasher = new PasswordHasher<SignUp>();
            newServiceProvider.Password = hasher.HashPassword(newServiceProvider, model1.Password);
            await _context.SignUps.AddAsync(newServiceProvider);
            await _context.SaveChangesAsync();
            return RedirectToAction("SignUpSuccessful", "Auth");
        }

        // Consumer signup
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUpConsumer(SignUp model2)
        {
            var existingUser = await _context.SignUps
                .FirstOrDefaultAsync(u => u.Email == model2.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Email already exists");
                ViewData["Error"] = "User already exists";
                return View("SignUp",model2);
            }
            var newConsumer = new SignUp
            {
                Email = model2.Email,
                Full_Name = model2.Full_Name,
                Phone_Number = model2.Phone_Number,
                User_Role = "Consumer"
            };
            var hasher = new PasswordHasher<SignUp>();
            newConsumer.Password = hasher.HashPassword(newConsumer, model2.Password);
            await _context.SignUps.AddAsync(newConsumer);
            await _context.SaveChangesAsync();
            return RedirectToAction("SignUpSuccessful", "Auth");
        }

        public IActionResult SignUpSuccessful()
        {
            return View();
        }


        //PC and Namspace closure
    }
}
