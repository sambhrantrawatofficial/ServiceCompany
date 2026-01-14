using System.ComponentModel.DataAnnotations;

namespace ServiceProvidingCompany.Models
{
    public class SignUp
    {
        [Key]
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
        [Required]        
        public string? Full_Name { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Phone number must be at least 10 digits long")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits")]
        public string? Phone_Number { get; set; }
        [Required]
        public string? User_Role { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
