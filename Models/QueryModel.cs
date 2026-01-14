using System.ComponentModel.DataAnnotations;

namespace ServiceProvidingCompany.Models
{
    public class QueryModel
    {
        [Key]
        [Required]
        public string Query_Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string? Full_Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Message { get; set; }
    }
}
