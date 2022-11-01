using System;
using System.Net;
using System.Net.Mail;

namespace Kurdi.CleanCode.EmailService
{
    public static class GMail
    {
        public static void SendMail(string message, string subject, string mail)
        {
            using (MailMessage maill = new MailMessage())
            {
                maill.From = new MailAddress("sheriff.elwany@gmail.com");
                maill.To.Add(mail);
                maill.Subject = subject;
                maill.Body = message;
                maill.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("sheriff.elwany@gmail.com", "tifa.011516");
                    smtp.EnableSsl = true;
                    smtp.Send(maill);
                }
            }

        }
    }
}
