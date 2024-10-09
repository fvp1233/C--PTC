using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.BillsDAO;
using PTC2024.Model.DAO.HelperDAO;
using PTC2024.View.Alerts;
using PTC2024.View.formularios.inicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.Alerts
{
    internal class ControllerConfirmPayment
    {
        FrmConfirmPayment objForm;
        int confirmValue;
        StartMenu objStartMenu;
        public ControllerConfirmPayment(FrmConfirmPayment View)
        {
            objForm = View;
            objForm.HidePassword.Click += new EventHandler(HidePassword);
            objForm.ShowPassword.Click += new EventHandler(ShowPassword);
            objForm.btnConfirm.Click += new EventHandler(ConfirmProcess);
            objForm.btnCancel.Click += new EventHandler(CancelProcess);
        }

        public void CancelProcess(object sender, EventArgs e)
        {
            CancelProcessValue();
            objForm.Close();
        }
        public SecureString ConvertToSecureString(string password)
        {
            SecureString securePassword = new SecureString();
            //Se recorre cada carácter de la contraseña ya ingresada o guardada en la base de datos
            foreach (char c in password.ToCharArray())
            {
                //Se agrega cada caracter a secureString
                securePassword.AppendChar(c);
            }
            //SecureString se establece como solo lectura para que no se pueda modificar después de ser creado
            securePassword.MakeReadOnly();
            // Se devuelve la contraseña en formato SecureString
            return securePassword;
        }
        public void ConfirmProcess(object sender, EventArgs e)
        {
            DAOBills dAOBills = new DAOBills();

            // Convertir la contraseña ingresada a SecureString
            SecureString securePassword = ConvertToSecureString(objForm.txtPassword.Text);

            // Validar la contraseña
            bool validatepassword = dAOBills.VerifyAdminPassword(securePassword);

            if (validatepassword)
            {
                ConfirmProcessValue(); // Establecer confirmación exitosa
                objForm.Close(); // Ocultar formulario
            }
            else
            {
                objForm.Close(); // Cerrar formulario en caso de error
            }
        }
        public void ShowPassword(object sender, EventArgs e)
        {
            objForm.txtPassword.PasswordChar = '\0';
            objForm.ShowPassword.Visible = false;
            objForm.HidePassword.Visible = true;
        }

        public void HidePassword(object sender, EventArgs e)
        {
            objForm.txtPassword.PasswordChar = '*';
            objForm.HidePassword.Visible = false;
            objForm.ShowPassword.Visible = true;
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
