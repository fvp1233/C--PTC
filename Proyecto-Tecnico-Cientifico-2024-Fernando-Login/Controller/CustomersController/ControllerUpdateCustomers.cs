using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Model.DAO.CustomersDAO;
using PTC2024.View.Clientes;

namespace PTC2024.Controller.CustomersController
{
    internal class ControllerUpdateCustomers
    {
        FrmUploadCustomers objUpdateCustomers;

        public ControllerUpdateCustomers(FrmUploadCustomers View, int idClient, string dui,string names, string lastnames,  string phone, string email, string address)
        {

            objUpdateCustomers = View;
            ChargeValues(idClient, dui, names, lastnames, phone, email, address);
            objUpdateCustomers.BtnActualizarCliente.Click += new EventHandler(UpdateCustomers);
    }

        public void UpdateCustomers(object sender, EventArgs e)
        {
            DAOUpdateCustomers daoUpdateCustomers = new DAOUpdateCustomers();

            daoUpdateCustomers.IdClient = int.Parse(objUpdateCustomers.txtId.Text); 
            daoUpdateCustomers.Dui = objUpdateCustomers.txtDui.Text;
            daoUpdateCustomers.Name = objUpdateCustomers.txtNombres.Text;
            daoUpdateCustomers.LastNames = objUpdateCustomers.txtApellidos.Text;
            daoUpdateCustomers.Email = objUpdateCustomers.txtEmail.Text;
            daoUpdateCustomers.Address = objUpdateCustomers.txtDireccion.Text;
            daoUpdateCustomers.Phone = objUpdateCustomers.txtTelefono.Text;

            int respuesta = daoUpdateCustomers.updateCustomers();
            if (respuesta == 1)
            {
                MessageBox.Show("Datos Actualizados");
            }

          }

        public void ChargeValues(int idClient, string dui, string names, string lastnames, string phone, string email, string address) {


            try
            {
                objUpdateCustomers.txtId.Text = idClient.ToString();
                objUpdateCustomers.txtDui.Text = dui;
                objUpdateCustomers.txtNombres.Text = names;
                objUpdateCustomers.txtApellidos.Text = lastnames;
                objUpdateCustomers.txtEmail.Text= email;
                objUpdateCustomers.txtDireccion.Text = address;
                objUpdateCustomers.txtTelefono.Text = phone;

            }
            catch (Exception)
            {

                throw;
            }

        }

        

        

}
}
