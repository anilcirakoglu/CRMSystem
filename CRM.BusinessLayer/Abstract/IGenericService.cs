using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Abstract
{
    public interface IGenericService<T>where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T? GetById(int id);
        List<T> GetList();
    }
}
