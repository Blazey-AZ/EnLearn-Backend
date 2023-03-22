using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace backend.Smtp
{
    public class MailerManager
    {
        public static readonly NetworkCredential credential = new NetworkCredential(){
            UserName = "nakulskumar1998@gmail.com",
            Password = "imgeylotvcltrqal",
        };


        public static async Task<bool> SendMail(string toUser, string subject, string body){
                
            MailMessage message = new MailMessage("nakulskumar1998@gmail.com", toUser, subject, body);
            message.IsBodyHtml = true;

            using(SmtpClient client = new SmtpClient("smtp.gmail.com", 587){
                UseDefaultCredentials = false,
                Credentials = credential,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            } ){
                await client.SendMailAsync(message);
            }
            return true;

        }

    }
}