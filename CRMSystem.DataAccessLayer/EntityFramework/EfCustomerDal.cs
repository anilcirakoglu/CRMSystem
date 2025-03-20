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
    }
}
