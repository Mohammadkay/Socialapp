using DatingAPP;
using Repository.Interface;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class ReposiotryUnitOfWork : IReposiotryUnitOfWork
    {
        private mkContext _context;

        public Lazy<IUserRepository> UserRepository { get; set; }

        public ReposiotryUnitOfWork(mkContext context)
        {
            _context = context;
            UserRepository = new Lazy<IUserRepository>(() => new UserReposiotry(_context));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
