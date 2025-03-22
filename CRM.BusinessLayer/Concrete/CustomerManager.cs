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

        public void Update(Customer entity)
        {
           _customerDal.Update(entity);
        }
    }
}
