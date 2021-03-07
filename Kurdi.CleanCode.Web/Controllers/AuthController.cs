using Kurdi.CleanCode.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurdi.CleanCode.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        [Route("Auth/ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token)
        {
            await userManager.ConfirmEmailAsync(await userManager.GetUserAsync(User), token);
            ViewBag.token = token;
            return View();
        }
        [Route("Auth/AccountConfirmation/")]
        [HttpGet]
        public async Task<IActionResult> AccountConfirmation()
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(userManager.GetUserAsync(User).Result);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new {token = token}, Request.Scheme);
            //ViewBag.confirmationLink = confirmationLink;
            
            GMail.SendMail($"confermation Link is {confirmationLink}", "kurdi.cleancode.web mail confirmation", userManager.GetUserAsync(User).Result.Email);
            return View();
        }
        [HttpPost]
        public IActionResult AccountConfirmation(string token)
        {
            return View();
        }

    }
}
