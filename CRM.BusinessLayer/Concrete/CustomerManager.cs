using CRM.BusinessLayer.Abstract;
using CRMSystem.DataAccessLayer.Abstract;
using CRMSystem.DtoLayer.CustomerDto;
using CRMSystem.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Create(Customer entity)
        {
           _customerDal.Add(entity);
        }

        public void Delete(Customer entity)
        {
           _customerDal.Delete(entity);
        }

        public Customer? GetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public List<Customer> GetList()
        {
            return _customerDal.GetListAll();
        }

        public bool IsExistsById(int id)
        {
           return _customerDal.IsExistsById(id);
        }

        public List<Customer> SearchCustomer(string customer)
        {
            return _customerDal.SearchCustomer(customer);
        }

        public List<Customer> SearchCustomerByRegion(string region)
        {
           return _customerDal.SearchCustomerByRegion(region);
        }

        public void Update(Customer entity)
        {
            if (entity != null)
            {
                var customerToUpdate = _customerDal.GetById(entity.CustomerID);
                if (customerToUpdate != null)
                {
                    customerToUpdate.FirstName = entity.FirstName;
                    customerToUpdate.LastName = entity.LastName;
                    customerToUpdate.Email = entity.Email;
                    customerToUpdate.Region = entity.Region;

                    _customerDal.Update(customerToUpdate);
                }
            }
        }
    }
}
