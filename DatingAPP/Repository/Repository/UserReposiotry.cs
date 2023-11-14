using DatingAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class UserReposiotry : Repository<User>, IUserRepository
    {
        private mkContext _context;
        public UserReposiotry(mkContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.Include(p=>p.Photos).ToListAsync();
        }

        public async Task<User> GetbyUserName(string userName)
        {
           return await _context.Users.Include(p => p.Photos).SingleOrDefaultAsync(p => p.UserName == userName);
        }

        public async Task<User> GetUsserbyId(int id)
        {
         return  await _context.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
