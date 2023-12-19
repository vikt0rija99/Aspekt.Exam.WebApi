using Aspekt.Exam.WebApi.DataAccess.Interfaces;
using Aspekt.Exam.WebApi.DataContext;
using Aspekt.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Aspekt.Exam.WebApi.DataAccess.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private AspektDbContext _aspektDbContext;

        public CompanyRepository(AspektDbContext aspektDbContext)
        {
            _aspektDbContext = aspektDbContext;
        }
        public int Create(Company entity)
        {
            if (entity.Id != 0)
            {
                throw new Exception("Auto Incrementing, Set It To Zero!");

            }
            _aspektDbContext.Companies.Add(entity);
            _aspektDbContext.SaveChanges();
            return entity.Id;
        }


        public void Delete(int id)
        {
            Company company = _aspektDbContext.Companies.FirstOrDefault(x => x.Id.Equals(id));
            if (company == null)
                throw new Exception($"Company with ID: {id} not found!");

            _aspektDbContext.Companies.Remove(company);
            _aspektDbContext.SaveChanges();
        }

        public List<Company> GetAll()
        {
            List<Company> companies = _aspektDbContext.Companies.ToList();
            if (companies.Count().Equals(0))
            {
                throw new Exception($"You Don't Have Any Companies!");
            }
            return companies;
        }

        public void Update(Company entity)
        {
            try
            {
                _aspektDbContext.Companies.Update(entity);
                _aspektDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("You cannot update a company that does not exist!");

            }
        }
    }
}
