using Aspekt.Exam.WebApi.ModelDTOs;

namespace Aspekt.Exam.WebApi.Services.Interfaces
{
    public interface ICompanyService
    {
        void Create(CompanyDto company);
        void Update(CompanyDto company);
        void Delete(int companyId);
        List<CompanyDto> GetAll();

    }
}
