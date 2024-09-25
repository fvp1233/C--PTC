using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using PTC2024.View.ProfileSettings;
using PTC2024.View.formularios.inicio;

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

        public void SendPasswordChange(string para, string de, string subject, string message)
        {
            FrmChangeUserPass objChangeP = new FrmChangeUserPass();
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

                objChangeP.snack.Show(objChangeP, "Se envío un correo al usuario.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
            }
            catch (Exception ex)
            {
                objChangeP.snack.Show(objChangeP, "Hubo un error enviando el correo.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
            }
        }

        public bool NewEmployee(string para, string de, string subject, string message)
        {
            StartMenu objS = new StartMenu(SessionVar.Username);
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

                objS.snackBar.Show(objS, "Se envío un correo electrónico al email ingresado.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                return true;
            }
            catch (Exception ex)
            {
                objS.snackBar.Show(objS, "Hubo un error enviando el correo.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                return false;
            }
        }

        public bool UpdatedEmail(string para, string de, string subject, string message)
        {
            StartMenu objS = new StartMenu(SessionVar.Username);
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

                
                Client.Send(msg);

                objS.snackBar.Show(objS, "Se envío un correo electrónico al nuevo email.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                return true;
            }
            catch (Exception ex)
            {
                objS.snackBar.Show(objS, "Hubo un error enviando el correo, no se puede actualizar.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                return false;
            }
        }

        public bool CustomerEmail(string para, string de, string subject, string message)
        {
            StartMenu objS = new StartMenu(SessionVar.Username);
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

                objS.snackBar.Show(objS, "Se envío un correo electrónico al email del cliente.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                return true;
            }
            catch (Exception ex)
            {
                objS.snackBar.Show(objS, "No se pudo enviar un correo electrónico al email del cliente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                return false;
            }
        }
        public bool UpdateBusiness(string para, string de, string subject, string message)
        {
            StartMenu objS = new StartMenu(SessionVar.Username);
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

                objS.snackBar.Show(objS, "Se envío un correo electrónico al email ingresado.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                return true;
            }
            catch (Exception ex)
            {
                objS.snackBar.Show(objS, "Hubo un error enviando el correo.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 2000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomLeft);
                return false;
            }
        }
    }
}
