using System.ComponentModel.DataAnnotations;

public class Offer
{
    [Key]
    public int Offer_Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string OfferType { get; set; } // LIMITED_TIME, TOP_USERS
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int CurrentUsers { get; set; }
    public int MaxUsers { get; set; }
    public bool IsActive { get; set; }

    // ✅ MISSING COLUMN (ADD THIS)
    public string CouponCode { get; set; }
}
