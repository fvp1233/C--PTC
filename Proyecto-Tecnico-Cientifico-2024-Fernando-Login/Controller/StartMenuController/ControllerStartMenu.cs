using PTC2024.Controller.Helper;
using PTC2024.View.Clientes;
using PTC2024.View.Empleados;
using PTC2024.View.Facturacion;
using PTC2024.View.formularios.inicio;
using PTC2024.View.InventarioServicios;
using PTC2024.View.Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.View.login;
using PTC2024.formularios.login;
using PTC2024.View.Dashboard;
using PTC2024.View.EmployeeViews;
using PTC2024.View.ProfileSettings;
using System.IO;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using PTC2024.Model.DAO.StartMenuDAO;
using PTC2024.Controller.ProfileController;
using PTC2024.Model.DAO.ProfileDAO;

namespace PTC2024.Controller.StartMenuController
{

    internal class ControllerStartMenu
    {
        StartMenu objStartMenu;
        Form currentForm;
        public ControllerStartMenu(StartMenu View, string username) 
        {
            objStartMenu = View;
            View.Load += new EventHandler(LoadDefaultForm);
            View.Load += new EventHandler(InitialAccess);
            objStartMenu.btnIcon.Click += new EventHandler(LoadProfileSettings);
            objStartMenu.btnMenuDashboard.Click += new EventHandler(LoadDashboard);
            objStartMenu.btnMenuEmployee.Click += new EventHandler(LoadEmployeeForm);
            objStartMenu.btnMenuPayroll.Click += new EventHandler(LoadPayrollForm);
            objStartMenu.btnpermissions.Click += new EventHandler(LoadPermissionsForm);
            objStartMenu.btnMenuServices.Click += new EventHandler(LoadServiceForm);
            objStartMenu.btnMenuCustomers.Click += new EventHandler(LoadCustomersForm);
            objStartMenu.btnMenuBills.Click += new EventHandler(LoadBillsForm);
            objStartMenu.btnMaintenance.Click += new EventHandler(LoadMaintenance);
            objStartMenu.btnLogOut.Click += new EventHandler(LogOut);
            objStartMenu.FormClosing += new FormClosingEventHandler(CloseProgram);
            
        }
        void InitialAccess(object sender, EventArgs e)
        {
            Access();
            objStartMenu.lblUser.Text = SessionVar.Username;
            objStartMenu.btnIcon.Image = ByteArrayToImage(SessionVar.ProfilePic);
            DAOStartMenu daoStart = new DAOStartMenu();
            bool chargeB = daoStart.ChargeInfoBusiness();
            if(chargeB == true)
            {
                objStartMenu.snackBar.Show(objStartMenu, $"Datos del negocio cargados con éxito.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
            }
            ShowWelcomeSnackBar();
        }
        public Image ByteArrayToImage(byte[] byteArray)
        {
            Image imageDefaul = objStartMenu.btnIcon.Image;
            if (byteArray == null || byteArray.Length == 0)
            {             
                //En caso de que el valor de la imagen sea null(como viene por defecto, se retorna el btnIcon)
                return imageDefaul; 
            }
            MemoryStream ms = new MemoryStream(byteArray);
            return Image.FromStream(ms);
        }

        public void ShowWelcomeSnackBar()
        {
            FrmWelcome objWelcome = new FrmWelcome();
            objStartMenu.snackBar.Show(objStartMenu, $"Sesión iniciada con éxito, bienvenido {SessionVar.Username}.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
        }

        public void Access()
        {
            switch (SessionVar.Access)
            {
                case "CEO":
                break;
                case "Administrador":
                    objStartMenu.btnMaintenance.Visible = false;
                    break;
                case "Empleado":
                    objStartMenu.btnMenuEmployee.Visible = false;
                    objStartMenu.btnMenuPayroll.Visible = false;
                    objStartMenu.btnMenuServices.Visible = false;
                    objStartMenu.btnMaintenance.Visible = false;
                    objStartMenu.btnpermissions.Visible = false;
                    objStartMenu.btnMenuDashboard.Visible = false;
                    break;
            }
        }

        private void LoadProfileSettings(object sender, EventArgs e)
        {
            FrmProfile obj = new FrmProfile();
            DAOProfile dAOProfile = new DAOProfile();
            dAOProfile.Username = SessionVar.Username;
            dAOProfile.GetEmployeeData();
            OpenForm<FrmProfile>();
        }
        private void LoadDefaultForm(object sender, EventArgs e)
        {
            OpenForm<FrmWelcome>();           
        }
        private void LoadDashboard(object sender, EventArgs e)
        {
            OpenForm<FrmDashboard>();
        }
        private void LoadEmployeeForm(object sender, EventArgs e)
        {
            OpenForm<FrmEmployees>();
        }
        private void LoadPayrollForm(object sender, EventArgs e)
        {
            OpenForm<FrmViewPayrolls>();
        }
        private void LoadPermissionsForm(object sender, EventArgs e)
        {
            OpenForm<FrmPermissions>();
        }
        private void LoadServiceForm(object sender, EventArgs e)
        {
            OpenForm<FrmServices>();
        }
        private void LoadCustomersForm(object sender, EventArgs e)
        {
            OpenForm<FrmCustomers>();
        }
        private void LoadBillsForm(object sender, EventArgs e)
        {
            OpenForm<FrmBills>();
        }
        private void LoadMaintenance(object sender, EventArgs e)
        {
            OpenForm<FrmMaintenance>();
        }
        /// <summary>
        /// Metodo para abrir formularios dentro del panel contenedor del formulario principal
        /// </summary>
        /// <typeparam name="MyForm"></typeparam>
        private void OpenForm<MyForm>()where MyForm : Form,new()
        {
            //Se declara objeto de tipo form llamado formulario 
            Form form;
            //Se guarda en el panel contenedor del formulario principal todos los controles del formulario que se desea abrir <MyForm> posteriormente se guarda todo en el objeto de tipo formulario
            form = objStartMenu.ContainerPanel.Controls.OfType<MyForm>().FirstOrDefault();
            if (form == null)
            {
                //Deginimos un nuevo formulario para que se guarde como nuevo objeto MyForm
                form = new MyForm();
                //Especificamos que el formulario debe mostrarse como ventana
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                if(currentForm!=null)
                {
                    //Se cierra el formulario actural para mostrar el nuevo formulario
                    currentForm.Close();
                    //Se eliminan del panel contenedor todos los controles del formulario que se cerrará
                    objStartMenu.ContainerPanel.Controls.Remove(currentForm);
                }
                //Se establece como nuevo formulario actual el formulario que se esta abriendo
                currentForm = form;
                //Agregamos los controles del nuevo formulario al panel contenedor
                objStartMenu.ContainerPanel.Controls.Add(form);
                objStartMenu.ContainerPanel.Tag = form;
                form.Show();
                form.BringToFront();
            }
            else
            {
                form.BringToFront();
            }

        }

        async public void LogOut(object sender, EventArgs e)
        {
            
            DAOStartMenu daoS = new DAOStartMenu();
            if (MessageBox.Show("¿Quiere cerrar la sesión?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await Task.Delay(1000);
                ClearVarSession();
                objStartMenu.Hide();
                DeleteLocalToken();
                daoS.Username = SessionVar.Username;
                daoS.DeleteUserToken();
                FrmLogin backToLogin = new FrmLogin();
                backToLogin.Show();
                objStartMenu.snackBar.Show(backToLogin, "La sesión se cerró con éxito.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
            }
        }    

        public void ClearVarSession()
        {
            SessionVar.Username = string.Empty;
            SessionVar.Password = string.Empty;
            SessionVar.FullName = string.Empty;
            SessionVar.Access = string.Empty;
            SessionVar.IdBussinesP = 0;
        }
        
        public void CloseProgram(Object sender, FormClosingEventArgs e)
        {
            //objeto del dao
            DAOStartMenu daoStart = new DAOStartMenu();
            //verificamos si existe un token local
            string savedToken = Properties.Settings.Default.Token;
            if (!string.IsNullOrEmpty(savedToken))
            {
                //Si existe un token, vamos a pasar a comprobar que ese token sea el mismo del usuario que tiene la sesión abierta
                //damos valor a los getters
                daoStart.Username = SessionVar.Username;
                daoStart.Token = savedToken;
                daoStart.CurrentDate = DateTime.Now;
                bool answer = daoStart.CompararToken();
                if (answer == true)
                {
                    //si la respuesta es true, el token local si pertenece al usuario y no ha expirado, por lo que solo damos un aviso al usuario
                    if (MessageBox.Show("¿Desea cerrar el programa? \nSu sesión permanecerá abierta ya que usted pidió que se recordaran sus credenciales.", "Cerar programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    //Si la respuesta es false, significa que el token local no pertenece al usuario con la sesión abierta
                    //ejecutamos todo con normalidad
                    if (MessageBox.Show("¿Desea cerrar el programa? \nLa sesión se cerrará automáticamente", "Cerar programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                //Si no existe un token entonces todo se ejecuta con normalidad
                if (MessageBox.Show("¿Desea cerrar el programa? \nLa sesión se cerrará automáticamente", "Cerar programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            
        }

        public void DeleteLocalToken()
        {
            //eliminamos el token local
            Properties.Settings.Default.Token = string.Empty;
            Properties.Settings.Default.Save();
        }
       
    }
}
