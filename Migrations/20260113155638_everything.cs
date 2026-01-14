using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceProvidingCompany.Migrations
{
    /// <inheritdoc />
    public partial class everything : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Initial_Book_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Consumer_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreferredTimeSlot1 = table.Column<TimeSpan>(type: "time", nullable: false),
                    PreferredTimeSlot2 = table.Column<TimeSpan>(type: "time", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Payment = table.Column<int>(type: "int", nullable: false),
                    Booking_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayPalOrderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Initial_Book_Id);
                });

            migrationBuilder.CreateTable(
                name: "CartInfos",
                columns: table => new
                {
                    Cart_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Consumer_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_Id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartInfos", x => x.Cart_Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTables",
                columns: table => new
                {
                    Category_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Category_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_images = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTables", x => x.Category_Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Contact_Info_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content_Heading = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Info_Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Contact_Info_Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Offer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentUsers = table.Column<int>(type: "int", nullable: false),
                    MaxUsers = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Offer_Id);
                });

            migrationBuilder.CreateTable(
                name: "QueryModels",
                columns: table => new
                {
                    Query_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueryModels", x => x.Query_Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceBookings",
                columns: table => new
                {
                    Booking_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Initial_Book_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consumer_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provider_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service_Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Customer_Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Booking_Completed_Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceBookings", x => x.Booking_Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceInfos",
                columns: table => new
                {
                    Service_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pricing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingHoursStart = table.Column<TimeSpan>(type: "time", nullable: true),
                    WorkingHoursEnd = table.Column<TimeSpan>(type: "time", nullable: true),
                    WeeklySchedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlockDates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSlots = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Radius = table.Column<int>(type: "int", nullable: false),
                    Addresses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationDocsPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotifyEmail = table.Column<bool>(type: "bit", nullable: false),
                    NotifySms = table.Column<bool>(type: "bit", nullable: false),
                    NotifyApp = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInfos", x => x.Service_Id);
                });

            migrationBuilder.CreateTable(
                name: "SignUps",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    User_Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUps", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CartInfos");

            migrationBuilder.DropTable(
                name: "CategoryTables");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "QueryModels");

            migrationBuilder.DropTable(
                name: "ServiceBookings");

            migrationBuilder.DropTable(
                name: "ServiceInfos");

            migrationBuilder.DropTable(
                name: "SignUps");
        }
    }
}
