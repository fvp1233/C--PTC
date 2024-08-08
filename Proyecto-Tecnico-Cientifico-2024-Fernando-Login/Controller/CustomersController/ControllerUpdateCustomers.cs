using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< Updated upstream
using PTC2024.View.Clientes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using PTC2024.Model.DAO.EmployeesDAO;
using System.Windows.Forms;
using PTC2024.Model.DAO.CustomersDAO;
using System.Data;
=======
>>>>>>> Stashed changes

namespace PTC2024.Controller.CustomersController
{
    internal class ControllerUpdateCustomers
    {
<<<<<<< Updated upstream

        FrmUploadCustomers objUploadCustomers;
        private string IdTypeC;

        public ControllerUpdateCustomers(FrmUploadCustomers VIEW, int IdCustomer, string DUI, string names, string lastNames, string phone, string email, string address, int IdTypeC)
        {
            objUploadCustomers = VIEW;
            this.IdTypeC = IdTypeC;

            //Métodos del formulario
            ChargeValues(IdCustomer, DUI, names, lastNames, phone, email, address, IdTypeC);
            objUploadCustomers.Load += new EventHandler(ChargeInfo);
            objUploadCustomers.BtnCancelar.Click += new EventHandler(CancelProcess);
            objUploadCustomers.BtnAgregarEmpleado.Click += new EventHandler(UpdateCustomer);

        }
        public void ChargeInfo(object sender, EventArgs e)
        {
            ChargeDropDowns();
        }
        public void CancelProcess(object sender, EventArgs e)
        {
            objUploadCustomers.Close();
        }

        public void UpdateEmployee(object sender, EventArgs e)
        {
            //Verificación de que todos los campos estén llenos
            if (!(string.IsNullOrEmpty(objUploadCustomers.txtNombres.Text.Trim()) ||
                string.IsNullOrEmpty(objUploadCustomers.txtLastNames.Text.Trim()) ||
                string.IsNullOrEmpty(objUploadCustomers.txtDui.Text.Trim()) ||
                string.IsNullOrEmpty(objUploadCustomers.txtDireccion.Text.Trim()) ||
                string.IsNullOrEmpty(objUploadCustomers.txtEmail.Text.Trim()) ||
                string.IsNullOrEmpty(objUploadCustomers.txtTelefono.Text.Trim())
                ))
            {
                //CREAMOS OBJETO DEL DAOUpdateEmployees
                DAOUpdateCustomers daoUpdateCustomer = new DAOUpdateCustomers();
                daoUpdateCustomer.Names = objUploadCustomers.txtNombres.Text.Trim();
                daoUpdateCustomer.LastNames = objUploadCustomers.txtLastNames.Text.Trim();
                daoUpdateCustomer.Dui = objUploadCustomers.txtDui.Text.Trim();
                daoUpdateCustomer.Address = objUploadCustomers.txtEmail.Text.Trim();
                daoUpdateCustomer.Email = objUploadCustomers.txtEmail.Text.Trim();
                daoUpdateCustomer.Phone = objUploadCustomers.txtTelefono.Text.Trim();
                daoUpdateCustomer.TypeC = (int)objUploadCustomers.dpTipoCliente.SelectedValue;

                //variable para saber la respuesta del proceso de update en el DAOUpdateEmployees
                int updateAnswer = daoUpdateCustomer.UpdateCustomers();
                //la evaluamos
                if (updateAnswer == 1)
                {
                    MessageBox.Show("Los datos del empleado han sido actualizados con éxito.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objUploadCustomers.Close();
                }
                else
                {
                    MessageBox.Show("Los datos del empleado no pudieron ser actualizados.", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Existen campos sin llenar.\n Porfavor llene todos los apartados para continuar", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void ChargeDropDowns()
        {
            //creando objeto de la clase DAOAddEmployee
            DAOUpdateCustomers daoUpdateCustomers = new DAOUpdateCustomers();

            //Dropdown de Estados civiles
            DataSet dspTypeC = daoUpdateCustomers.ObtenerTiposC();
            objUploadCustomers.dpTipoCliente.DataSource = dspTypeC.Tables["tbTypeC"];
            objUploadCustomers.dpTipoCliente.DisplayMember = "customerType";
            objUploadCustomers.dpTipoCliente.ValueMember = "IdTypeC";
            //Para que el dropdown tenga seleccionado el dato del registro:
            objUploadCustomers.dpTipoCliente.Text = IdTypeC;
        }

        public void ChargeValues(int IdCustomer, string DUI, string names, string lastNames, string phone, string email, string address, string IdTypeC)
        {
            try
            {
                objUploadCustomers.txtDui.Text = DUI;
                objUploadCustomers.txtNombres.Text = names;
                objUploadCustomers.txtLastNames.Text = lastNames;
                objUploadCustomers.txtTelefono.Text = phone;
                objUploadCustomers.txtEmail.Text = email;
                objUploadCustomers.txtDireccion.Text = address;
                objUploadCustomers.dpTipoCliente.Text = IdTypeC.ToString();
                


            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
=======
>>>>>>> Stashed changes
    }
}
