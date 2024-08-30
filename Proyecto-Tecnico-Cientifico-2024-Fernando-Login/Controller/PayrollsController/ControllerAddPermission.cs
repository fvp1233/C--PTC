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
            objAddPermission.btnAddPermission.Click += new EventHandler(AddPermission);
            objAddPermission.btnCancel.Click += new EventHandler(CloseForm);
            objAddPermission.rtxtContext.KeyDown += new KeyEventHandler(pasteContext);
            objAddPermission.txtIdEmployee.KeyDown += new KeyEventHandler(pasteDisabledNames);

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
                    MessageBox.Show("La fecha ingresada no puede ser de un dia anterior",
                  "Fecha invalida",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios, llene todos los apartados.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
