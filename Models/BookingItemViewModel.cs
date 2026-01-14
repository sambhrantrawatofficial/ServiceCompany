namespace ServiceProvidingCompany.Models.ViewModels
{
    public class BookingItemViewModel
    {
        public string ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Pricing { get; set; }
        public string Duration { get; set; }
        public string Category { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }

        public string ProviderName { get; set; }
        public string ProviderEmail { get; set; }
        public string BusinessName { get; set; }

        public string Initial_Book_Id { get; set; }
        public string Consumer_Email { get; set; }
        public string Address { get; set; }
        public string Landmark { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public string PreferredTimeSlot1 { get; set; }
        public string PreferredTimeSlot2 { get; set; }
        public string Notes { get; set; }
        public string Payment { get; set; }
        public string Booking_Status { get; set; }
    }
}