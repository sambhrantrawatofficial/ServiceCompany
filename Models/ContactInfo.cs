using System.ComponentModel.DataAnnotations;

namespace ServiceProvidingCompany.Models
{
    public class ContactInfo
    {
        [Key]
        public string? Contact_Info_Id { get; set; }
        public string? Content_Heading { get; set; }
        public string? Content { get; set; }
        public string? Url { get; set; }
        public string? Contact_Info_Category { get; set; }
    }
}