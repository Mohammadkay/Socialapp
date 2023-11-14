using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IService<T>
    {
        ActionResult<IQueryable<T>> GetAll();


        ActionResult<T> GetById(int Id);
        ActionResult Delete(T entity);

        ActionResult UpdateById(T entity);
        ActionResult Add(T entity);
        ActionResult AddRange(IEnumerable<T> entities);
        ActionResult DeleteRange(IEnumerable<T> entities);
    }
}
