using PTC2024.Controller.Helper;
using PTC2024.Model;
using PTC2024.Model.DAO.BillsDAO;
using PTC2024.Model.DAO.LogInDAO;
using PTC2024.View.Alerts;
using PTC2024.View.BillsViews;
using PTC2024.View.Facturacion;
using PTC2024.View.formularios.inicio;
using PTC2024.View.Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.BillsController
{
    internal class ControllerOverride
    {

        FrmOverrideBill objoverrideBill;
        int confirmValue;
        //CONSTRUCTOR DEL FORMULARIO
        public ControllerOverride(FrmOverrideBill View)
        {
            objoverrideBill = View;
            //Eventos para los clicks de los botones
            objoverrideBill.btnback.Click += new EventHandler(CancelProcess);
            objoverrideBill.btnConfirm.Click += new EventHandler(ConfirmProcess);
            objoverrideBill.ShowPassword.Click += new EventHandler(ShowPassword);
            objoverrideBill.txtPasswordBunifu.Click += new EventHandler(HidePassword);

        }

        public void CancelProcess(object sender, EventArgs e)
        {
            CancelProcessValue();
            objoverrideBill.Close();
        }

        public SecureString ConvertToSecureString(string password)
        {
            SecureString securePassword = new SecureString();
            foreach (char c in password.ToCharArray())
            {
                securePassword.AppendChar(c);
            }
            securePassword.MakeReadOnly();
            return securePassword;
        }
        public void ConfirmProcess(object sender, EventArgs e)
        {
            DAOBills dAOBills = new DAOBills();

            // Convertir la contraseña ingresada a SecureString
            SecureString securePassword = ConvertToSecureString(objoverrideBill.txtPasswordBunifu.Text);

            // Validar la contraseña
            bool validatepassword = dAOBills.VerifyAdminPassword(securePassword);

            if (validatepassword)
            {
                ConfirmProcessValue(); // Establecer confirmación exitosa
                MessageBox.Show("Contraseña correcta.", "Proceso Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objoverrideBill.Close(); // Ocultar formulario
            }
            else
            {
                MessageBox.Show("Contraseña de administrador incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                objoverrideBill.Close(); // Cerrar formulario en caso de error
            }
        }


        public void ShowPassword(object sender, EventArgs e)
        {
            objoverrideBill.txtPasswordBunifu.PasswordChar = '\0';
            objoverrideBill.ShowPassword.Visible = false;
            objoverrideBill.HidePassword.Visible = true;
        }

        public void HidePassword(object sender, EventArgs e)
        {
            objoverrideBill.txtPasswordBunifu.PasswordChar = '*';
            objoverrideBill.HidePassword.Visible = false;
            objoverrideBill.ShowPassword.Visible = true;
        }

        public void InitialCharge(object sender, EventArgs e)
        {
            objoverrideBill.txtPasswordBunifu.PasswordChar = '*';
            objoverrideBill.HidePassword.Visible = false;
        }
        public int CancelProcessValue()
        {
            confirmValue = 0;
            return confirmValue;
        }

        public int ConfirmProcessValue()
        {
            confirmValue = 1;
            return confirmValue;
        }

        public int ConfirmValue
        {
            get { return confirmValue; }

        }
    
    

        }
}
