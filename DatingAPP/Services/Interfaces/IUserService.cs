using DatingAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;

namespace Services.Interfaces
{
    public interface IUserService:IService<User>
    {

        public ActionResult Register(RegisterDto entity);
        public ActionResult<AuthDto> Login(LoginDto entity);
    }
}
