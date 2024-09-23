using PTC2024.Model.DAO.EmployeesDAO;
using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.Model.DAO.ServicesDAO;
using PTC2024.View.EmployeeViews;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.PayrollsController
{
    internal class ControllerPermission
    {
        FrmPermissions objPermission;
        public ControllerPermission(FrmPermissions View)
        {
            objPermission = View;
            objPermission.Load += new EventHandler(LoadData);
            objPermission.btnGeneratePermission.Click += new EventHandler(OpenAddPermission);
            objPermission.cmsUpdatePermission.Click += new EventHandler(OpenUpdatePermission);
            objPermission.btnDeletePermission.Click += new EventHandler(DeshiblePermission);
            objPermission.cmsDeletePermission.Click += new EventHandler(DeletePermission);
            objPermission.txtEmployeeSearch.KeyDown += new KeyEventHandler(SearchPermissionEvent);
            objPermission.cb1.Click += new EventHandler(CheckedBy1);
            objPermission.cb2.Click += new EventHandler(CheckedBy2);
            objPermission.cb3.Click += new EventHandler(CheckedBy3);
            objPermission.cb4.Click += new EventHandler(CheckedBy4);
            objPermission.cb5.Click += new EventHandler(CheckedBy5);
            objPermission.cb6.Click += new EventHandler(CheckedBy6);
            objPermission.cb7.Click += new EventHandler(CheckedBy7);


        }
        public void LoadData(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            DAOPermission daoRefresh = new DAOPermission();
            DataSet dataSet = daoRefresh.GetPermissions();
            objPermission.dgvPermissions.DataSource = dataSet.Tables["viewPermissions"];
            objPermission.dgvPermissions.Columns[1].Visible = false;
            objPermission.dgvPermissions.Columns[7].Visible = false;
            objPermission.dgvPermissions.Columns[8].Visible = false;
        }
        public void SearchPermissionEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPermission();
            }
            if (objPermission.txtEmployeeSearch.Text == string.Empty)
            {
                RefreshData();
            }
        }
        void SearchPermission()
        {
            DAOPermission objDao = new DAOPermission();
            DataSet ds = objDao.SearchPayroll(objPermission.txtEmployeeSearch.Text.Trim());
            objPermission.dgvPermissions.DataSource = ds.Tables["viewPermissions"];
        }
        public void OpenAddPermission(object sender, EventArgs e)
        {
            FrmAddPermission openForm = new FrmAddPermission();
            openForm.ShowDialog();
            RefreshData();
        }
        public void OpenUpdatePermission(object sender, EventArgs e)
        {
            int pos = objPermission.dgvPermissions.CurrentRow.Index;
            int idEmployee, idPermission, idType, idStatus;
            DateTime start, end;
            string context, status, typeP;
            idEmployee = int.Parse(objPermission.dgvPermissions[0, pos].Value.ToString());
            idPermission = int.Parse(objPermission.dgvPermissions[1, pos].Value.ToString());
            start = DateTime.Parse(objPermission.dgvPermissions[2, pos].Value.ToString());
            end = DateTime.Parse(objPermission.dgvPermissions[3, pos].Value.ToString());
            context = objPermission.dgvPermissions[4, pos].Value.ToString();
            status = objPermission.dgvPermissions[6, pos].Value.ToString();
            typeP = objPermission.dgvPermissions[5, pos].Value.ToString();
            idType = int.Parse(objPermission.dgvPermissions[7,pos].Value.ToString());
            idStatus = int.Parse(objPermission.dgvPermissions[8,pos].Value.ToString());
            FrmUpdatePermission openUpdatePermission = new FrmUpdatePermission(idEmployee, idPermission, start, end, context, status, typeP, idType, idStatus);
            openUpdatePermission.ShowDialog();
            RefreshData();

        }
        public void DeletePermission(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de borrar los datos, esta accion no se puede revertir", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOPermission daoPermission = new DAOPermission();
                int pos = objPermission.dgvPermissions.CurrentRow.Index;
                daoPermission.IdPermission = int.Parse(objPermission.dgvPermissions[1, pos].Value.ToString());
                int answer = daoPermission.DeletePermission();

                /*Se evalua la respuesta*/
                if (answer == 1)
                {
                    MessageBox.Show("Los datos se eliminaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Los datos no se eliminaron debido a un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshData();

            }
        }


        public void DeshiblePermission(object sender, EventArgs e)
        {
            DAOPermission DaoDeshiblePermission = new DAOPermission();
            DataSet dsPermissions = DaoDeshiblePermission.GetPermissionsDisable();
            DataSet dsEmployee = DaoDeshiblePermission.GetEmployee();
            DataTable dtPermissions = dsPermissions.Tables["tbPermissions"];
            DataTable dtEmployee = dsEmployee.Tables["tbEmployee"];
            int returnValue = 0;
            foreach (DataRow dr in dtEmployee.Rows)
            {
                int employeeStatus = int.Parse(dr["IdStatus"].ToString());
                if (employeeStatus == 2)
                {
                    int IdEmployee = int.Parse(dr["IdEmployee"].ToString());
                    DataRow[] permissions = dtPermissions.Select($"IdEmployee = {IdEmployee}");
                    foreach (DataRow permissionRow in permissions)
                    {
                        int idPermission = int.Parse(permissionRow["IdPermission"].ToString());
                        DaoDeshiblePermission.IdStatusPermission = 3;
                        DaoDeshiblePermission.IdEmployee = IdEmployee;
                        returnValue = DaoDeshiblePermission.UpdateDsEPermission();
                    }
                }
            }
            RefreshData();
            if (returnValue == 1)
            {
                MessageBox.Show("Los datos han sido eliminados exitosamente",
                                "Proceso completado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser eliminados",
                                "Proceso interrumpido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        public void CheckedBy1(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOPermission daoPermission = new DAOPermission();
            //Creamos una variable string que dependerá de que checkbox esta activado
            if (objPermission.cb1.Checked == true)
            {
                objPermission.cb2.Checked = false;
                objPermission.cb3.Checked = false;
                objPermission.cb4.Checked = false;
                objPermission.cb5.Checked= false;
                objPermission.cb6.Checked = false;
                objPermission.cb7.Checked = false;
                DataSet ds = daoPermission.SearchPermissionBy1();
                objPermission.dgvPermissions.DataSource = ds.Tables["viewPermissions"];
            }
            else
            {
                RefreshData();
            }
        }
        public void CheckedBy2(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOPermission daoPermission = new DAOPermission();
            //Creamos una variable string que dependerá de que checkbox esta activado
            if (objPermission.cb2.Checked == true)
            {
                objPermission.cb1.Checked = false;
                objPermission.cb3.Checked = false;
                objPermission.cb4.Checked = false;
                objPermission.cb6.Checked = false;
                objPermission.cb7.Checked = false;
                objPermission.cb5.Checked = false;

                DataSet ds = daoPermission.SearchPermissionBy2();
                objPermission.dgvPermissions.DataSource = ds.Tables["viewPermissions"];
            }
            else
            {
                RefreshData();
            }
        }
        public void CheckedBy3(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOPermission daoPermission = new DAOPermission();
            //Creamos una variable string que dependerá de que checkbox esta activado
            if (objPermission.cb3.Checked == true)
            {
                objPermission.cb2.Checked = false;
                objPermission.cb1.Checked = false;
                objPermission.cb4.Checked = false;
                objPermission.cb5.Checked = false;
                objPermission.cb6.Checked = false;
                objPermission.cb7.Checked = false;


                DataSet ds = daoPermission.SearchPermissionBy3();
                objPermission.dgvPermissions.DataSource = ds.Tables["viewPermissions"];
            }
            else
            {
                RefreshData();
            }
        }
        public void CheckedBy4(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOPermission daoPermission = new DAOPermission();
            //Creamos una variable string que dependerá de que checkbox esta activado
            if (objPermission.cb4.Checked == true)
            {
                objPermission.cb2.Checked = false;
                objPermission.cb3.Checked = false;
                objPermission.cb1.Checked = false;
                objPermission.cb5.Checked = false;
                objPermission.cb6.Checked = false;
                objPermission.cb7.Checked = false;


                DataSet ds = daoPermission.SearchPermissionBy4();
                objPermission.dgvPermissions.DataSource = ds.Tables["viewPermissions"];
            }
            else
            {
                RefreshData();
            }
        }
        public void CheckedBy5(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOPermission daoPermission = new DAOPermission();
            //Creamos una variable string que dependerá de que checkbox esta activado
            if (objPermission.cb5.Checked == true)
            {
                objPermission.cb2.Checked = false;
                objPermission.cb3.Checked = false;
                objPermission.cb1.Checked = false;
                objPermission.cb4.Checked = false;
                objPermission.cb6.Checked = false;
                objPermission.cb7.Checked = false;


                DataSet ds = daoPermission.SearchPermissionBy5();
                objPermission.dgvPermissions.DataSource = ds.Tables["viewPermissions"];
            }
            else
            {
                RefreshData();
            }
        }
        public void CheckedBy6(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOPermission daoPermission = new DAOPermission();
            //Creamos una variable string que dependerá de que checkbox esta activado
            if (objPermission.cb6.Checked == true)
            {
                objPermission.cb2.Checked = false;
                objPermission.cb3.Checked = false;
                objPermission.cb1.Checked = false;
                objPermission.cb5.Checked = false;
                objPermission.cb4.Checked = false;
                objPermission.cb7.Checked = false;


                DataSet ds = daoPermission.SearchPermissionBy6();
                objPermission.dgvPermissions.DataSource = ds.Tables["viewPermissions"];
            }
            else
            {
                RefreshData();
            }
        }
        public void CheckedBy7(object sender, EventArgs e)
        {
            //Creamos objeto del DAOEmployee
            DAOPermission daoPermission = new DAOPermission();
            //Creamos una variable string que dependerá de que checkbox esta activado
            if (objPermission.cb7.Checked == true)
            {
                objPermission.cb2.Checked = false;
                objPermission.cb3.Checked = false;
                objPermission.cb1.Checked = false;
                objPermission.cb5.Checked = false;
                objPermission.cb6.Checked = false;
                objPermission.cb4.Checked = false;


                DataSet ds = daoPermission.SearchPermissionBy7();
                objPermission.dgvPermissions.DataSource = ds.Tables["viewPermissions"];
            }
            else
            {
                RefreshData();
            }
        }
    }
}
