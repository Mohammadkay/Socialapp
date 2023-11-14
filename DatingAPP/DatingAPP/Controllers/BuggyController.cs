using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace DatingAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private IServiceUnitOfWork _serviceUnitOfWork;
        private mkContext _context;
        public BuggyController(IServiceUnitOfWork serviceUnitOfWork, mkContext context)
        {
            _serviceUnitOfWork = serviceUnitOfWork;
            _context = context;
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecet()
        {
           
            return "Secret Text";
        }

        [HttpGet("not-found")]
        public ActionResult<User> GetNotFound()
        {
            var v= _context.Users.Find(-1);
            if(v==null) return NotFound();
            return v;
        }


        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
             var v=_context.Users.Find(-1);
            return v.ToString();
        }
        
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
         return BadRequest("This was not a good request");
        }

    }
}
