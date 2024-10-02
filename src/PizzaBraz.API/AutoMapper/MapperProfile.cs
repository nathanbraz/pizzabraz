using AutoMapper;
using PizzaBraz.API.ViewModels.Company;
using PizzaBraz.API.ViewModels.Customer;
using PizzaBraz.API.ViewModels.Order;
using PizzaBraz.API.ViewModels.OrderItem;
using PizzaBraz.API.ViewModels.Product;
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

            CreateMap<CreateProductViewModel, ProductDTO>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<CreateOrderViewModel, OrderDTO>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<CreateOrderItemViewModel, OrderItemDTO>()
               .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
               .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<UserDTO, UserViewModel>();
            CreateMap<User, UserDTO>().ReverseMap();


            //CreateMap<User, UserDTO>().ReverseMap();
            //CreateMap<UserViewModel, UserDTO>().ReverseMap();

            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<CompanyViewModel, CompanyDTO>().ReverseMap();

            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomerViewModel, CustomerDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductViewModel, ProductDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderViewModel, OrderDTO>().ReverseMap();

            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            //CreateMap<OrderItemViewModel, OrderDTO>().ReverseMap();

        }
    }
}
