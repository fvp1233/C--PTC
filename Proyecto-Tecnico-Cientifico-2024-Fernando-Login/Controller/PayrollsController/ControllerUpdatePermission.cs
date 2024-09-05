using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.EmployeeViews;
using PTC2024.View.formularios.inicio;
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
        StartMenu objStartForm;
        private int idType;
        private int idStatus;
        public ControllerUpdatePermission(FrmUpdatePermission View, int idEmployee, int idPermission, DateTime start, DateTime end, string context, string status, string typeP, int idType, int idStatus)
        {
            objUpdatePermission = View;
            DisableComponents();
            this.idType = idType;
            this.idStatus = idStatus;
            ChargeValues(idEmployee, idPermission, start, end, context, status, typeP, idType, idStatus);
            objUpdatePermission.Load += new EventHandler(FillDropdown);
            objUpdatePermission.btnAddPermission.Click += new EventHandler(UpdatePermission);
            objUpdatePermission.txtIdEmployee.TextChanged += new EventHandler(idNum);
            objUpdatePermission.txtIdEmployee.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdatePermission.rtxtContext.MouseDown += new MouseEventHandler(DisableContextMenu);           
            objUpdatePermission.btnCancel.Click += new EventHandler(CloseForm);
        }
        public void UpdatePermission(object sender, EventArgs e)
        {
            try
            {
                DAOUpdatePermission daoUpdate = new DAOUpdatePermission();
                DAOAddPermission DaoInsert = new DAOAddPermission();
                DataSet ds = DaoInsert.GetEmployeeGender();

                if (ds != null && ds.Tables["tbEmployee"].Rows.Count > 0)
                {
                    int idGender = Convert.ToInt32(ds.Tables["tbEmployee"].Rows[0]["IdGender"]);

                    // Asumiendo que IdGender = 1 es Masculino y IdGender = 2 es Femenino.
                    if (idGender == 1 && objUpdatePermission.cmbTypePermission.Text == "Maternidad")
                    {
                        objUpdatePermission.bunifuSnackbar1.Show(objStartForm, "No se puede asignar un permiso de maternidad a un empleado masculino.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                        return;
                    }
                    else if (idGender == 2 && objUpdatePermission.cmbTypePermission.Text == "Paternidad")
                    {
                        objUpdatePermission.bunifuSnackbar1.Show(objUpdatePermission, "No se puede asignar un permiso de paternidad a una empleada femenina.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                        return;
                    }
                    if (objUpdatePermission.cmbTypePermission.Text == "Maternidad")
                    {
                        DaoInsert.EmployeeStatus = 3;
                        DaoInsert.IdEmployee = int.Parse(objUpdatePermission.txtIdEmployee.Text.Trim());
                        int returnedValue = DaoInsert.UpdateStatusEmployee();
                        if (returnedValue == 1)
                        {
                            StartMenu objStart = new StartMenu(SessionVar.Username);
                            objStartForm = objStart;
                            objStartForm.snackBar.Show(objStartForm, $"La empleada fue actualizada existosamente, inciando su su periodo de maternidad", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

                        }
                        else
                        {
                            StartMenu objStart = new StartMenu(SessionVar.Username);
                            objStartForm = objStart;
                            objStartForm.snackBar.Show(objStartForm, $"los datos no pudieron ser actualizados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                        }
                    }
                    else if (objUpdatePermission.cmbTypePermission.Text == "Paternidad")
                    {
                        DaoInsert.EmployeeStatus = 4;
                        DaoInsert.IdEmployee = int.Parse(objUpdatePermission.txtIdEmployee.Text.Trim());
                        int returnedValue = DaoInsert.UpdateStatusEmployee();
                        if (returnedValue == 1)
                        {
                            StartMenu objStart = new StartMenu(SessionVar.Username);
                            objStartForm = objStart;
                            objStartForm.snackBar.Show(objStartForm, $"El empleado fue actualizado extosamente, iniciando su periodo de paternidad", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

                        }
                        else
                        {
                            objUpdatePermission.bunifuSnackbar1.Show(objUpdatePermission, $"los datos no pudieron ser actualizados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                        }
                    }
                    daoUpdate.Start = objUpdatePermission.dtpStart.Value;
                    daoUpdate.End = objUpdatePermission.dtpEnd.Value;
                    daoUpdate.Context = objUpdatePermission.rtxtContext.Text.Trim();
                    daoUpdate.IdEmployee = int.Parse(objUpdatePermission.txtIdEmployee.Text.Trim());
                    daoUpdate.IdPermission = int.Parse(objUpdatePermission.txtIdPermission.Text.Trim());
                    daoUpdate.IdStatusPermission = (int)objUpdatePermission.cmbStatusPermission.SelectedValue;
                    daoUpdate.IdTypePermission = (int)objUpdatePermission.cmbTypePermission.SelectedValue;
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
            objUpdatePermission.cmbTypePermission.SelectedValue = idType;


            DataSet dsStatusPermission = daoPermission.GetStatusPermission();
            objUpdatePermission.cmbStatusPermission.DataSource = dsStatusPermission.Tables["tbStatusPermission"];
            objUpdatePermission.cmbStatusPermission.DisplayMember = "statusPermission";
            objUpdatePermission.cmbStatusPermission.ValueMember = "IdStatusPermission";
            objUpdatePermission.cmbStatusPermission.SelectedValue = idStatus;
        }
        public void ChargeValues(int idEmployee, int idPermission, DateTime start, DateTime end, string context, string status, string typeP, int idType, int idStatus)
        {
            try
            {
                objUpdatePermission.txtIdEmployee.Text = idEmployee.ToString();
                objUpdatePermission.txtIdPermission.Text = idPermission.ToString();
                objUpdatePermission.dtpStart.Value = start;
                objUpdatePermission.dtpEnd.Value = end;
                objUpdatePermission.rtxtContext.Text = context.ToString();
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
        public void idNum(object sender, EventArgs e)
        {
            int cursorPosition = objUpdatePermission.txtIdEmployee.SelectionStart;
            string text = new string(objUpdatePermission.txtIdEmployee.Text.Where(c => char.IsDigit(c)).ToArray());
            objUpdatePermission.txtIdEmployee.Text = text;
            objUpdatePermission.txtIdEmployee.SelectionStart = cursorPosition;
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
