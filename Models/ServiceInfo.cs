using System;
using System.ComponentModel.DataAnnotations;

public class ServiceInfo
{
    [Key]
    public string? Service_Id { get; set; } = Guid.NewGuid().ToString();

    // --- Service Info ---
    [Required]
    public string? ServiceName { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public string? Pricing { get; set; }
    public string? Duration { get; set; }
    [Required]
    public string? Category { get; set; }
    [Required]
    public string? ImagePath { get; set; }

    // --- Availability ---
    [DataType(DataType.Time)]
    public TimeSpan? WorkingHoursStart { get; set; }
    [DataType(DataType.Time)]
    public TimeSpan? WorkingHoursEnd { get; set; }

    // --- Weekly Schedule ---
    public string? WeeklySchedule { get; set; }   // e.g. "Mon,Tue,Wed"

    // --- Time Slots ---
    public string? TimeSlots { get; set; }        // e.g. "Morning,Afternoon"

    // --- Location ---
    [Required]
    public string? City { get; set; }
    public string? PinCode { get; set; }
    public int Radius { get; set; }
    [Required]
    public string? Addresses { get; set; }        // store multiple addresses as comma-separated

    // --- Profile & Verification ---
    public string? FullName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? BusinessName { get; set; }
    public string? VerificationDocsPath { get; set; } // store uploaded docs path(s)

    // --- Notifications ---
    public bool NotifyEmail { get; set; }
    public bool NotifySms { get; set; }
    public bool NotifyApp { get; set; }
}