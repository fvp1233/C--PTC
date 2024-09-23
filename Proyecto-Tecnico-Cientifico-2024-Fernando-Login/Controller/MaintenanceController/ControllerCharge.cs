using PTC2024.Model.DAO.MaintenanceDAO;
using PTC2024.View.Dashboard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.MaintenanceController
{
    internal class ControllerCharge
    {
        FrmCharge objCharge;
        public ControllerCharge(FrmCharge View)
        {
            objCharge = View;
            objCharge.Load += new EventHandler(LoadData);
            objCharge.cmsDeleteCharge.Click += new EventHandler(DeleteCharge);
            objCharge.cmsUpdateCharge.Click += new EventHandler(OpenUdateCharge);
            objCharge.btnGoBack.Click += new EventHandler(GoBack);
        }
        public void DeleteCharge(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de borrar los datos, esta accion no se puede revertir", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOCharge objDelete = new DAOCharge();
                int pos = objCharge.dgvCharge.CurrentRow.Index;
                objDelete.IdCharge = int.Parse(objCharge.dgvCharge[0, pos].Value.ToString());
                int answer = objDelete.DeleteCharge();
                if (answer == 1)
                {
                    MessageBox.Show("Los datos se eliminaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    objCharge.snack.Show(objCharge, "Este cargo no se puede eliminar debido a que un empleado pertenece a este puesto", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomCenter);
                }
            }
            RefreshData();
        }
        public void LoadData(object sender, EventArgs e)
        {
            RefreshData();
            objCharge.txtId.Visible = false;
            objCharge.dgvCharge.Columns[0].Visible = false;

        }
        public void RefreshData()
        {
            DAOCharge objRefresh = new DAOCharge();
            DataSet ds = objRefresh.GetCharge();
            objCharge.dgvCharge.DataSource = ds.Tables["tbBusinessP"];

        }
        public void GoBack(object sender, EventArgs e)
        {
            objCharge.Close();
        }
        public void OpenUdateCharge(object sender, EventArgs e)
        {
            int pos = objCharge.dgvCharge.CurrentRow.Index;
            int id;
            string name;
            double bonus;
            id = int.Parse(objCharge.dgvCharge[0, pos].Value.ToString());
            name = objCharge.dgvCharge[1, pos].Value.ToString();
            bonus = double.Parse(objCharge.dgvCharge[2, pos].Value.ToString());
            FrmUpdateCharge openFrom = new FrmUpdateCharge(id, name, bonus);
            openFrom.ShowDialog();
            RefreshData();
        }
    }
}
