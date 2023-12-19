using Aspekt.Exam.WebApi.ModelDTOs;
using Aspekt.Exam.WebApi.Models;
using AutoMapper;

namespace Aspekt.Exam.WebApi.Mappers
{
    public static class ModelMapper
    {
        // COUNTRY
        public static CountryDto ToDto(this Country domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Country, CountryDto>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<CountryDto>(domainModel);
        }
        public static Country ToDomain(this CountryDto domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CountryDto, Country>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<Country>(domainModel);
        }
        // COMPANY
        public static CompanyDto ToDto(this Company domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyDto>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<CompanyDto>(domainModel);
        }

        public static Company ToDomain(this CompanyDto domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CompanyDto, Company>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<Company>(domainModel);
        }

        // CONTACT
        public static ContactDto ToDto(this Contact domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contact, ContactDto>();
                cfg.CreateMap<Country, CountryDto>();
                cfg.CreateMap<Company, CompanyDto>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<ContactDto>(domainModel);
        }

        public static Contact ToDomain(this ContactDto domainModel)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ContactDto, Contact>();
                cfg.CreateMap<CompanyDto, Company>();
                cfg.CreateMap<CountryDto, Country>();
            });

            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<Contact>(domainModel);
        }
    }
}
