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
            objPermission.txtEmployeeSearch.KeyPress += new KeyPressEventHandler(SearchPermissionEvent);
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
        public void SearchPermissionEvent(object sender, KeyPressEventArgs e)
        {
            SearchPermission();
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
    }
}
