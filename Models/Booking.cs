using System.ComponentModel.DataAnnotations;

namespace ServiceProvidingCompany.Models
{
    public enum PaymentMethod
    {
        UPI,
        Card,
        CashOnDelivery
    }

    public class Booking
    {
        [Key]
        public string? Initial_Book_Id { get; set; }

        public string? Consumer_Email { get; set; }

        // Ref from Service Info
        public string? Service_Id { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? Landmark { get; set; }

        [Required]
        public string? Phone { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan PreferredTimeSlot1 { get; set; }

        [Required]
        public TimeSpan PreferredTimeSlot2 { get; set; }

        public string? Notes { get; set; }

        [Required]
        public PaymentMethod Payment { get; set; }

        public string? Booking_Status { get; set; }

        // ✅ PayPal fields (nullable for COD / UPI)
        public string? PayPalOrderId { get; set; }

        public string? PaymentStatus { get; set; } // Paid / COD / Pending
    }
}