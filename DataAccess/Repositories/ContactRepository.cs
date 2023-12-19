using Aspekt.Exam.WebApi.DataAccess.Interfaces;
using Aspekt.Exam.WebApi.DataContext;
using Aspekt.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Aspekt.Exam.WebApi.DataAccess.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private AspektDbContext _aspektDbContext;
        public ContactRepository(AspektDbContext aspektDbContext)
        {
            _aspektDbContext = aspektDbContext;
        }

        public int Create(Contact entity)
        {
            Company company = _aspektDbContext.Companies.FirstOrDefault(x => x.Id.Equals(entity.CompanyId));
            Country country = _aspektDbContext.Countries.FirstOrDefault(x => x.Id.Equals(entity.CountryId));

            if (company == null)
                throw new Exception("Error!");
            if (country == null)
                throw new Exception("Error!");
            if (entity.Id != 0)
                throw new Exception("Auto Incrementing, Set It To Zero!");

            _aspektDbContext.Contacts.Add(entity);
            _aspektDbContext.SaveChanges();

            return entity.Id;
            
        }

        public void Delete(int id)
        {
            Contact contact = _aspektDbContext.Contacts.FirstOrDefault(x => x.Id.Equals(id));
            if (contact == null)
                throw new Exception($"Contact With ID: {id} Not Found");

            _aspektDbContext.Contacts.Remove(contact);
            _aspektDbContext.SaveChanges();
        }

        public List<Contact> GetAll()
        {
            List<Contact> contacts = _aspektDbContext.Contacts
                .Include(x => x.Company)
                .Include(x => x.Country)
                .ToList();

            if (contacts.Count().Equals(0))
            {
                throw new Exception($"You Don't Have Contacts!");
            }
            return contacts;
        }

        public void Update(Contact entity)
        {
            try
            {
                _aspektDbContext.Update(entity);
                _aspektDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error! Contact Does Not Exist!");
            }
        }
    }
}
