using PTC2024.Model.DAO.MaintenanceDAO;
using PTC2024.View.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.MaintenanceController
{
    internal class ControllerUpdateCharge
    {
        FrmUpdateCharge objUpdateCharge;
        public ControllerUpdateCharge(FrmUpdateCharge View, int id, string name, double bonus)
        {
            objUpdateCharge = View;
            ChargeValues(id, name, bonus);
            Disable();
            objUpdateCharge.btnUpdate.Click += new EventHandler(UpdateCharge);
            objUpdateCharge.btnGoBack.Click += new EventHandler(CloseForm);
        }
        public void UpdateCharge(object sender, EventArgs e)
        {
            DAOUpdateCharge DAOUpdate = new DAOUpdateCharge();
            DAOUpdate.NameCharge = objUpdateCharge.txtCharge.Text.Trim();
            DAOUpdate.BonusCharge = double.Parse(objUpdateCharge.txtBonus.Text.Trim());
            DAOUpdate.IdCharge = int.Parse(objUpdateCharge.txtID.Text.Trim());
            int returnedValues = DAOUpdate.UpdateCharge();
            if (returnedValues == 1)
            {
                MessageBox.Show("Los datos han sido actualizado exitosamente",
                "Proceso completado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Los datos no pudieron ser actualizados debido a un error inesperado",
                "Proceso interrumpido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            CloseUpdate();
        }
        public void ChargeValues(int id, string name, double bonus)
        {
            try
            {
                objUpdateCharge.txtID.Text = id.ToString();
                objUpdateCharge.txtCharge.Text = name;
                objUpdateCharge.txtBonus.Text = bonus.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        public void Disable()
        {
            objUpdateCharge.txtID.Visible = false;
        }
        public void CloseUpdate()
        {
            objUpdateCharge.Close();
        }
        public void CloseForm(object sender, EventArgs e)
        {
            CloseUpdate();
        }
    }
}
