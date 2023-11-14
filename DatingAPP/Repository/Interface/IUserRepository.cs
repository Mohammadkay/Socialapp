using DatingAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository:IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetbyUserName(string userName);
        Task<User> GetUsserbyId(int id);
    }
}
