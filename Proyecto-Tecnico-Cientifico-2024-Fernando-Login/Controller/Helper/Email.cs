using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace PTC2024.Controller.Helper
{
    internal class Email
    {
        public SmtpClient Client = new SmtpClient();
        public MailMessage msg = new MailMessage();
        public System.Net.NetworkCredential creds = new System.Net.NetworkCredential("h2c.soporte.usuarios@gmail.com", "pgcrsydunvshbwih");
        public void Send(string para, string de, string subject, string message)
        {
            try
            {
                Client.Host = "smtp.gmail.com";
                Client.EnableSsl = true;
                Client.Port = 587;
                Client.Credentials = creds;

                MailAddress to = new MailAddress(para);
                MailAddress from = new MailAddress(de);
                msg.Subject = subject;
                msg.Body = message;
                msg.From = from;
                msg.To.Add(to);

            }
            catch (Exception e)
            {

                throw(e);
            }
        }
    }
}
