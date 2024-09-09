using PTC2024.Controller.Helper;
using PTC2024.View.Server;
using System;
using System.Collections.Generic;
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
            objPassword.Load += new EventHandler(InitialCharge);
            objPassword.HidePassword.Click += new EventHandler(HidePassword);
            objPassword.ShowPassword.Click += new EventHandler(ShowPassword);
            objPassword.btnConfirm.Click += new EventHandler(VerifyPass);
            objPassword.txtPassword.MouseDown += new MouseEventHandler(DisableContextMenu);
        }
        public void VerifyPass(object sender, EventArgs e)
        {
            CommonClasses common = new CommonClasses();
            string encryptedPass = common.ComputeSha256Hash(objPassword.txtPassword.Text);
            if (!string.IsNullOrEmpty(objPassword.txtPassword.Text))
            {
                if (encryptedPass == SessionVar.Password)
                {
                    FrmServerConfiguration objOpen = new FrmServerConfiguration();
                    objOpen.ShowDialog();
                    objOpen.Close();
                }
                else
                {
                    MessageBox.Show("Acceso denegado, las credenciales no tienen los permisos suficientes.", "Error al validar contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Favor llenar todos los campos", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
