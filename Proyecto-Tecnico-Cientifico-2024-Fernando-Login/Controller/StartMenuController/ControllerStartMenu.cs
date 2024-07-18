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

namespace PTC2024.Controller.StartMenuController
{

    internal class ControllerStartMenu
    {
        StartMenu objStartMenu;
        Form currentForm;
        public ControllerStartMenu(StartMenu View) 
        {
            objStartMenu = View;
            View.Load += new EventHandler(LoadDefaultForm);
            objStartMenu.btnMenuDashboard.Click += new EventHandler(LoadDefaultForm);
            objStartMenu.btnMenuEmployee.Click += new EventHandler(LoadEmployeeForm);
            objStartMenu.btnMenuPayroll.Click += new EventHandler(LoadPayrollForm);
            objStartMenu.btnMenuServices.Click += new EventHandler(LoadServiceForm);
            objStartMenu.btnMenuCustomers.Click += new EventHandler(LoadCustomersForm);
            objStartMenu.btnMenuBills.Click += new EventHandler(LoadBillsForm);
        }    

        private void LoadDefaultForm(object sender, EventArgs e)
        {
            OpenForm<FrmWelcome>();
        }
        private void LoadEmployeeForm(object sender, EventArgs e)
        {
            OpenForm<FrmEmployees>();
        }
        private void LoadPayrollForm(object sender, EventArgs e)
        {
            OpenForm<FrmViewPayrolls>();
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
    }
}
