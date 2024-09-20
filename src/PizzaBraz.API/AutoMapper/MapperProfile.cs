using AutoMapper;
using PizzaBraz.API.ViewModels.Company;
using PizzaBraz.API.ViewModels.Customer;
using PizzaBraz.API.ViewModels.User;
using PizzaBraz.Domain.Entities;
using PizzaBraz.Services.DTO;

namespace PizzaBraz.API.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUserViewModel, UserDTO>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateAt, opt => opt.Ignore());

            CreateMap<CreateCustomerViewModel, CustomerDTO>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateAt, opt => opt.Ignore());

            CreateMap<UserDTO, UserViewModel>();
            CreateMap<User, UserDTO>().ReverseMap();


            //CreateMap<User, UserDTO>().ReverseMap();
            //CreateMap<UserViewModel, UserDTO>().ReverseMap();

            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<CompanyViewModel, CompanyDTO>().ReverseMap();

            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomerViewModel, CustomerDTO>().ReverseMap();

        }
    }
}
