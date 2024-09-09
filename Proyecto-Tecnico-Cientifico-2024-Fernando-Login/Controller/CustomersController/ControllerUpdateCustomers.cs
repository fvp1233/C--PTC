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
        private int idTypeC;

        //Se declara el constructor con sus respectivos parametros
        public ControllerUpdateCustomers(FrmUploadCustomers View, int idClient, string dui,string names, string lastnames,  string phone, string email, string address, int idTypeC)
        {

            objUpdateCustomers = View;
            this.idTypeC = idTypeC;
            ChargeValues(idClient, dui, names, lastnames, phone, email, address);
            //Evento para cargar los combos
            objUpdateCustomers.Load += new EventHandler(loadCombos);
            //Evento para actulizar los clientes
            objUpdateCustomers.BtnActualizarCliente.Click += new EventHandler(UpdateCustomers);
            //Evento para cancelar el proceso
            objUpdateCustomers.BtnCancelar.Click += new EventHandler(CancelProcess);
            objUpdateCustomers.txtNames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCustomers.txtLastNames.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCustomers.txtDui.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCustomers.txtAddress.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCustomers.txtPhone.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCustomers.txtEmail.MouseDown += new MouseEventHandler(DisableContextMenu);
        }

        public void loadCombos(object sender, EventArgs e)
        {
            DAOAddCustomers dAOAddCustomers = new DAOAddCustomers();


            DataSet dsclientType = dAOAddCustomers.getTypeCustomers();
            objUpdateCustomers.dpClientType.DataSource = dsclientType.Tables["tbTypeC"];
            objUpdateCustomers.dpClientType.DisplayMember = "customerType";
            objUpdateCustomers.dpClientType.ValueMember = "IdTypeC";
            objUpdateCustomers.dpClientType.SelectedValue = idTypeC;


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
            daoUpdateCustomers.ClientType = int.Parse(objUpdateCustomers.dpClientType.SelectedValue.ToString());

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
