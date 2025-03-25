using AutoMapper;
using CRMSystem.DtoLayer.CustomerDto;
using CRMSystem.EntityLayer.Entities;

namespace CRMSystemApi.Mapping
{
    public class CustomerMapping:Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customer,CreateCustomerDto>().ReverseMap();
            CreateMap<Customer,ResultCustomerDto>().ReverseMap();
            CreateMap<Customer,GetCustomerDto>().ReverseMap();
            CreateMap<Customer,UpdateCustomerDto>().ReverseMap();    
        }
    }
}
