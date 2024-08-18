using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.EmployeeViews;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        public void OpenAddPermission(object sender, EventArgs e)
        {
            FrmAddPermission openForm = new FrmAddPermission();
            openForm.ShowDialog();
        }
        public void OpenUpdatePermission(object sender, EventArgs e)
        {
            int pos = objPermission.dgvPermissions.CurrentRow.Index;
            int idEmployee, idPermission;
            DateTime start, end;
            string context, status, typeP;
            idEmployee = int.Parse(objPermission.dgvPermissions[0, pos].Value.ToString());
            idPermission = int.Parse(objPermission.dgvPermissions[1, pos].Value.ToString());
            start = DateTime.Parse(objPermission.dgvPermissions[2,pos].Value.ToString());
            end = DateTime.Parse(objPermission.dgvPermissions[3,pos].Value.ToString());
            context = objPermission.dgvPermissions[4,pos].Value.ToString();
            status = objPermission.dgvPermissions[6, pos].Value.ToString();
            typeP = objPermission.dgvPermissions[5, pos].Value.ToString();
            FrmUpdatePermission openUpdatePermission = new FrmUpdatePermission(idEmployee, idPermission, start, end, context, status, typeP);
            openUpdatePermission.ShowDialog();
            RefreshData();

        }

    }
}
