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
            //Eventos que carga los datos del datagridview
            objCustomers.Load += new EventHandler(LoadData);
            //Eventos para la filtración de clientes ya sea natural, juridico o sean todos
            objCustomers.chkTodos.Click += new EventHandler(ChekedTodos);
            objCustomers.chkJuridico.Click += new EventHandler(ChekedJuridico);
            objCustomers.chkNatural.Click += new EventHandler(ChekedNatural);
            //Evento para añadir un cliente 
            objCustomers.BtnAddCustomer.Click += new EventHandler(AddCustomer);
            //Evento para actualizar un cliente
            objCustomers.cmsActualizarCliente.Click += new EventHandler(UpdateCustomers);
            //Evento para eliminar un cliente
            objCustomers.cmsEliminarCliente.Click += new EventHandler(DeleteCustomer);
            //Evento para buscar clientes 
            objCustomers.txtSearch.KeyPress += new KeyPressEventHandler(Search);

        }

        //Metodo que carga los datos(refresca todo los datos del datagridview)
        public void LoadData(object sender, EventArgs e)
        {

            refreshData();
        }

        //Metodo que filtra todos los clientes existentes
        public void ChekedTodos(object sender, EventArgs e)
        {
            objCustomers.chkTodos.Checked = true;
            objCustomers.chkNatural.Checked = false;
            objCustomers.chkJuridico.Checked = false;
            refreshData();
        }

        //Metodo que filtra los cheques de los clientes judiciales
        public void ChekedJuridico(object sender, EventArgs e)
        {
            objCustomers.chkJuridico.Checked = true;
            objCustomers.chkNatural.Checked = false;
            objCustomers.chkTodos.Checked = false;
            refreshData();
        }

        //Metodo que filtra los cheques de los clientes naturales
        public void ChekedNatural(object sender, EventArgs e)
        {
            objCustomers.chkNatural.Checked = true;
            objCustomers.chkJuridico.Checked = false;
            objCustomers.chkTodos.Checked = false;
            refreshData();
        }

        //Metodo para refrescar al añadir un cliente
        public void AddCustomer(object sender, EventArgs e)
        {
            FrmAddCustomers abrirForm = new FrmAddCustomers();
            abrirForm.ShowDialog();
            refreshData();
        }

        //Metodo para actualizar un cliente
        public void UpdateCustomers(object sender, EventArgs e)
        {
            //Se llenan los parametros del datagridview, en su correspondiente columna
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


        //Metodo que muestra y recarga todos los clientes
        public void refreshData()
        {   //Se hace la condicion para filtrar que clientes se mostraran
            //De manera predeterminada se mostraran todos
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
            //Se llenara el data set con el tipo de persona(Cliente) esto para unicamente mostrar un tipo de persona (Todos, Judicial, Natural)
            DataSet ds = objRefresh.FillCustomers(tipoP);

            //Se llena el datagridview con la vista del cliente, es decir llena todos los datos del cliente
            objCustomers.dgvCustomers.DataSource = ds.Tables["viewCustomers"];

        }

        //Metodo para eliminar un cliente
        public void DeleteCustomer(object sender, EventArgs e)
        {
            // se le pregunta al usuario si sta seguro de borrar los datos ya que esta opcion no tiene vuelta atras
            if (MessageBox.Show("Estas seguro de borrar los datos, esta accion no se puede revertir", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Si el usuario confirma la accion entonces se procede a eliminar el Cliente
                DAOCustomers dAOCustomers = new DAOCustomers();
                //Se captura la fila seleccionada
                int pos = objCustomers.dgvCustomers.CurrentRow.Index;

                //Aca se le da valor al atributo de la clase IdCustomer
                dAOCustomers.IdCustomer1 = int.Parse(objCustomers.dgvCustomers[0, pos].Value.ToString());

                //Se captura la respuesta que retorno el metodo DeleteCustomer
                int answer = dAOCustomers.DeleteCustomers();

                //Se evalua la respuesta, si es 1 los datos se muestra la correcta eliminacion,en caso que no se muestra el mensaje de la incorrecta eliminacion
                if (answer == 1)
                {
                    MessageBox.Show("Los datos se eliminaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Los datos no se eliminaron debido a un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Se refresca el DataGridView
                refreshData();
            }
        }

        //Metodo para buscar un cliente 
        public void Search(object sender, EventArgs e)
        {
            DAOCustomers dAOCustomers = new DAOCustomers();

            //Aca se le da valor al atributo de la clase (con el textbox del search)
            dAOCustomers.Search = objCustomers.txtSearch.Text;

            //Se captura la respuesta del metodo SearchData del DAO y se le agrega su respectivo parametro
            DataSet respuesta = dAOCustomers.SearchData(dAOCustomers.Search);
            //Se le dice al DataGridView lo que tiene que mostrar (Vista de los clientes)
            objCustomers.dgvCustomers.DataSource = respuesta.Tables["viewCustomers"];
        }
    }
}

