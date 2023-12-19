using Aspekt.Exam.WebApi.DataAccess.Interfaces;
using Aspekt.Exam.WebApi.Mappers;
using Aspekt.Exam.WebApi.ModelDTOs;
using Aspekt.Exam.WebApi.Models;
using Aspekt.Exam.WebApi.Services.Interfaces;

namespace Aspekt.Exam.WebApi.Services
{
    public class CountryService : ICountyService
    {
        private ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public void Create(CountryDto country)
        {
            _countryRepository.Create(country.ToDomain());
        }

        public List<CountryDto> GetAll()
        {
            List<Country> countries = _countryRepository.GetAll();
            List<CountryDto> countriesDto = new List<CountryDto>();

            foreach (Country item in countries)
            {
                countriesDto.Add(item.ToDto());
            }

            return countriesDto;
        }

        public void Delete(int countryId)
        {
            _countryRepository.Delete(countryId);
        }

        public void Update(CountryDto country)
        {
            _countryRepository.Update(country.ToDomain());
        }
    }
}
