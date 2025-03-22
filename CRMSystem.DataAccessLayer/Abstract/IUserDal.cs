using CRMSystem.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMSystem.DataAccessLayer.Abstract
{
    public interface IUserDal:IGenericDal<User>
    {
        bool CheckUsernameAndPassword(string username, string password);
    }
}
