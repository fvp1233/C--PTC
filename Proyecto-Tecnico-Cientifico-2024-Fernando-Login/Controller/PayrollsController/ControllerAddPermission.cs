using PTC2024.Controller.Helper;
using PTC2024.Model.DAO.HelperDAO;
using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.Resources.Language;
using PTC2024.View.EmployeeViews;
using PTC2024.View.formularios.inicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.PayrollsController
{
    internal class ControllerAddPermission
    {
        FrmAddPermission objAddPermission;
        StartMenu objStartForm;

        public ControllerAddPermission(FrmAddPermission View)
        {
            objAddPermission = View;
            objAddPermission.Load += new EventHandler(FillDropdown);
            objAddPermission.cmbTypePermission.SelectedIndexChanged += new EventHandler(cmbTypePermission_SelectedIndexChangedM);
            objAddPermission.cmbTypePermission.SelectedIndexChanged += new EventHandler(cmbTypePermission_SelectedIndexChangedP);
            objAddPermission.btnAddPermission.Click += new EventHandler(AddPermission);
            objAddPermission.btnCancel.Click += new EventHandler(CloseForm);
            objAddPermission.rtxtContext.KeyDown += new KeyEventHandler(pasteContext);
            objAddPermission.txtIdEmployee.KeyDown += new KeyEventHandler(pasteDisabledNames);
            objAddPermission.txtIdEmployee.Leave += new EventHandler(LoadEmployeeName);
            objAddPermission.txtIdEmployee.MouseDown += new MouseEventHandler(DisableContextMenu);
            objAddPermission.txtIdEmployee.TextChanged += new EventHandler(idNum);
            objAddPermission.rtxtContext.MouseDown += new MouseEventHandler(DisableContextMenu);

        }
        public void ChargeLanguage()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            EnglishL();
        }
        public void EnglishL()
        {
            objAddPermission.lblTitle.Text = English.addPermission;
            objAddPermission.lblSubtitle.Text = English.addSubTitleP;
            objAddPermission.bunifuGroupBox1.Text = English.permissionBox;
            objAddPermission.IdEmployee.Text = English.employeeId;
            objAddPermission.lblTypeP.Text = English.typePermission;
            objAddPermission.lblStatusP.Text = English.permissionStatus;
            objAddPermission.lblStart.Text = English.start;
            objAddPermission.lblEnd.Text = English.end;
            objAddPermission.lblContext.Text = English.reason;
            objAddPermission.lblEmployeeInfo.Text = English.employeForWhom;
            objAddPermission.btnCancel.Text = English.gobackForm;
            objAddPermission.btnAddPermission.Text = English.add;
        }
        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }
        public void idNum(object sender, EventArgs e)
        {
            int cursorPosition = objAddPermission.txtIdEmployee.SelectionStart;
            string text = new string(objAddPermission.txtIdEmployee.Text.Where(c => char.IsDigit(c)).ToArray());
            objAddPermission.txtIdEmployee.Text = text;
            objAddPermission.txtIdEmployee.SelectionStart = cursorPosition;
        }
        public void FillDropdown(object sender, EventArgs e)
        {
            DAOAddPermission daoddPermission = new DAOAddPermission();
            ChargeLanguage();
            DataSet dsTypePermission = daoddPermission.GetTypePermission();
            objAddPermission.cmbTypePermission.DataSource = dsTypePermission.Tables["tbTypePermission"];
            objAddPermission.cmbTypePermission.DisplayMember = "typePermisiion";
            objAddPermission.cmbTypePermission.ValueMember = "IdTypePermission";

            DataSet dsStatusPermission = daoddPermission.GetStatusPermission();
            objAddPermission.cmbStatusPermission.DataSource = dsStatusPermission.Tables["tbStatusPermission"];
            objAddPermission.cmbStatusPermission.DisplayMember = "statusPermission";
            objAddPermission.cmbStatusPermission.ValueMember = "IdStatusPermission";
        }
        public void AddPermission(object sender, EventArgs e)
        {

            if (!(string.IsNullOrEmpty(objAddPermission.rtxtContext.Text.Trim()) || string.IsNullOrEmpty(objAddPermission.txtIdEmployee.Text.Trim())))
            {
                if (int.TryParse(objAddPermission.txtIdEmployee.Text, out _))
                {
                    DAOAddPermission DaoInsert = new DAOAddPermission();
                    int employeeId = int.Parse(objAddPermission.txtIdEmployee.Text.Trim());
                    DaoInsert.IdEmployee = employeeId;

                    DataSet ds = DaoInsert.GetEmployeeGender();

                    if (ds != null && ds.Tables["tbEmployee"].Rows.Count > 0)
                    {
                        int idGender = Convert.ToInt32(ds.Tables["tbEmployee"].Rows[0]["IdGender"]);

                        // Asumiendo que IdGender = 1 es Masculino y IdGender = 2 es Femenino.
                        if (idGender == 1 && objAddPermission.cmbTypePermission.Text == "Maternidad")
                        {
                            objAddPermission.bunifuSnackbar1.Show(objAddPermission, "No se puede asignar un permiso de maternidad a un empleado masculino.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                            return;
                        }
                        else if (idGender == 2 && objAddPermission.cmbTypePermission.Text == "Paternidad")
                        {
                            objAddPermission.bunifuSnackbar1.Show(objAddPermission, "No se puede asignar un permiso de paternidad a una empleada femenina.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                            return;
                        }

                        if (objAddPermission.dtpStart.Value >= DateTime.Now && objAddPermission.dtpEnd.Value >= objAddPermission.dtpStart.Value)
                        {
                            DaoInsert.Start = objAddPermission.dtpStart.Value.Date;
                            DaoInsert.End = objAddPermission.dtpEnd.Value.Date;
                            DaoInsert.Context = objAddPermission.rtxtContext.Text.Trim();
                            DaoInsert.IdEmployee = employeeId;
                            DaoInsert.IdStatusPermission = int.Parse(objAddPermission.cmbStatusPermission.SelectedValue.ToString());

                            if (objAddPermission.cmbTypePermission.Text == "Maternidad")
                            {
                                DaoInsert.EmployeeStatus = 3;
                                DaoInsert.IdEmployee = int.Parse(objAddPermission.txtIdEmployee.Text.Trim());
                                int returnedValues = DaoInsert.UpdateStatusEmployee();
                                if (returnedValues == 1)
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
                            else if (objAddPermission.cmbTypePermission.Text == "Paternidad")
                            {
                                DaoInsert.EmployeeStatus = 4;
                                DaoInsert.IdEmployee = int.Parse(objAddPermission.txtIdEmployee.Text.Trim());
                                int returnedValues = DaoInsert.UpdateStatusEmployee();
                                if (returnedValues == 1)
                                {
                                    StartMenu objStart = new StartMenu(SessionVar.Username);
                                    objStartForm = objStart;
                                    objStartForm.snackBar.Show(objStartForm, $"El empleado fue actualizado extosamente, iniciando su periodo de paternidad", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                                    DAOInitialView daoInitial = new DAOInitialView();
                                    daoInitial.ActionType = "Se agregó un permiso";
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
                                    objAddPermission.bunifuSnackbar1.Show(objAddPermission, $"los datos no pudieron ser actualizados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                                }
                            }
                            else if (objAddPermission.cmbTypePermission.Text == "Incapacidad")
                            {
                                DaoInsert.EmployeeStatus = 4;
                                DaoInsert.IdEmployee = int.Parse(objAddPermission.txtIdEmployee.Text.Trim());
                                int returnedValues = DaoInsert.UpdateStatusEmployee();
                                if (returnedValues == 1)
                                {
                                    StartMenu objStart = new StartMenu(SessionVar.Username);
                                    objStartForm = objStart;
                                    objStartForm.snackBar.Show(objStartForm, $"El empleado fue actualizado extosamente, iniciando su periodo de paternidad", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

                                }
                                else
                                {
                                    objAddPermission.bunifuSnackbar1.Show(objAddPermission, $"los datos no pudieron ser actualizados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                                }
                            }
                            DaoInsert.IdTypePermission = int.Parse(objAddPermission.cmbTypePermission.SelectedValue.ToString());
                            int returnedValue = DaoInsert.InsertPermission();
                            if (returnedValue == 1)
                            {
                                StartMenu objStart = new StartMenu(SessionVar.Username);
                                objStartForm = objStart;
                                objStartForm.snackBar.Show(objStartForm, $"El permiso fue registrado exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);
                            }
                            else
                            {
                                StartMenu objStart = new StartMenu(SessionVar.Username);
                                objStartForm = objStart;
                                objStartForm.snackBar.Show(objStartForm, $"El permiso no pudo ser registrado", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopRight);

                            }
                            Close();
                        }
                        else
                        {
                            objAddPermission.bunifuSnackbar1.Show(objAddPermission, $"la fecha ingresada no puede ser de un dia enterior", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);

                        }
                    }
                    else
                    {
                        objAddPermission.bunifuSnackbar1.Show(objAddPermission, $"Favor ingresar un valor numerico", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                    }
                }
            }
            else
            {
                objAddPermission.bunifuSnackbar1.Show(objAddPermission, $"Todos los campos son obligatorios, favor llenar todos los campos", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }

        }
        public void LoadEmployeeName(object sender, EventArgs e)
        {
            string employeeIdText = objAddPermission.txtIdEmployee.Text.Trim();
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
                        objAddPermission.lblEmployeeName.Text = employeeName;
                    }
                    else
                    {
                        objAddPermission.bunifuSnackbar1.Show(objAddPermission, $"No se encontro al empleado con el ID proporcionado", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                    }
                }
                else
                {
                    objAddPermission.bunifuSnackbar1.Show(objAddPermission, $"Favor ingresar un ID de empelado valido", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                }
            }
        }

        private void cmbTypePermission_SelectedIndexChangedM(object sender, EventArgs e)
        {
            if (objAddPermission.cmbTypePermission.SelectedItem != null)
            {
                // Verifica si se seleccionó "Maternidad"
                if (objAddPermission.cmbTypePermission.Text == "Maternidad")
                {
                    // Sumar 112 días a la fecha seleccionada en dtpStart
                    objAddPermission.dtpStart.ValueChanged += dtpStart_ValueChangedM;
                }
                else
                {
                    // Remover el evento si no es "Maternidad"
                    objAddPermission.dtpStart.ValueChanged -= dtpStart_ValueChangedM;
                }
            }
        }

        public void dtpStart_ValueChangedM(object sender, EventArgs e)
        {
            // Sumar 112 días a la fecha de inicio seleccionada y asignarla a dtpEnd
            objAddPermission.dtpEnd.Value = objAddPermission.dtpStart.Value.AddDays(112);
        }
        public void cmbTypePermission_SelectedIndexChangedP(object sender, EventArgs e)
        {
            if (objAddPermission.cmbTypePermission.SelectedItem != null)
            {
                // Verifica si se seleccionó "Maternidad"
                if (objAddPermission.cmbTypePermission.Text == "Paternidad")
                {
                    // Sumar 112 días a la fecha seleccionada en dtpStart
                    objAddPermission.dtpStart.ValueChanged += dtpStart_ValueChangedP;
                }
                else
                {
                    // Remover el evento si no es "Maternidad"
                    objAddPermission.dtpStart.ValueChanged -= dtpStart_ValueChangedP;
                }
            }
        }

        public void dtpStart_ValueChangedP(object sender, EventArgs e)
        {
            // Sumar 112 días a la fecha de inicio seleccionada y asignarla a dtpEnd
            objAddPermission.dtpEnd.Value = objAddPermission.dtpStart.Value.AddDays(3);
        }
        public void Close()
        {
            objAddPermission.Close();

        }
        public void CloseForm(object sender, EventArgs e)
        {
            Close();
        }
        private void pasteDisabledNames(object sender, KeyEventArgs e)
        {
            // Verifica si se está presionando Ctrl+C o Ctrl+V
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                // Cancela la operación
                e.SuppressKeyPress = true;
            }
        }
        public void pasteContext(object sender, KeyEventArgs e)
        {
            // Verifica si se está presionando Ctrl+C o Ctrl+V
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                // Cancela la operación
                e.SuppressKeyPress = true;
            }
        }
    }
}
