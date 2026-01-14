using System.ComponentModel.DataAnnotations;

namespace ServiceProvidingCompany.Models
{
    public class CartInfo
    {
        [Key]
        [Required]
        public string? Cart_Id { get; set; }

        [Required]
        public string? Consumer_Email { get; set; }

        [Required]
        //Ref from Service Info
        public string? Service_Id { get; set; }

    }
}
