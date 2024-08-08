using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.CustomersDAO;
using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.Model.DAO.ServicesDAO;
using PTC2024.View.Clientes;
using PTC2024.View.Service_inventory;

namespace PTC2024.Controller.CustomersController
{
    class ControllerCustomers
    {
        FrmCustomers objCustomers;
        public ControllerCustomers(FrmCustomers Vista)
        {
            objCustomers = Vista;
            objCustomers.Load += new EventHandler(LoadData);
            objCustomers.chkTodos.Click += new EventHandler(ChekedTodos);
            objCustomers.chkJuridico.Click += new EventHandler(ChekedJuridico);
            objCustomers.chkNatural.Click += new EventHandler(ChekedNatural);
            objCustomers.BtnAddCustomer.Click += new EventHandler(AddCustomer);
            objCustomers.cmsActualizarCliente.Click += new EventHandler(UpdateCustomers);
            objCustomers.cmsEliminarCliente.Click += new EventHandler(DeleteCustomer);
            objCustomers.txtSearch.KeyPress += new KeyPressEventHandler(Search);

        }

        public void UpdateCustomers(object sender, EventArgs e)
        {
            int pos = objCustomers.dgvCustomers.CurrentRow.Index;



            int id = int.Parse(objCustomers.dgvCustomers[0, pos].Value.ToString());
            string dui = objCustomers.dgvCustomers[1, pos].Value.ToString();
            string names = objCustomers.dgvCustomers[2, pos].Value.ToString();
            string lastNames = objCustomers.dgvCustomers[3, pos].Value.ToString();
            string phone = objCustomers.dgvCustomers[4, pos].Value.ToString();
            string email = objCustomers.dgvCustomers[5, pos].Value.ToString();
            string address = objCustomers.dgvCustomers[6, pos].Value.ToString();




            FrmUploadCustomers objUpdateCustomers = new FrmUploadCustomers(id, dui, names, lastNames, phone, email, address);



            objUpdateCustomers.ShowDialog();
            refreshData();


        }



        public void AddCustomer(object sender, EventArgs e)
        {
            FrmAddCustomers abrirForm = new FrmAddCustomers(1);
            abrirForm.ShowDialog();
            refreshData();

        }
        public void ChekedNatural(object sender, EventArgs e)
        {
            objCustomers.chkJuridico.Checked = false;
            objCustomers.chkTodos.Checked = false;
            refreshData();
        }
        public void ChekedJuridico(object sender, EventArgs e)
        {
            objCustomers.chkNatural.Checked = false;
            objCustomers.chkTodos.Checked = false;
            refreshData();
        }
        public void ChekedTodos(object sender, EventArgs e)
        {
            objCustomers.chkNatural.Checked = false;
            objCustomers.chkJuridico.Checked = false;
            refreshData();
        }
        public void LoadData(object sender, EventArgs e)
        {

            refreshData();
        }

        public void refreshData()
        {
            string tipoP = "";
            if (objCustomers.chkTodos.Checked == true)
            {
                tipoP = "T";
            }
            if (objCustomers.chkJuridico.Checked == true)
            {
                tipoP = "J";
            }
            if (objCustomers.chkNatural.Checked == true)
            {
                tipoP = "N";
            }

            DAOCustomers objRefresh = new DAOCustomers();
            DataSet ds = objRefresh.FillCustomers(tipoP);

            objCustomers.dgvCustomers.DataSource = ds.Tables["viewCustomers"];

        }

        public void DeleteCustomer(object sender, EventArgs e)
        {
            /*Aca se le pregunta al usuario si sta seguro de borrar los datos ya que esta opcion no tiene vuelta atras*/
            if (MessageBox.Show("Estas seguro de borrar los datos, esta accion no se puede revertir", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /*Si el usuario confirma la accion entonces se procede a eliminar el Cliente*/
                DAOCustomers dAOCustomers = new DAOCustomers();
                /*Se captura la fila seleccionada*/
                int pos = objCustomers.dgvCustomers.CurrentRow.Index;

                /*Aca se le da valor al atributo de la clase*/
                dAOCustomers.IdCustomer1 = int.Parse(objCustomers.dgvCustomers[0, pos].Value.ToString());

                /*Se captura la respuesta que retorno el metodo DeleteService*/
                int answer = dAOCustomers.DeleteCustomers();

                /*Se evalua la respuesta*/
                if (answer == 1)
                {
                    MessageBox.Show("Los datos se eliminaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Los datos no se eliminaron debido a un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                /*Se refresca el DataGridView*/
                refreshData();

            }


        }

        /*Este metodo se ejecutara cuando se escriba en el textbox para filtrar un servicio*/
        public void Search(object sender, EventArgs e)
        {
            DAOCustomers dAOCustomers = new DAOCustomers();

            /*Aca se le da valor al atributo de la clase*/
            dAOCustomers.Search = objCustomers.txtSearch.Text;

            /*Se captura la respuesta de l metodo SearchData y se le agrega su respectivo parametro*/
            DataSet respuesta = dAOCustomers.SearchData(dAOCustomers.Search);
            /*Se le dice al DataGridView lo que tiene que mostrar*/
            objCustomers.dgvCustomers.DataSource = respuesta.Tables["viewCustomers"];
        }
    }
}

