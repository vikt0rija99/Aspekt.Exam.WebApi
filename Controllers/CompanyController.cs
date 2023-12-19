using Aspekt.Exam.WebApi.ModelDTOs;
using Aspekt.Exam.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("add")]
        public ActionResult CreateCompany(CompanyDto companyDto)
        {
            _companyService.Create(companyDto);
            return StatusCode(StatusCodes.Status201Created, "Successfully Added New Company!");
        }

        [HttpGet("all")]
        public ActionResult<List<CompanyDto>> GetAll()
        { 
            List<CompanyDto> companies = _companyService.GetAll();
            return StatusCode(StatusCodes.Status200OK, companies);
        }

        [HttpDelete("{id}/delete")]
        public ActionResult Delete(int id)
        {
            _companyService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, "Company Successfully Deleted");
        }

        [HttpPost("update")]
        public ActionResult Update(CompanyDto companyDto)
        {
            _companyService.Update(companyDto);
            return StatusCode(StatusCodes.Status202Accepted, $"Successfully Updated Company with ID: {companyDto.Id}");
        }
    }
}
