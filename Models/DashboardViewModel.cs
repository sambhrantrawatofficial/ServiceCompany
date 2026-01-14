namespace ServiceProvidingCompany.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalServices { get; set; }
        public int TotalBookings { get; set; }

        public int AcceptedBookings { get; set; }
        public int PendingBookings { get; set; }
        public int RejectedBookings { get; set; }
        public int CompeletedBookings { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal PlatformDues { get; set; }
        public decimal NetEarnings { get; set; }

        public double AverageRating { get; set; }

        public List<RatingItem> RatingBreakdown { get; set; } = new();
        public List<MonthlyBookingItem> MonthlyBookings { get; set; } = new();
    }

    public class RatingItem
    {
        public int Rating { get; set; }
        public int Count { get; set; }
    }

    public class MonthlyBookingItem
    {
        public int Month { get; set; }
        public int Count { get; set; }
    }
}
