using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Net.Mail;
using System.Web;

using StoneMarket.Core.Interfaces;
using StoneMarket.Core.Services;

using StoneMarket.AccessLayer.Entity;

//using Kavenegar;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StoneMarket.Core.Classes
{    
    public class MessageSender
    {
        private IAdmin _admin;

        AuthorizationFilterContext context;

        public void SMS(string to, string body)
        {
            _admin = (IAdmin)context.HttpContext.RequestServices.GetService(typeof(IAdmin));

            Setting setting = _admin.GetSetting();

            var sender = setting.SmsSender;
            var receptor = to;
            var message = body;
            //var api = new KavenegarApi(setting.SmsApi);

            //api.Send(sender, receptor, message);
        }

        public void Email(string to, string subject, string body)
        {
            _admin = (IAdmin)context.HttpContext.RequestServices.GetService(typeof(IAdmin));

            Setting setting = _admin.GetSetting();

            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(to, "دیجی کالا"));
                message.From = new MailAddress(setting.MailAddress, "دیجی کالا");

                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.UseDefaultCredentials = false;
                    client.Port = 587;
                    client.Credentials = new NetworkCredential(setting.MailAddress, setting.MailPassword);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }
    }
}
