using DatingAPP;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Repository<T> : IRepository <T> where T : class
    {
       private  mkContext _context;
        public Repository(mkContext context) {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);  
            save();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            save();

        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            save();

        }

        public void DeleteRange(IEnumerable<T> entities)
        {
           _context.Set<T>().RemoveRange(entities);
            save();

        }

        public IEnumerable<T> GetAll()
        {
           return _context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int Id)
        {
             

            return _context.Set<T>().Find(Id);

        }

      

        public void UpdateById(T entity)
        {
            _context.Set<T>().Update(entity);
            save();
        }
        public void save()
        {
            _context.SaveChanges();
        }

    }
}
