using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace ServiceProvidingCompany.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        public DbSet<ServiceInfo> ServiceInfos { get; set; }
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<ServiceBookings> ServiceBookings { get; set; }
        public DbSet<CategoryTable> CategoryTables { get; set; }
        public DbSet<CartInfo> CartInfos { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<QueryModel> QueryModels { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
    }
}