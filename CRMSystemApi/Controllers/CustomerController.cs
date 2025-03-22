using AutoMapper;
using CRM.BusinessLayer.Abstract;
using CRM.BusinessLayer.Concrete;
using CRMSystem.DtoLayer.CustomerDto;
using CRMSystem.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace CRMSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet("CustomerList")]
        public IActionResult CustomerList()
        {
            var values = _customerService.GetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var customer = _mapper.Map<Customer>(createCustomerDto);
            _customerService.Create(customer);
            return Ok(customer);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {

            var customer = _customerService.GetById(id);
            if (customer != null)
            {
                var result = _mapper.Map<GetCustomerDto>(customer);
                return Ok(result);
            }
            return NotFound("Müşteri bulunamadı");
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer != null) 
            {
                _customerService.Delete(customer);
                return Ok("Müşteri  başarıyla silindi");
            }
            return NotFound("Müşteri mevcut değil");
        }
        [HttpPut]
        public IActionResult UpdateCustomer(UpdateCustomerDto updateCustomerDto) 
        {
            var isExist = _customerService.IsExistsById(updateCustomerDto.CustomerID);
            if (!isExist) {
                return NotFound("Müşteri mevcut değil");
            }
            var customer = _mapper.Map<Customer>(updateCustomerDto);
            _customerService.Update(customer);
            return Ok(customer);
        }

    }
}
