using System.ComponentModel.DataAnnotations;

namespace ServiceProvidingCompany.Models
{
    public class CategoryTable
    {
        [Key]
        [Required]
        public string? Category_Id { get; set; }

        [Required]
        public string? Category_name { get; set; }

        [Required]
        public string? Category_images { get; set; }
    }
}
