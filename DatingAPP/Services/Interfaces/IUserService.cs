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

         ActionResult Register(RegisterDto entity);
         ActionResult<AuthDto> Login(LoginDto entity);

        Task<ActionResult<IEnumerable<MemberDto>>> GetAllUsers();
        Task<ActionResult<MemberDto>> GetbyUserName(string userName);
        Task<ActionResult<MemberDto>> GetUsserbyId(int id);
    }
}
