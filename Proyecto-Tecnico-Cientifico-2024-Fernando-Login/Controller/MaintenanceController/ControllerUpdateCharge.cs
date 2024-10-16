using PTC2024.Model.DAO.MaintenanceDAO;
using PTC2024.View.Dashboard;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            objUpdateCharge.Load += new EventHandler(DarkMode);
            objUpdateCharge.btnUpdate.Click += new EventHandler(UpdateCharge);
            objUpdateCharge.btnGoBack.Click += new EventHandler(CloseForm);
            objUpdateCharge.txtCharge.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdateCharge.txtBonus.MouseDown += new MouseEventHandler(DisableContextMenu);
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

        public void DarkMode(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.darkMode == true)
            {
                objUpdateCharge.BackColor = Color.FromArgb(30, 30, 30);
                objUpdateCharge.lblTitle.ForeColor = Color.White;
                objUpdateCharge.lblName.ForeColor = Color.White;
                objUpdateCharge.lblBonus.ForeColor = Color.White;
            }
            
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

        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }
    }
}
