using PTC2024.Model.DAO.MaintenanceDAO;
using PTC2024.View.Dashboard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.MaintenanceController
{
    internal class ControllerDepartments
    {
        FrmDepartments objDep;
        public ControllerDepartments(FrmDepartments View)
        {
            objDep = View;
            objDep.Load += new EventHandler(LoadData);
            objDep.btnAddDepartment.Click += new EventHandler(NewDepartment);
            objDep.cmsDeleteDepartment.Click += new EventHandler(DeleteDepartment);
            objDep.btnGoBack.Click += new EventHandler(GoBack);
            objDep.txtDepartment.TextChanged += new EventHandler(OnlyLettersName);
            objDep.txtDepartment.MouseDown += new MouseEventHandler(DisableContextMenu);
        }
        public void NewDepartment(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(objDep.txtDepartment.Text.Trim())))
            {
                DAODepartment DAOInsert = new DAODepartment();
                DAOInsert.Department = objDep.txtDepartment.Text.Trim();
                int returnedValue = DAOInsert.AddDepartment();
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
            else
            {
                MessageBox.Show("Existen campos vacíos, complete cada uno de los apartados.",
                    "Proceso interrumpido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            RefreshData();
            objDep.txtDepartment.Clear();
        }
        public void DeleteDepartment(object sender, EventArgs e)
        {
            DAODepartment dAODepartment = new DAODepartment();
            int pos = objDep.dgvDepartments.CurrentRow.Index;

            int idDepart = int.Parse(objDep.dgvDepartments[0, pos].Value.ToString());

            if (MessageBox.Show("Estas seguro de borrar los datos, esta accion no se puede revertir", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                dAODepartment.IdDepartment = int.Parse(objDep.dgvDepartments[0, pos].Value.ToString());
                int answer = dAODepartment.DeleteDepartment();
                if (answer == 1)
                {
                    MessageBox.Show("Los datos se eliminaron correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    objDep.snack.Show(objDep, "Este departamento no se puede eliminar debido a que un empleado pertenece a este departamento", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomCenter);
                }
            }
            RefreshData();

        }
        public void LoadData(object sender, EventArgs e)
        {
            RefreshData();
            objDep.dgvDepartments.Columns[0].Visible = false;
        }
        public void RefreshData()
        {
            DAODepartment objRefresh = new DAODepartment();
            DataSet ds = objRefresh.GetDepartmentDgv();
            objDep.dgvDepartments.DataSource = ds.Tables["tbDepartment"];
        }
        public void GoBack(object sender, EventArgs e)
        {
            objDep.Close();
        }

        private void DisableContextMenu(object sender, MouseEventArgs e)
        {
            // Desactiva el menú contextual al hacer clic derecho
            if (e.Button == MouseButtons.Right)
            {
                ((Bunifu.UI.WinForms.BunifuTextBox)sender).ContextMenu = new ContextMenu();  // Asigna un menú vacío
            }
        }

        public void OnlyLettersName(object sender, EventArgs e)
        {
            // Obtener la posición actual del cursor
            int cursorPosition = objDep.txtDepartment.SelectionStart;

            // Filtrar el texto para que solo queden letras y espacios
            string text = new string(objDep.txtDepartment.Text
                                       .Where(c => char.IsLetter(c) || char.IsWhiteSpace(c))
                                       .ToArray());

            // Actualizar el contenido del TextBox con el texto filtrado
            objDep.txtDepartment.Text = text;

            // Restaurar la posición del cursor
            objDep.txtDepartment.SelectionStart = cursorPosition;
        }
    }
}
