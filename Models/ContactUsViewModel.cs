namespace ServiceProvidingCompany.Models
{
    public class ContactUsViewModel
    {
        public QueryModel QueryForm { get; set; } = new QueryModel();
        public List<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();
    }
}