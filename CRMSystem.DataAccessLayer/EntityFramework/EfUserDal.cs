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
    public class EfUserDal : GenericRepository<User>, IUserDal
    {
        public EfUserDal(CRMSystemContext context) : base(context)
        {
        }
    }
}
