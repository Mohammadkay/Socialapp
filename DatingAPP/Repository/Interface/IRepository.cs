using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T> where T : class
    {
     
       
        IEnumerable<T> GetAll();
        T GetById(int Id);

        void Delete(T entity);

        void UpdateById(T entity);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void DeleteRange(IEnumerable<T> entities);
        void save();


    }
}
