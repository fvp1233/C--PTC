using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.EmployeeViews;
using PTC2024.View.Service_inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.PayrollsController
{
    internal class ControllerUpdatePermission
    {
        FrmUpdatePermission objUpdatePermission;
        public ControllerUpdatePermission(FrmUpdatePermission View, int idEmployee, int idPermission, DateTime start, DateTime end, string context, string status, string typeP)
        {
            objUpdatePermission = View;
            DisableComponents();
            ChargeValues(idEmployee, idPermission, start, end, context, status, typeP);
            objUpdatePermission.Load += new EventHandler(FillDropdown);
            objUpdatePermission.btnAddPermission.Click += new EventHandler(UpdatePermission);
            objUpdatePermission.btnCancel.Click += new EventHandler(CloseForm);
        }
        public void UpdatePermission(object sender, EventArgs e)
        {
            try
            {
                DAOUpdatePermission daoUpdate = new DAOUpdatePermission();
                daoUpdate.Start = objUpdatePermission.dtpStart.Value;
                daoUpdate.End = objUpdatePermission.dtpEnd.Value;
                daoUpdate.Context = objUpdatePermission.rtxtContext.Text.Trim();
                daoUpdate.IdEmployee = int.Parse(objUpdatePermission.txtIdEmployee.Text.Trim());
                daoUpdate.IdStatusPermission = (int)objUpdatePermission.cmbStatusPermission.SelectedValue;
                daoUpdate.IdTypePermission = (int)objUpdatePermission.cmbTypePermission.SelectedValue;
                daoUpdate.IdPermission = int.Parse(objUpdatePermission.txtIdPermission.Text.Trim());
                int returnedValues = daoUpdate.UpdatePermission();
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
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{ex}",
                "Proceso completado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            CloseF();
        }
        public void FillDropdown(object sender, EventArgs e)
        {
            DAOUpdatePermission daoPermission = new DAOUpdatePermission();

            DataSet dsTypePermission = daoPermission.GetTypePermission();
            objUpdatePermission.cmbTypePermission.DataSource = dsTypePermission.Tables["tbTypePermission"];
            objUpdatePermission.cmbTypePermission.DisplayMember = "typePermisiion";
            objUpdatePermission.cmbTypePermission.ValueMember = "IdTypePermission";

            DataSet dsStatusPermission = daoPermission.GetStatusPermission();
            objUpdatePermission.cmbStatusPermission.DataSource = dsStatusPermission.Tables["tbStatusPermission"];
            objUpdatePermission.cmbStatusPermission.DisplayMember = "statusPermission";
            objUpdatePermission.cmbStatusPermission.ValueMember = "IdStatusPermission";
        }
        public void ChargeValues(int idEmployee, int idPermission, DateTime start, DateTime end, string context, string status, string typeP)
        {
            try
            {
                objUpdatePermission.txtIdEmployee.Text = idEmployee.ToString();
                objUpdatePermission.txtIdPermission.Text = idPermission.ToString();
                objUpdatePermission.dtpStart.Value = start;
                objUpdatePermission.dtpEnd.Value = end;
                objUpdatePermission.rtxtContext.Text = context.ToString();
                objUpdatePermission.cmbStatusPermission.Text = status.ToString();
                objUpdatePermission.cmbTypePermission.Text = typeP.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DisableComponents()
        {
            objUpdatePermission.txtIdPermission.Visible = false;
        }
        public void CloseF()
        {
            objUpdatePermission.Close();
        }
        public void CloseForm(object sender, EventArgs e)
        {
            CloseF();
        }
    }
}
