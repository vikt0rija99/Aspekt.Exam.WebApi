using Aspekt.Exam.WebApi.DataAccess.Interfaces;
using Aspekt.Exam.WebApi.Mappers;
using Aspekt.Exam.WebApi.ModelDTOs;
using Aspekt.Exam.WebApi.Models;
using Aspekt.Exam.WebApi.Services.Interfaces;

namespace Aspekt.Exam.WebApi.Services
{
    public class CompanyService: ICompanyService
    {
        private ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void Create(CompanyDto company)
        {
            _companyRepository.Create(company.ToDomain());
        }

        public void Delete(int companyId)
        {
            _companyRepository.Delete(companyId);
        }

        public List<CompanyDto> GetAll()
        {
            List<Company> companies = _companyRepository.GetAll();
            List<CompanyDto> companyDtos = new List<CompanyDto>();
            foreach(Company item in companies)
            {
                companyDtos.Add(item.ToDto());
            }
            return companyDtos;
        }

        public void Update(CompanyDto company)
        {
            _companyRepository.Update(company.ToDomain());
        }
    }
}
