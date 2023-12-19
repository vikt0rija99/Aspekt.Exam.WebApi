using Aspekt.Exam.WebApi.ModelDTOs;

namespace Aspekt.Exam.WebApi.Services.Interfaces
{
    public interface ICountyService
    {
        void Create(CountryDto country);
        void Update(CountryDto country);
        void Delete(int countryId);
        List<CountryDto> GetAll();



    }
}
