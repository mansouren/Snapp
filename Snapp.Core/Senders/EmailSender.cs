using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Snapp.Core.Senders
{
    public static class EmailSender
    {
        public static void Send(string to,string subject,string body)
        {
            var myMail = "";
            var password = "";
            var mail = new MailMessage();
            mail.From = new MailAddress(myMail, "اسنپ");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            var smtpserver = new SmtpClient();
            smtpserver.Port = 0;
            smtpserver.Credentials = new NetworkCredential(myMail, password);
            smtpserver.EnableSsl = false;
            smtpserver.Send(mail);
        }
    }
}
