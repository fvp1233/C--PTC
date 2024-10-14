using PTC2024.Controller.Helper;
using PTC2024.View.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.Server
{
    internal class ControllerCEOPassword
    {
        FrmConfirmPassword objPassword;
        public ControllerCEOPassword(FrmConfirmPassword View)
        {
            objPassword = View;
            objPassword.MaximizeBox = false;
            objPassword.Load += new EventHandler(InitialCharge);
            objPassword.HidePassword.Click += new EventHandler(HidePassword);
            objPassword.ShowPassword.Click += new EventHandler(ShowPassword);
            objPassword.btnConfirm.Click += new EventHandler(VerifyEvent);
            objPassword.txtPassword.MouseDown += new MouseEventHandler(DisableContextMenu);
        }
        public void VerifyEvent(object sender, EventArgs e)
        {
            VerifyPass();
        }
        public bool VerifyPass()
        {
            CommonClasses common = new CommonClasses();
            string encryptedPass = common.ComputeSha256Hash(objPassword.txtPassword.Text);
            if (!string.IsNullOrEmpty(objPassword.txtPassword.Text))
            {
                if (encryptedPass == SessionVar.Password)
                {
                    FrmServerConfiguration objOpen = new FrmServerConfiguration(2);
                    objOpen.ShowDialog();
                    objOpen.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Acceso denegado, las credenciales no tienen los permisos suficientes.", "Error al validar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Favor llenar todos los campos", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public void ShowPassword(object sender, EventArgs e)
        {
            objPassword.txtPassword.PasswordChar = '\0';
            objPassword.ShowPassword.Visible = false;
            objPassword.HidePassword.Visible = true;
        }

        public void HidePassword(object sender, EventArgs e)
        {
            objPassword.txtPassword.PasswordChar = '*';
            objPassword.HidePassword.Visible = false;
            objPassword.ShowPassword.Visible = true;
        }
        public void InitialCharge(object sender, EventArgs e)
        {
            objPassword.txtPassword.PasswordChar = '*';
            objPassword.HidePassword.Visible = false;
            
            //Modo oscuro
            if(Properties.Settings.Default.darkMode == true)
            {
                objPassword.BackColor = Color.FromArgb(30, 30, 30);
                objPassword.serverPassNegro.Visible = false;
                objPassword.ServerPassBlanco.Visible = true;
                objPassword.lblText.ForeColor = Color.White;
            }
        }

        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }
    }
}
