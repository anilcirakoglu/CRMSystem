using CRMSystem.DtoLayer.CustomerDto;
using CRMSystem.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Abstract
{
    public interface ICustomerService:IGenericService<Customer>
    {
        bool IsExistsById(int id);
        List<Customer> SearchCustomer(string customer);
        List<Customer> SearchCustomerByRegion(string region);
    }
}
