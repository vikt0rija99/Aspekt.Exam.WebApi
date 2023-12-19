using Aspekt.Exam.WebApi.Models;

namespace Aspekt.Exam.WebApi.ModelDTOs
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public CompanyDto Company { get; set; }
        public int CountryId { get; set; }
        public CountryDto Country { get; set; }
    }
}
