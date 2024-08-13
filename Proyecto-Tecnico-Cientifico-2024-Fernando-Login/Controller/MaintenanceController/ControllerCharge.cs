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
            objCharge.btnAddCharge.Click += new EventHandler(NewCharge);
            objCharge.cmsDeleteCharge.Click += new EventHandler(DeleteCharge);
            objCharge.btnGoBack.Click += new EventHandler(GoBack);
        }
        public void NewCharge(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objCharge.txtCharge.Text.Trim())|| string.IsNullOrEmpty(objCharge.txtBonus.Text.Trim())))
            { 
                DAOCharge DAOInsert = new DAOCharge();
                DAOInsert.NameCharge = objCharge.txtCharge.Text.Trim();
                DAOInsert.BonusCharge = double.Parse(objCharge.txtBonus.Text.Trim());
                int returnedValue = DAOInsert.AddCharge();
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
            RefreshData();
            objCharge.txtCharge.Clear();
            objCharge.txtBonus.Clear();
        }
        //public void UpdateCharge(object sender, EventArgs e)
        //{
        //    DAOCharge DAOUpdate = new DAOCharge();
        //    DAOUpdate.IdCharge = int.Parse(objCharge.txtId.Text.Trim());
        //    DAOUpdate.NameCharge = objCharge.txtCharge.Text.Trim();
        //    DAOUpdate.BonusCharge = double.Parse(objCharge.txtBonus.Text.Trim());
        //    int returnedValues = DAOUpdate.UpdateCharge();
        //    if(returnedValues == 1)
        //    {
        //        MessageBox.Show("Los datos han sido actualizado exitosamente",
        //        "Proceso completado",
        //        MessageBoxButtons.OK,
        //        MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Los datos no pudieron ser actualizados debido a un error inesperado",
        //        "Proceso interrumpido",
        //        MessageBoxButtons.OK,
        //        MessageBoxIcon.Error);
        //    }
        //}
        //public void ChargeValues(int id, string name, double bonus)
        //{
        //    try
        //    {
        //        objCharge.txtId.Text = id.ToString();
        //        objCharge.txtCharge.Text = name;
        //        objCharge.txtBonus.Text = bonus.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"{ex.Message}");
        //    }
        //}
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
                    MessageBox.Show("Los datos no se eliminaron debido a un error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
