using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurdi.CleanCode.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("signIn")]
        public IActionResult SignIn([FromForm]  String userName, [FromForm] String password)
        {
            return Ok();
        }

        [HttpPost]
        [Route("signUp")]
        public IActionResult SignUp()
        {
            return Ok();
        }
    }
}
