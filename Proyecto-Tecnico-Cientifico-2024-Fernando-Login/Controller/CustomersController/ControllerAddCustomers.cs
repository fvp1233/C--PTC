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


        public ControllerAddCustomers (FrmAddCustomers Vista)
        {
            objAddCustomers = Vista;
            
           // VerificarAccion();
            objAddCustomers.Load += new EventHandler(CargarCombos);
            objAddCustomers.BtnAgregarCliente.Click += new EventHandler(AgregarCliente);
            objAddCustomers.BtnCancelar.Click += new EventHandler(CancelarProceso);
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
            //validaciones para que no queden en blanco
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
                dAOAddCustomers.EmployeeType = int.Parse(objAddCustomers.comboTipodeCliente.SelectedValue.ToString());
                

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

        
        public void CancelarProceso(object sender, EventArgs e)
        {
            objAddCustomers.Close();
        }


    }

}
                
        
