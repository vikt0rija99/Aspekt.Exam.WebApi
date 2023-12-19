using Aspekt.Exam.WebApi.ModelDTOs;
using Aspekt.Exam.WebApi.ModelDTOs.OtherDTOs;
using Aspekt.Exam.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aspekt.Exam.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost("add")]
        public ActionResult Create(ContactDto contactDto)
        {
            _contactService.Create(contactDto);
            return StatusCode(StatusCodes.Status201Created, "Successfully Added New Contact!");
        }

        [HttpGet("all")]
        public ActionResult<List<ContactDto>> GetAll()
        {
            List<ContactDto> contacts = _contactService.GetAll();
            return StatusCode(StatusCodes.Status200OK, contacts);
        }

        [HttpDelete("{id}/delete")]
        public ActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, "Contact Successfully Deleted");
        }

        [HttpPost("update")]
        public ActionResult Update(ContactDto contactDto)
        {
            _contactService.Updade(contactDto);
            return StatusCode(StatusCodes.Status202Accepted, $"Successfully Updated Contact with ID: {contactDto.Id}");
        }

        [HttpGet("filter/{countryId}/{companyId}")]
        public ActionResult<List<ContactDto>> FilterContacts(int countryId, int companyId)
        {
            List<ContactDto> filteredContacts = _contactService.FilterContact(countryId, companyId);
            return StatusCode(StatusCodes.Status202Accepted, filteredContacts);
        }

        [HttpGet("filterbycountry/{countryId}")]
        public ActionResult<List<ContactDto>> FilterContactsByCountry(int countryId)
        {
            List<ContactDto> filteredContacts = _contactService.FilterContact(countryId, null);
            return StatusCode(StatusCodes.Status202Accepted, filteredContacts);
        }

        [HttpGet("filterbycompany/{companyId}")]
        public ActionResult<List<ContactDto>> FilterContactsByCompany(int companyId)
        {
            List<ContactDto> filteredContacts = _contactService.FilterContact(null, companyId);
            return StatusCode(StatusCodes.Status202Accepted, filteredContacts);
        }

        [HttpGet("getcontactwithcompanyandcountry")]
        public ActionResult<List<ContactDto>> GetContactWithCompanyAndCountry()
        {
            List<ContactInfoDto> contacts = _contactService.GetContactsWithCompanyAndCountry();
            return StatusCode(StatusCodes.Status202Accepted, contacts);
        }

    }

  }
