using AutoMapper;
using DatingAPP;
using Repository.Interface;
using Repository.UnitOfWork;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitOfWork
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {

        private IReposiotryUnitOfWork _reposiotryUnitOfWork;

        private IAuthServices _authServices;
        private IMapper _mapper;
        public Lazy<IUserService> user { get; set; }
        

        public ServiceUnitOfWork(mkContext context,IAuthServices authServices)
        {
            _authServices = authServices;
            _reposiotryUnitOfWork =new ReposiotryUnitOfWork(context);
            user = new Lazy<IUserService>(()=>new UserService(_reposiotryUnitOfWork, _authServices, _mapper));
        }

        

        public void Dispose()
        {
        _reposiotryUnitOfWork.Dispose();
        }
    }
}
