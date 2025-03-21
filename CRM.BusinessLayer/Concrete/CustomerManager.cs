using CRM.BusinessLayer.Abstract;
using CRMSystem.DataAccessLayer.Abstract;
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

        public void TAdd(Customer entity)
        {
            _customerDal.Add(entity);
        }

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public Customer TGetByID(int id)
        {
           return _customerDal.GetByID(id);
        }

        public List<Customer> TGetListAll()
        {
            return _customerDal.GetListAll();
        }

        public void TUpdate(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}
