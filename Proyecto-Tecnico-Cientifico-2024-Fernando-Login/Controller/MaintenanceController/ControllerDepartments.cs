using PTC2024.Model.DAO.MaintenanceDAO;
using PTC2024.View.Dashboard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.MaintenanceController
{
    internal class ControllerDepartments
    {
        FrmDepartments objDep;
        public ControllerDepartments(FrmDepartments View)
        {
            objDep = View;
            objDep.Load += new EventHandler(LoadData);
            objDep.btnAddDepartment.Click += new EventHandler(NewDepartment);
            objDep.cmsDeleteDepartment.Click += new EventHandler(DeleteDepartment);
            objDep.btnGoBack.Click += new EventHandler(GoBack);
        }
        public void NewDepartment(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objDep.txtDepartment.Text.Trim())))
            {
                DAODepartment DAOInsert = new DAODepartment();
                DAOInsert.Department = objDep.txtDepartment.Text.Trim();
                int returnedValue = DAOInsert.AddDepartment();
                if (returnedValue == 1)
                {
                    MessageBox.Show("Los datos han sido registrados exitosamente",
                "Proceso completado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Los datos no pudieron ser registrados",
                                    "Proceso interrumpido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Existen campos vacíos, complete cada uno de los apartados.",
                    "Proceso interrumpido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            RefreshData();
            objDep.txtDepartment.Clear();
        }
        public void DeleteDepartment(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de borrar los datos, esta accion no se puede revertir", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAODepartment dAODepartment = new DAODepartment();
                int pos = objDep.dgvDepartments.CurrentRow.Index;
                dAODepartment.IdDepartment = int.Parse(objDep.dgvDepartments[0, pos].Value.ToString());
                int answer = dAODepartment.DeleteDepartment();
                if (answer == 1)
                {
                    MessageBox.Show("Los datos se eliminaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Los datos no se eliminaron debido a un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            RefreshData();
        }
        public void LoadData(object sender, EventArgs e)
        {
            RefreshData();
            objDep.dgvDepartments.Columns[0].Visible = false;
        }
        public void RefreshData()
        {
            DAODepartment objRefresh = new DAODepartment();
            DataSet ds = objRefresh.GetDepartmentDgv();
            objDep.dgvDepartments.DataSource = ds.Tables["tbDepartment"];
        }
        public void GoBack(object sender, EventArgs e)
        {
            objDep.Close();
        }
    }
}
