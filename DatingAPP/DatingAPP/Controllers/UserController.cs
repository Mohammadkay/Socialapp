using Domain.DTOs;
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
        public UserController(IServiceUnitOfWork serviceUnitOfWork)
        {

            _serviceUnitOfWork = serviceUnitOfWork;

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


    }
}
