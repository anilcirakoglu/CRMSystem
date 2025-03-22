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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Create(User entity)
        { 
            _userDal.Add(entity);
        }

        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public User GetById(int id)
        {
          return _userDal.GetById(id);
        }

        public List<User> GetList()
        {
            return _userDal.GetListAll();
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }
    }
}
