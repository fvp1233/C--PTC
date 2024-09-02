using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.EmployeeViews;
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

        }
        public void FillDropdown(object sender, EventArgs e)
        {
            DAOAddPermission daoddPermission = new DAOAddPermission();

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
                DAOAddPermission DaoInsert = new DAOAddPermission();
                if (objAddPermission.dtpStart.Value >= DateTime.Now && objAddPermission.dtpEnd.Value >= objAddPermission.dtpStart.Value)
                {
                    DaoInsert.Start = objAddPermission.dtpStart.Value.Date;
                    DaoInsert.End = objAddPermission.dtpEnd.Value.Date;
                    DaoInsert.Context = objAddPermission.rtxtContext.Text.Trim();
                    DaoInsert.IdEmployee = int.Parse(objAddPermission.txtIdEmployee.Text.Trim());
                    DaoInsert.IdStatusPermission = int.Parse(objAddPermission.cmbStatusPermission.SelectedValue.ToString());
                    if(objAddPermission.cmbTypePermission.Text == "Maternidad")
                    {
                        DaoInsert.EmployeeStatus = 3;
                        DaoInsert.IdEmployee = int.Parse(objAddPermission.txtIdEmployee.Text.Trim());
                        int returnedValues = DaoInsert.UpdateStatusEmployee();
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
                    else if (objAddPermission.cmbTypePermission.Text == "Paternidad")
                    {
                        DaoInsert.EmployeeStatus = 4;
                        DaoInsert.IdEmployee = int.Parse(objAddPermission.txtIdEmployee.Text.Trim());
                        int returnedValues = DaoInsert.UpdateStatusEmployee();
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
                    DaoInsert.IdTypePermission = int.Parse(objAddPermission.cmbTypePermission.SelectedValue.ToString());
                    int returnedValue = DaoInsert.InsertPermission();
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
                    Close();
                }
                else
                {
                    MessageBox.Show("La fecha ingresada no puede ser de un día anterior",
                  "Fecha inválida",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios, llene todos los apartados.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show("No se encontró un empleado con el ID proporcionado.",
                                        "Empleado no encontrado",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un ID de empleado válido.",
                                    "ID inválido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
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
