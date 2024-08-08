using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace PTC2024.Controller.Helper
{
    internal class Email
    {
        //Se crea una instancia del SmtpClient
        public SmtpClient Client = new SmtpClient();
        public MailMessage msg = new MailMessage();
        public NetworkCredential creds = new NetworkCredential("h2c.soporte.usuarios@gmail.com", "uqtl fozz ttgg gzee");
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

                //
                Client.Send(msg);

                MessageBox.Show("El correo fue enviado con éxito", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error enviando el email. \n Error: {ex.Message}", "Error");
            }
        }
    }
}
