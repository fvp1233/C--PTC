using System;
using System.Collections.Generic;
using System.Data;
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
        

        //Se declara el constructor con sus respectivos parametros
        public ControllerUpdateCustomers(FrmUploadCustomers View, int idClient, string dui,string names, string lastnames,  string phone, string email, string address )
        {

            objUpdateCustomers = View;
            
            ChargeValues(idClient, dui, names, lastnames, phone, email, address );
            //Evento para cargar los combos
            objUpdateCustomers.Load += new EventHandler(loadCombos);
            //Evento para actulizar los clientes
            objUpdateCustomers.BtnActualizarCliente.Click += new EventHandler(UpdateCustomers);
            //Evento para cancelar el proceso
            objUpdateCustomers.BtnCancelar.Click += new EventHandler(CancelProcess);
        }

        public void loadCombos(object sender, EventArgs e)
        {
            DAOAddCustomers dAOAddCustomers = new DAOAddCustomers();


            DataSet dsclientType = dAOAddCustomers.getTypeCustomers();
            objUpdateCustomers.dpClientType.DataSource = dsclientType.Tables["tbTypeC"];
            objUpdateCustomers.dpClientType.DisplayMember = "customerType";
            objUpdateCustomers.dpClientType.ValueMember = "IdTypeC";


        }

        public void UpdateCustomers(object sender, EventArgs e)
        {
            DAOUpdateCustomers daoUpdateCustomers = new DAOUpdateCustomers();

            daoUpdateCustomers.IdClient = int.Parse(objUpdateCustomers.txtId.Text); 
            daoUpdateCustomers.Dui = objUpdateCustomers.txtDui.Text;
            daoUpdateCustomers.Name = objUpdateCustomers.txtNames.Text;
            daoUpdateCustomers.LastNames = objUpdateCustomers.txtLastNames.Text;
            daoUpdateCustomers.Email = objUpdateCustomers.txtEmail.Text;
            daoUpdateCustomers.Address = objUpdateCustomers.txtAddress.Text;
            daoUpdateCustomers.Phone = objUpdateCustomers.txtPhone.Text;

            int answer = daoUpdateCustomers.updateCustomers();
            if (answer == 1)
            {
                MessageBox.Show("Datos Actualizados");
                objUpdateCustomers.Close();
            }

          }

        public void ChargeValues(int idClient, string dui, string names, string lastnames, string phone, string email, string address) {


            try
            {
                objUpdateCustomers.txtId.Text = idClient.ToString();
                objUpdateCustomers.txtDui.Text = dui;
                objUpdateCustomers.txtNames.Text = names;
                objUpdateCustomers.txtLastNames.Text = lastnames;
                objUpdateCustomers.txtEmail.Text= email;
                objUpdateCustomers.txtAddress.Text = address;
                objUpdateCustomers.txtPhone.Text = phone;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void CancelProcess(object sender, EventArgs e)
        {
            objUpdateCustomers.Close();

        }






}
}
