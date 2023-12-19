using Aspekt.Exam.WebApi.DataAccess.Interfaces;
using Aspekt.Exam.WebApi.Mappers;
using Aspekt.Exam.WebApi.ModelDTOs;
using Aspekt.Exam.WebApi.ModelDTOs.OtherDTOs;
using Aspekt.Exam.WebApi.Models;
using Aspekt.Exam.WebApi.Services.Interfaces;

namespace Aspekt.Exam.WebApi.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void Create(ContactDto contact)
        {
            _contactRepository.Create(contact.ToDomain());
        }

        public void Delete(int contactId)
        {
            _contactRepository.Delete(contactId);
        }

        public List<ContactDto> FilterContact(int? countryId, int? companyId)
        {
            List<ContactDto> contactsDto = new List<ContactDto>();
            List<Contact> filteredContacts = new List<Contact>();
            try
            {

                if (companyId == null)
                {
                    filteredContacts = _contactRepository.GetAll().Where(x => x.CountryId.Equals(countryId)).ToList();
                }
                else if (countryId == null)
                {
                    filteredContacts = _contactRepository.GetAll().Where(x => x.CompanyId.Equals(companyId)).ToList();
                }
                else
                {
                    filteredContacts = _contactRepository.GetAll().Where(x => x.CountryId.Equals(countryId) && x.CompanyId.Equals(companyId)).ToList();
                }


                foreach (Contact item in filteredContacts)
                {
                    contactsDto.Add(item.ToDto());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Please set a filter!");
            }

            return contactsDto;
        }

        public List<ContactDto> GetAll()
        {
            List<Contact> contacts = _contactRepository.GetAll();

            List<ContactDto> contactsDto = new List<ContactDto>();

            foreach (Contact item in contacts)
            {
                contactsDto.Add(item.ToDto());
            }

            return contactsDto;
        }

        public List<ContactInfoDto> GetContactsWithCompanyAndCountry()
        {
            List<ContactInfoDto> contactInfos = new List<ContactInfoDto>();
            List<Contact> contacts = _contactRepository.GetAll().Where(x => x.Country != null && x.Company != null).ToList();

            foreach (Contact contact in contacts)
            {
                ContactInfoDto newContact = new ContactInfoDto
                {
                    Name = contact.Name,
                    CompanyName = contact.Company.Name,
                    Country = contact.Country.Name
                };
                contactInfos.Add(newContact);
            }

            return contactInfos;
        }

        public void Updade(ContactDto contact)
        {
            _contactRepository.Update(contact.ToDomain());
        }
    }
}
