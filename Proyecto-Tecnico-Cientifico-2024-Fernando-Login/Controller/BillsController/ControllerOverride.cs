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
            //Evento que verifica que la contraseña es correcta o no
            objoverrideBill.btnConfirm.Click += new EventHandler(VerifyEvent);
            //Evento que muestra la contraseña
            objoverrideBill.ShowPassword.Click += new EventHandler(ShowPassword);
            //Evento que desahabilita para mostrar contraseña
            objoverrideBill.txtPasswordBunifu.Click += new EventHandler(HidePassword);
            //Evento que deshabilita el menu context del textbox
            objoverrideBill.txtPasswordBunifu.MouseDown += new MouseEventHandler(DisableContextMenu);

        }
        
    public void VerifyEvent(object sender, EventArgs e)
    {
        VerifyPass();
    }
        //Verifica la contraseña
    public bool VerifyPass()
    {
            //Muestra el objeto de la clase common
        CommonClasses common = new CommonClasses();
            //Verifica que la contraseña sea una previamente incriptada
        string encryptedPass = common.ComputeSha256Hash(objoverrideBill.txtPasswordBunifu.Text);
        if (!string.IsNullOrEmpty(objoverrideBill.txtPasswordBunifu.Text))
        {
                //Cuando se incripte la contraseña ejecuta el proceso
            if (encryptedPass == SessionVar.Password)
            {
                    ConfirmProcessValue(); // Establecer confirmación exitosa
                    objoverrideBill.Close(); // Ocultar formulario
                    //Muestra el objeto de la clase de DAOInitialView
                    DAOInitialView daoInitial = new DAOInitialView();
                    //Muestra mensaje de confirmación luego que la contraseña este incriptada
                    daoInitial.ActionType = "Se rectificó una factura";
                    daoInitial.TableName = "Facturas";
                    daoInitial.ActionBy = SessionVar.Username;
                    daoInitial.ActionDate = DateTime.Now;
                    //Esto sirve para ingresar la auditoria respectiva de la anulación de facturas
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
                return true;
        }
        else
        {
            MessageBox.Show("Favor llenar todos los campos", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
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
