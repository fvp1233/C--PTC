using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DAO.CustomersDAO;
using PTC2024.View.Clientes;
using PTC2024.Controller.Helper;
using System.Windows.Forms;
using PTC2024.Model.DTO.CustomersDTO;

namespace PTC2024.Controller.CustomersController
{
    class ControllerAddCustomers
    {
        FrmAddCustomers objAddCustomers;
        private int accion;
        private int tipoC;

        public ControllerAddCustomers (FrmAddCustomers Vista, int accion)
        {
            objAddCustomers = Vista;
            this.accion = accion;
            VerificarAccion();
            objAddCustomers.Load += new EventHandler(CargarCombos);
            objAddCustomers.BtnAgregarCliente.Click += new EventHandler(AgregarCliente);
            objAddCustomers.BtnCancelar.Click += new EventHandler(CancelarProceso);
        }

        public ControllerAddCustomers( FrmAddCustomers VIEW, int p_accion, int IdCustomer,  int DUI, string names,  string lastNames, string phone, string email, string address, int IdtypeC) 
        {
            this.accion = p_accion;
           
            
            //Metodos cuando se inicia el formulario
            objAddCustomers = VIEW;
            objAddCustomers.Load += new EventHandler(CargarCombos);
            VerificarAccion();
            //Metodos cuando se ejecuta un evento
            objAddCustomers.BtnAgregarCliente.Click += new EventHandler(updateCustomers);
            objAddCustomers.BtnCancelar.Click += new EventHandler(CancelarProceso);
            

        }
        public void VerificarAccion()
        {
            if (accion == 1)
            {
                objAddCustomers.BtnAgregarCliente.Enabled = true;
                objAddCustomers.btnActualizar.Enabled = false;



            }

            if (accion == 2)
            {
                objAddCustomers.BtnAgregarCliente.Enabled = false;
                objAddCustomers.btnActualizar.Enabled = true;
            }
        }

        public void CargarCombos (object sender, EventArgs e)
        { 
        DAOAddCustomers dAOAddCustomers = new DAOAddCustomers();


            DataSet dsTipodeCliente  = dAOAddCustomers.ObtenerTiposEmpleado();
            objAddCustomers.comboTipodeCliente.DataSource = dsTipodeCliente.Tables["tbTypeC"];
            objAddCustomers.comboTipodeCliente.DisplayMember = "customerType";
            objAddCustomers.comboTipodeCliente.ValueMember = "IdTypeC";


        }

        public void AgregarCliente (object sender, EventArgs e)
        {

            if (!(string.IsNullOrEmpty(objAddCustomers.txtNombres.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtApellidos.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtDui.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtDireccion.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtEmail.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.txtTelefono.Text.Trim()) ||
                string.IsNullOrEmpty(objAddCustomers.comboTipodeCliente.Text.Trim()) 
                ))
            {

                DAOAddCustomers dAOAddCustomers = new DAOAddCustomers();
                CommonClasses commonClasses = new CommonClasses();

               
                dAOAddCustomers.Names = objAddCustomers.txtNombres.Text;
                dAOAddCustomers.Lastnames = objAddCustomers.txtApellidos.Text;
                dAOAddCustomers.DUI1 = objAddCustomers.txtDui.Text;

                dAOAddCustomers.Address = objAddCustomers.txtDireccion.Text;
                dAOAddCustomers.Email = objAddCustomers.txtEmail.Text;
                dAOAddCustomers.Phone = objAddCustomers.txtTelefono.Text;
                dAOAddCustomers.IdCustomer = int.Parse(objAddCustomers.comboTipodeCliente.SelectedValue.ToString());

                int valorRespuesta = dAOAddCustomers.RegisterCustomer();

                if (valorRespuesta == 1)
                {
                    MessageBox.Show("Los datos se registraron de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objAddCustomers.Close();
                }
                else
                {
                    MessageBox.Show("Los datos no pudieron ser registrados", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios y existen algunos vacíos, llene todos los apartados.",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
            
        }

        public void updateCustomers(object sender , EventArgs e)
        {
            DAOAddCustomers daoUpdateCustomers = new DAOAddCustomers();
            daoUpdateCustomers.Names = objAddCustomers.txtNombres.Text.Trim();
            daoUpdateCustomers.Lastnames = objAddCustomers.txtApellidos.Text.Trim();
            daoUpdateCustomers.DUI1 = objAddCustomers.txtDui.Text.Trim();
            daoUpdateCustomers.Address = objAddCustomers.txtDireccion.Text.Trim();
            daoUpdateCustomers.Email = objAddCustomers.txtEmail.Text.Trim();
            daoUpdateCustomers.Phone = objAddCustomers.txtTelefono.Text.Trim();
            daoUpdateCustomers.IdCustomer = int.Parse(objAddCustomers.comboTipodeCliente.SelectedValue.ToString());
            int valorRetornado = daoUpdateCustomers.UpdateCustomers(); 

        }
        public void CancelarProceso(object sender, EventArgs e)
        {
            objAddCustomers.Close();
        }


    }

}
                
        
