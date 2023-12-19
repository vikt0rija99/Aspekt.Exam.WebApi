using Aspekt.Exam.WebApi.DataAccess.Interfaces;
using Aspekt.Exam.WebApi.DataContext;
using Aspekt.Exam.WebApi.Models;

namespace Aspekt.Exam.WebApi.DataAccess.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private AspektDbContext _aspektDbContext;

        public CountryRepository(AspektDbContext aspektDbContext)
        {
            _aspektDbContext = aspektDbContext;
        }
        public int Create(Country entity)
        {
            if (entity.Id != 0)
            {
                throw new Exception("Country ID is automatically incremented, please set it to zero!");
            }
            _aspektDbContext.Countries.Add(entity);
            _aspektDbContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(int id)
        {
            Country country = _aspektDbContext.Countries.FirstOrDefault(x =>x.Id.Equals(id));

            if (country == null)
                throw new Exception($"Country With ID: {id} Not Found!");

            _aspektDbContext.Countries.Remove(country);
            _aspektDbContext.SaveChanges();
        }

        public List<Country> GetAll()
        {
            List<Country> countries = _aspektDbContext.Countries.ToList(); ;
            if (countries.Count().Equals(0))
            {
                throw new Exception($"You dont have any countries!");
            }
            return countries;
        }

        public void Update(Country entity)
        {
            try
            {
                _aspektDbContext.Countries.Update(entity);
                _aspektDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("You cannot update a country that does not exist!");
            }
        }
    }
}
