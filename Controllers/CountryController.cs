using Aspekt.Exam.WebApi.ModelDTOs;
using Aspekt.Exam.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountyService _countryService;

        public CountryController(ICountyService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost("add")]
        public ActionResult Create(CountryDto countryDto)
        {
            _countryService.Create(countryDto);
            return StatusCode(StatusCodes.Status201Created, "Successfully Added New Country!");
        }

        [HttpGet("all")]
        public ActionResult<List<CountryDto>> GetAll()
        {
            List<CountryDto> countries = _countryService.GetAll();
            return StatusCode(StatusCodes.Status200OK, countries);
        }

        [HttpDelete("{id}/delete")]
        public ActionResult Delete(int id)
        {
            _countryService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, "Country Successfully Deleted");
        }

        [HttpPost("update")]
        public ActionResult Update(CountryDto countryDto)
        {
            _countryService.Update(countryDto);
            return StatusCode(StatusCodes.Status202Accepted, $"Successfully Updated Country with ID: {countryDto.Id}");
        }
    }
}
