using AutoMapper;
using CRM.BusinessLayer.Abstract;
using CRM.BusinessLayer.Concrete;
using CRMSystem.DtoLayer.CustomerDto;
using CRMSystem.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using System.Text.Json;

namespace CRMSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ICustomerService customerService, IMapper mapper, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet("CustomerList")]
        public IActionResult CustomerList()
        {
            try
            {
               
                var values = _customerService.GetList();
                _logger.LogInformation("Create Customer - Params:{0}", JsonSerializer.Serialize(values));
                return Ok(values);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata meydana geldi");
                return StatusCode(500, "Bir hata oluştu daha sonra tekrar deneyin");
            }
        }
        
        [HttpPost]
        public IActionResult CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            try
            {
                _logger.LogInformation("Create Customer - Params:{0}", JsonSerializer.Serialize(createCustomerDto));
                var customer = _mapper.Map<Customer>(createCustomerDto);
                _customerService.Create(customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata meydana geldi");
                return StatusCode(500, "Bir hata oluştu daha sonra tekrar deneyin");
            }


        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                _logger.LogInformation("Get by id - Params: id:{0}", id);
                var customer = _customerService.GetById(id);
                if (customer != null)
                {
                    _logger.LogInformation("Müşteri bulundu");
                    var result = _mapper.Map<GetCustomerDto>(customer);
                    return Ok(result);
                }
                _logger.LogWarning("Müşteri bulunamadı");
                return NotFound("Müşteri bulunamadı");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata meydana geldi");
                return StatusCode(500, "Bir hata oluştu daha sonra tekrar deneyin");
            }

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var customer = _customerService.GetById(id);
                if (customer != null)
                {

                    _customerService.Delete(customer);
                    _logger.LogInformation("Müşteri silindi");
                    return Ok("Müşteri  başarıyla silindi");
                }
                return NotFound("Müşteri mevcut değil");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Bir hata meydana geldi");
                return StatusCode(500, "Bir hata oluştu daha sonra tekrar deneyin");
            }
        }
        [HttpPut]
        public IActionResult UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            try
            {
                var isExist = _customerService.IsExistsById(updateCustomerDto.CustomerID);
                if (!isExist)
                {
                    _logger.LogError("Müşteri yok");
                    return NotFound("Müşteri mevcut değil");
                }
                var customer = _mapper.Map<Customer>(updateCustomerDto);
                _customerService.Update(customer);
                _logger.LogInformation("Müşteri güncellendi Params:{ 0}", JsonSerializer.Serialize(updateCustomerDto));
                return Ok(customer);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Bir hata meydana geldi");
                return StatusCode(500, "Bir hata oluştu daha sonra tekrar deneyin");
            }



        }

    }
}
