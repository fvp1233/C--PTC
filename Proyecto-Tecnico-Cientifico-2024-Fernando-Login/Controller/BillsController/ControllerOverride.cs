using PTC2024.Controller.Helper;
using PTC2024.Model;
using PTC2024.Model.DAO.BillsDAO;
using PTC2024.Model.DAO.HelperDAO;
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
        StartMenu objStartMenu;
        //CONSTRUCTOR DEL FORMULARIO
        public ControllerOverride(FrmOverrideBill View)
        {
            objoverrideBill = View;
            //Eventos para los clicks de los botones
            objoverrideBill.btnback.Click += new EventHandler(CancelProcess);
            objoverrideBill.btnConfirm.Click += new EventHandler(ConfirmProcess);
            objoverrideBill.ShowPassword.Click += new EventHandler(ShowPassword);
            objoverrideBill.txtPasswordBunifu.Click += new EventHandler(HidePassword);
            objoverrideBill.txtPasswordBunifu.MouseDown += new MouseEventHandler(DisableContextMenu);

        }
        /// <summary>
        /// Métodos de los eventos del formulario para anular las facturas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CancelProcess(object sender, EventArgs e)
        {
            CancelProcessValue();
            objoverrideBill.Close();
        }
        /// <summary>
        /// Método que convierte una cadena de texto string en un secureString el cual logra de manera más segura almacenar las contraseñas en la memoria
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Método de confirmación de un proceso, validando la contraseña del administrador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                objoverrideBill.Close(); // Ocultar formulario
                DAOInitialView daoInitial = new DAOInitialView();
                daoInitial.ActionType = "Se rectificó una factura";
                daoInitial.TableName = "Facturas";
                daoInitial.ActionBy = SessionVar.Username;
                daoInitial.ActionDate = DateTime.Now;
                int auditAnswer = daoInitial.InsertAudit();
                if (auditAnswer != 1)
                {
                    objStartMenu.snackBar.Show(objStartMenu, $"La auditoria no pudo ser registrada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                }
            }
            else
            {
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
