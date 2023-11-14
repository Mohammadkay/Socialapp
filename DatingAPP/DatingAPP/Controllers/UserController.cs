using AutoMapper;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Services;

namespace DatingAPP.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class UserController : ControllerBase
    {
        private  IServiceUnitOfWork _serviceUnitOfWork;
        private IAuthServices _authServices;
        private IMapper _mapper;
        public UserController(IServiceUnitOfWork serviceUnitOfWork,IMapper mapper)
        {

            _serviceUnitOfWork = serviceUnitOfWork;
            _mapper = mapper;

        }
        [HttpPost("Register")]
        public ActionResult Register(RegisterDto e)
        {
            using (_serviceUnitOfWork)
                return _serviceUnitOfWork.user.Value.Register(e);
        }
        [HttpPost("Login")]

        public ActionResult<AuthDto> Login(LoginDto user)
        {
            using (_serviceUnitOfWork)
                return _serviceUnitOfWork.user.Value.Login(user);

        }

        //[HttpGet]
        //public ActionResult<IQueryable<User>> GetAllUsers()
        //{
        //    using (_serviceUnitOfWork)
        //        return _serviceUnitOfWork.user.Value.GetAll();
        //}

        [HttpGet]
        

        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAllUsers()
        {
            using (_serviceUnitOfWork)
                return await _serviceUnitOfWork.user.Value.GetAllUsers();
        }

        [HttpGet("{id}")]
       

        public async Task<ActionResult<MemberDto>> GetUsersById(int id)
        {
            using (_serviceUnitOfWork)
                return await _serviceUnitOfWork.user.Value.GetUsserbyId(id);
        }
        
        [HttpGet("GetByUserName/{UserName}")]
        public async Task<ActionResult<MemberDto>> GetByUserName(string UserName)
        {
            using (_serviceUnitOfWork)
                return await _serviceUnitOfWork.user.Value.GetbyUserName(UserName);
        }
    }
}
