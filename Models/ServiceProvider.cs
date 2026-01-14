using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceProvidingCompany.Models
{
    public class ServiceProvider
    {
        [Key]
        public int Id { get; set; }

        // --- Service Info ---
        [Required]
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public decimal Pricing { get; set; }
        public string Duration { get; set; }
        public string Category { get; set; }
        public string UploadedImages { get; set; } // store file paths or URLs

        // --- Availability ---
        public string WorkingHoursStart { get; set; }
        public string WorkingHoursEnd { get; set; }
        public string WeeklySchedule { get; set; }   // e.g. "Mon|Tue|Wed"
        // pipe-separated dates
        public string TimeSlots { get; set; }        // e.g. "Morning|Afternoon|Evening"

        // --- Location ---
        public string City { get; set; }
        public string PinCode { get; set; }
        public string Radius { get; set; }

        // Multiple addresses stored as pipe-separated string
        public string Addresses { get; set; } // e.g. "Address1|Address2|Address3"

        // --- Profile & Verification ---
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BusinessName { get; set; }

        // Multiple verification docs stored as pipe-separated string
        public string VerificationDocs { get; set; } // e.g. "KYC.pdf|GST.pdf|ID.jpg"

        // --- Notifications ---
        public bool NotifyEmail { get; set; }
        public bool NotifySms { get; set; }
        public bool NotifyApp { get; set; }

        // --- Helper methods ---
        [NotMapped]
        public List<string> AddressList
        {
            get => string.IsNullOrEmpty(Addresses) ? new List<string>() : new List<string>(Addresses.Split('|'));
            set => Addresses = value != null ? string.Join("|", value) : null;
        }

        [NotMapped]
        public List<string> VerificationDocsList
        {
            get => string.IsNullOrEmpty(VerificationDocs) ? new List<string>() : new List<string>(VerificationDocs.Split('|'));
            set => VerificationDocs = value != null ? string.Join("|", value) : null;
        }
    }
}
