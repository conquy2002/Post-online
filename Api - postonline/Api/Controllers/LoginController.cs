using Microsoft.AspNetCore.Mvc;
using Api.Data;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ApiContext _context;

        public LoginController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public Object GetLoginToken(string user)
        {
            var checkLogin =  _context.User.FirstOrDefault(u => u.Token == user);
            if (checkLogin == null)
            {
                return new { Status = "Error", Message = "login fail." };
            }
            else
            {
                return new { Status = "Success", Message = checkLogin.Id };
            }
        }
    }
}
