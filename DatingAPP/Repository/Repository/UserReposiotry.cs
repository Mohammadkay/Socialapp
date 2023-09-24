using DatingAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;
namespace Repository.Repository
{
    public class UserReposiotry : Repository<User>, IUserRepository
    {
        private mkContext _context;
        public UserReposiotry(mkContext context) : base(context)
        {
            _context = context;
        }

        public User FindEmail(string email)
        {
          return  _context.Users.Where(x=>x.Email==email).SingleOrDefault();
        }
    }
}
