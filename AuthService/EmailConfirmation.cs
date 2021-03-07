using Kurdi.CleanCode.EmailService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Kurdi.CleanCode.AuthService
{
    public static class EmailConfirmation
    {

   
        //TODO: send email, check, confirm
        public async static void SendConfirmationToken(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IdentityUser user)
        {
            // generate token send mail.
            var confToken  = await userManager.GenerateEmailConfirmationTokenAsync(user);
            //send mail.
            GMail.SendMail($"this is your confirmation token {confToken}","Confirm Email", user.Email);
        }

        public async static Task<IdentityResult> Confirm(UserManager<IdentityUser> userManager, IdentityUser user, string token)
        {
            return await userManager.ConfirmEmailAsync(user, token);
        }
    }
}
