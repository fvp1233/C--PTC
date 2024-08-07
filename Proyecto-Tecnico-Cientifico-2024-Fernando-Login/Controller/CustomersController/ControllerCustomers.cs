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
    class ControllerCustomers
    {
        FrmCustomers objCustomers;
        public ControllerCustomers(FrmCustomers Vista) { 
            objCustomers = Vista;
            objCustomers.Load += new EventHandler(LoadData);
            objCustomers.chkTodos.Click += new EventHandler(ChekedTodos);
            objCustomers.chkJuridico.Click += new EventHandler(ChekedJuridico);
            objCustomers.chkNatural.Click += new EventHandler(ChekedNatural);
            objCustomers.BtnAddCustomer.Click += new EventHandler(AddCustomer);
            objCustomers.cmsActualizarCliente.Click += new EventHandler(UpdateCustomers);
        }

        public void UpdateCustomers(object sender, EventArgs e)
        {
            int pos = objCustomers.dgvCustomers.CurrentRow.Index;

            FrmAddCustomers openForm = new FrmAddCustomers(2,
                int.Parse(objCustomers.dgvCustomers[0,pos].Value.ToString()),
                int.Parse(objCustomers.dgvCustomers[1,pos].Value.ToString()),
                objCustomers.dgvCustomers[2, pos].Value.ToString(),
                objCustomers.dgvCustomers[3, pos].Value.ToString(),
                objCustomers.dgvCustomers[4, pos].Value.ToString(),
                objCustomers.dgvCustomers[5, pos].Value.ToString(),
                objCustomers.dgvCustomers[6, pos].Value.ToString(),
                int.Parse(objCustomers.dgvCustomers[7,pos].Value.ToString())
                )  
                ;
            openForm.ShowDialog();
            RefrescarData();
            

        }
        public void AddCustomer (object sender, EventArgs e)
        {
            FrmAddCustomers abrirForm = new FrmAddCustomers(1);
            abrirForm.ShowDialog();
            RefrescarData();

        }
        public void ChekedNatural(object sender, EventArgs e)
        {
            objCustomers.chkJuridico.Checked = false;
            objCustomers.chkTodos.Checked = false;
            RefrescarData();
        }
        public void ChekedJuridico(object sender, EventArgs e)
        {
            objCustomers.chkNatural.Checked = false;
            objCustomers.chkTodos.Checked = false;
            RefrescarData();
        }
        public void ChekedTodos(object sender, EventArgs e )
        {
            objCustomers.chkNatural.Checked = false;
            objCustomers.chkJuridico.Checked = false;
            RefrescarData();
        }
        public void LoadData(object sender, EventArgs e) {

            RefrescarData();
        }
        public void RefrescarData()
        {
            DAOCustomers objDAOCustomers = new DAOCustomers();
            DataSet ds = new DataSet();
            string tipoP = "";
            if (objCustomers.chkTodos.Checked==true) {
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
            ds = objDAOCustomers.FillCustomers(tipoP);
            objCustomers.dgvCustomers.DataSource = ds.Tables["tbCustomers"];
            objCustomers.dgvCustomers.Columns[0].DividerWidth = 1;
            objCustomers.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            
            



        }
    }
}
