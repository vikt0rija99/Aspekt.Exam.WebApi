using Aspekt.Exam.WebApi.ModelDTOs;
using Aspekt.Exam.WebApi.ModelDTOs.OtherDTOs;

namespace Aspekt.Exam.WebApi.Services.Interfaces
{
    public interface IContactService
    {
        void Create(ContactDto contact);
        void Updade(ContactDto contact);
        void Delete(int contactId);
        List<ContactDto> GetAll();
        List<ContactInfoDto> GetContactsWithCompanyAndCountry();
        List<ContactDto> FilterContact(int? countryId, int? companyId);
    }
}
