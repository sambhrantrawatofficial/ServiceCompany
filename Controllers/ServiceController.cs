using Microsoft.AspNetCore.Mvc;
using ServiceProvidingCompany.Models;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

public class ServiceController : Controller
{
    private readonly AppDbContext _context;
    private readonly Cloudinary _cloudinary;

    public ServiceController(AppDbContext context, IConfiguration config)
    {
        _context = context;
        var cloudinaryUrl =
            Environment.GetEnvironmentVariable("CLOUDINARY_URL")
            ?? config["CLOUDINARY_URL"];

        if (string.IsNullOrWhiteSpace(cloudinaryUrl))
            throw new Exception("CLOUDINARY_URL is missing");

        _cloudinary = new Cloudinary(cloudinaryUrl);
    }

    // ================= GET =================
    [Authorize]
    [HttpGet]
    public IActionResult Create()
    {
        var role = Request.Cookies["UserRole"];
        if (!role?.Contains("provider", StringComparison.OrdinalIgnoreCase) ?? true)
        {
            TempData["UnauthorisedAccess"] = "You are not authorized to access this page.";
            return RedirectToAction("Index", "Login");
        }
        // Fetch categories from DB
        var categories = _context.CategoryTables
    .OrderBy(c => c.Category_name)
    .Select(c => c.Category_name)
    .ToList();

        ViewBag.Categories = categories;
        return View();
    }

    // ================= POST =================
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        ServiceInfo model,
        IFormFile UploadedImages,
        List<IFormFile> verificationDocs)
    {
        var role = Request.Cookies["UserRole"];
        if (!role?.Contains("provider",
                StringComparison.OrdinalIgnoreCase) ?? true)
        {
            TempData["UnauthorisedAccess"] = "You are not authorized to access the this page.";
            return RedirectToAction("Index", "Login");
        }

        // ================= SERVICE IMAGE (CLOUDINARY) =================
        if (UploadedImages != null && UploadedImages.Length > 0)
        {
            // Optional: validate image type
            var allowedTypes = new[] { "image/jpeg", "image/png", "image/webp" };
            if (!allowedTypes.Contains(UploadedImages.ContentType))
            {
                ModelState.AddModelError("", "Only image files are allowed.");
                return View(model);
            }

            using var stream = UploadedImages.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(UploadedImages.FileName, stream),
                Folder = "ServiceProvidingCompany/services",
                Transformation = new Transformation()
                                    .Quality("auto")
                                    .FetchFormat("auto")
                                    .Crop("limit")
                                    .Width(800)
                                    .Height(600)
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                model.ImagePath = uploadResult.SecureUrl.ToString();
            }
        }

        // ================= VERIFICATION DOCS (LOCAL STORAGE) =================
        if (verificationDocs != null && verificationDocs.Count > 0)
        {
            var docsFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "docs"
            );

            Directory.CreateDirectory(docsFolder);

            var docUrls = new List<string>();

            foreach (var doc in verificationDocs)
            {
                if (doc.Length == 0) continue;

                var fileName = Guid.NewGuid() + Path.GetExtension(doc.FileName);
                var fullPath = Path.Combine(docsFolder, fileName);

                using var stream = new FileStream(fullPath, FileMode.Create);
                await doc.CopyToAsync(stream);

                docUrls.Add("/docs/" + fileName);
            }

            model.VerificationDocsPath = string.Join(",", docUrls);
        }

        // ================= SAVE TO DATABASE =================
        _context.ServiceInfos.Add(model);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // ================= LIST =================
    [Authorize]
    public IActionResult Index()
    {
        var role = Request.Cookies["UserRole"];
        if (!role?.Contains("provider",
                StringComparison.OrdinalIgnoreCase) ?? true)
        {
            TempData["UnauthorisedAccess"] = "You are not authorized to access the this page.";
            return RedirectToAction("Index", "Login");
        }
        var services = _context.ServiceInfos.ToList();
        return View(services);
    }
}