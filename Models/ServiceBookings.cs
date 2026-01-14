using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceProvidingCompany.Models
{
    public class ServiceBookings
    {
        [Key]
        [Required]
        public string? Booking_Id { get; set; }

        [Required]
        //Ref from Booking.cs
        public string? Initial_Book_Id { get; set; }

        [Required]
        public string? Consumer_Email { get; set; }

        [Required]
        public string? Provider_Email { get; set; }

        [Required]
        public string? Service_Id { get; set; }

        [Required]
        public string? Service_Category { get; set; }

        public int? Rating { get; set; }

        public string? Customer_Feedback { get; set; }

        [Required]
        public string? Booking_Completed_Date { get; set; }


        //
    }
}