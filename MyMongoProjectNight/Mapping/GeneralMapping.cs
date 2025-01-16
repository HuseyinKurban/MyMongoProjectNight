using AutoMapper;
using MyMongoProjectNight.Dtos.CustomerDtos;
using MyMongoProjectNight.Dtos.DepartmentDtos;
using MyMongoProjectNight.Entities;

namespace MyMongoProjectNight.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, GetByIdCustomerDto>().ReverseMap();

            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();
            CreateMap<Department, ResultDepartmentDto>().ReverseMap();
            CreateMap<Department, GetByIdDepartmentDto>().ReverseMap();

            CreateMap<Customer, ResultCustomerWithCategoryDto>().ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.DepartmentName));
        }
    }
}
