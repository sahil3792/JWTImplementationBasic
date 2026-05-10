using BusinessAccessLayer.IBAL;
using JWTImplementation.Model.Login;
using Microsoft.AspNetCore.Mvc;

namespace JWTImplementation.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginBAL _IloginBal;
        public LoginController(ILoginBAL loginbal) => 
            _IloginBal = loginbal;
            
        [HttpPost]
        [Route("login")]
        public dynamic Login([FromBody] ReqLoginModel Loginmodel)
        {
            
            return _IloginBal.Validate(Loginmodel.UserName, Loginmodel.Password); ;
        }
    }
}
