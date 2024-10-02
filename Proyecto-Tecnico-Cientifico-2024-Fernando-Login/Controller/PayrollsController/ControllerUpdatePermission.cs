using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.HelperDAO;
using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.Resources.Language;
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
            objUpdatePermission.Load += new EventHandler(LoadEmployeeName);
            objUpdatePermission.btnAddPermission.Click += new EventHandler(UpdatePermission);
            objUpdatePermission.txtIdEmployee.TextChanged += new EventHandler(idNum);
            objUpdatePermission.txtIdEmployee.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdatePermission.rtxtContext.MouseDown += new MouseEventHandler(DisableContextMenu);
            objUpdatePermission.txtIdEmployee.Leave += new EventHandler(LoadEmployeeName);
            objUpdatePermission.btnCancel.Click += new EventHandler(CloseForm);
            objUpdatePermission.cmbTypePermission.SelectedIndexChanged += new EventHandler(cmbTypePermission_SelectedIndexChangedM);
            objUpdatePermission.cmbTypePermission.SelectedIndexChanged += new EventHandler(cmbTypePermission_SelectedIndexChangedP);
        }
        public void ChargeLanguage()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            EnglishL();
        }
        public void EnglishL()
        {
            objUpdatePermission.lblTitle.Text = English.updatePermissionS;
            objUpdatePermission.lblSubtitle.Text = English.updateSubTitleP;
            objUpdatePermission.bunifuGroupBox1.Text = English.permissionBox;
            objUpdatePermission.IdEmployee.Text = English.employeeId;
            objUpdatePermission.lblTypeP.Text = English.typePermission;
            objUpdatePermission.lblStatusP.Text = English.permissionStatus;
            objUpdatePermission.lblStart.Text = English.start;
            objUpdatePermission.lblEnd.Text = English.end;
            objUpdatePermission.lblContext.Text = English.reason;
            objUpdatePermission.lblEmployeeInfo.Text = English.employeForWhom;
            objUpdatePermission.btnCancel.Text = English.gobackForm;
            objUpdatePermission.btnAddPermission.Text = English.add;
        }
        public void UpdatePermission(object sender, EventArgs e)
        {
            try
            {
                DAOUpdatePermission daoUpdate = new DAOUpdatePermission();
                DAOAddPermission DaoInsert = new DAOAddPermission();
                int employeeId = int.Parse(objUpdatePermission.txtIdEmployee.Text.Trim());
                DaoInsert.IdEmployee = employeeId;
                DataSet ds = DaoInsert.GetEmployeeGender();

                if (ds != null && ds.Tables.Contains("tbEmployee") && ds.Tables["tbEmployee"].Rows.Count > 0)
                {
                    int idGender = Convert.ToInt32(ds.Tables["tbEmployee"].Rows[0]["IdGender"]);

                    // Asumiendo que IdGender = 1 es Masculino y IdGender = 2 es Femenino.
                    if (idGender == 1 && objUpdatePermission.cmbTypePermission.Text == "Maternidad")
                    {
                        objUpdatePermission.bunifuSnackbar1.Show(objUpdatePermission, "No se puede asignar un permiso de maternidad a un empleado masculino.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                        return;
                    }
                    else if (idGender == 2 && objUpdatePermission.cmbTypePermission.Text == "Paternidad")
                    {
                        objUpdatePermission.bunifuSnackbar1.Show(objUpdatePermission, "No se puede asignar un permiso de paternidad a una empleada femenina.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                        return;
                    }
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
                        DAOInitialView daoInitial = new DAOInitialView();
                        daoInitial.ActionType = "Se actualizó un permiso";
                        daoInitial.TableName = "Permisos";
                        daoInitial.ActionBy = SessionVar.Username;
                        daoInitial.ActionDate = DateTime.Now;
                        int auditAnswer = daoInitial.InsertAudit();
                        if (auditAnswer != 1)
                        {
                            objStartForm.snackBar.Show(objStartForm, $"La auditoria no pudo ser registrada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                        }

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
                        DAOInitialView daoInitial = new DAOInitialView();
                        daoInitial.ActionType = "Se actualizo un empleado";
                        daoInitial.TableName = "tbEmployee";
                        daoInitial.ActionBy = SessionVar.Username;
                        daoInitial.ActionDate = DateTime.Now;
                        int auditAnswer = daoInitial.InsertAudit();
                        if (auditAnswer != 1)
                        {
                            objStartForm.snackBar.Show(objStartForm, $"La auditoria no pudo ser registrada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                        }

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
                    DAOInitialView daoInitial = new DAOInitialView();
                    daoInitial.ActionType = "Se actualizo un permiso";
                    daoInitial.TableName = "tbPermission";
                    daoInitial.ActionBy = SessionVar.Username;
                    daoInitial.ActionDate = DateTime.Now;
                    int auditAnswer = daoInitial.InsertAudit();
                    if (auditAnswer != 1)
                    {
                        objStartForm.snackBar.Show(objStartForm, $"La auditoria no pudo ser registrada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
                    }
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
            ChargeLanguage();
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
        public void LoadEmployeeName(object sender, EventArgs e)
        {
            string employeeIdText = objUpdatePermission.txtIdEmployee.Text.Trim();
            if (!string.IsNullOrEmpty(employeeIdText))
            {
                int employeeId;
                if (int.TryParse(employeeIdText, out employeeId))
                {
                    DAOAddPermission dao = new DAOAddPermission();
                    dao.IdEmployee = employeeId;
                    DataSet ds = dao.GetEmployeeName();

                    if (ds != null && ds.Tables["viewEmployees"].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables["viewEmployees"].Rows[0];
                        string employeeName = row["Nombre Completo"].ToString();
                        objUpdatePermission.lblId.Text = employeeName;
                    }
                    else
                    {
                        objUpdatePermission.bunifuSnackbar1.Show(objUpdatePermission, $"No se encontro al empleado con el ID proporcionado", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                    }
                }
                else
                {
                    objUpdatePermission.bunifuSnackbar1.Show(objUpdatePermission, $"Favor ingresar un ID de empelado valido", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                }
            }
        }
        private void cmbTypePermission_SelectedIndexChangedM(object sender, EventArgs e)
        {
            if (objUpdatePermission.cmbTypePermission.SelectedItem != null)
            {
                // Verifica si se seleccionó "Maternidad"
                if (objUpdatePermission.cmbTypePermission.Text == "Maternidad")
                {
                    // Sumar 112 días a la fecha seleccionada en dtpStart
                    objUpdatePermission.dtpStart.ValueChanged += dtpStart_ValueChangedM;
                }
                else
                {
                    // Remover el evento si no es "Maternidad"
                    objUpdatePermission.dtpStart.ValueChanged -= dtpStart_ValueChangedM;
                }
            }
        }

        public void dtpStart_ValueChangedM(object sender, EventArgs e)
        {
            // Sumar 112 días a la fecha de inicio seleccionada y asignarla a dtpEnd
            objUpdatePermission.dtpEnd.Value = objUpdatePermission.dtpStart.Value.AddDays(112);
        }
        public void cmbTypePermission_SelectedIndexChangedP(object sender, EventArgs e)
        {
            if (objUpdatePermission.cmbTypePermission.SelectedItem != null)
            {
                // Verifica si se seleccionó "Maternidad"
                if (objUpdatePermission.cmbTypePermission.Text == "Paternidad")
                {
                    // Sumar 112 días a la fecha seleccionada en dtpStart
                    objUpdatePermission.dtpStart.ValueChanged += dtpStart_ValueChangedP;
                }
                else
                {
                    // Remover el evento si no es "Maternidad"
                    objUpdatePermission.dtpStart.ValueChanged -= dtpStart_ValueChangedP;
                }
            }
        }

        public void dtpStart_ValueChangedP(object sender, EventArgs e)
        {
            // Sumar 112 días a la fecha de inicio seleccionada y asignarla a dtpEnd
            objUpdatePermission.dtpEnd.Value = objUpdatePermission.dtpStart.Value.AddDays(3);
        }
    }
}
