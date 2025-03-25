using CRMSystem.DataAccessLayer.Abstract;
using CRMSystem.DataAccessLayer.Concrete;
using CRMSystem.DataAccessLayer.Repositories;
using CRMSystem.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DataAccessLayer.EntityFramework
{
    public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
    {
        public EfCustomerDal(CRMSystemContext context) : base(context)
        {
        }

        public bool IsExistsById(int id)
        {
          return _context.Set<Customer>().Any(x=>x.CustomerID == id);
        }

        public List<Customer> SearchCustomer(string customer)
        {
            return _context.Set<Customer>()
                     .Where(x => x.FirstName.ToLower().Contains(customer.ToLower())
                              || x.LastName.ToLower().Contains(customer.ToLower())
                              || x.Region.ToLower().Contains(customer.ToLower())
                              ||x.FirstName.StartsWith(customer)
                              ||x.LastName.StartsWith(customer)
                              ||x.Region.StartsWith(customer)).OrderBy(c => c.CustomerID) 
                        .ToList(); 
        }

        public List<Customer> SearchCustomerByRegion(string region)
        {
           return _context.Set<Customer>().Where(x=>x.Region==region).OrderBy(c => c.CustomerID)
                        .ToList();
        }
    }
}
