using PTC2024.Model.DAO.EmployeesDAO;
using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.View.Alerts;
using PTC2024.Controller.Alerts;
using System.Windows.Forms;

namespace PTC2024.Controller.Employees
{
    internal class ControllerEmployees
    {
        FrmEmployees objEmployees;

        //CONSTRUCTOR
        public ControllerEmployees(FrmEmployees Vista)
        {
            objEmployees = Vista;
            //Evento para cargar el dataGrid
            objEmployees.Load += new EventHandler(LoadData);
            //Eventos de click de botones
            objEmployees.BtnAddEmployee.Click += new EventHandler(NewEmployee);
            objEmployees.cmsUpdateEmployee.Click += new EventHandler(UpdateEmployee);
            objEmployees.cmsDeleteEmployee.Click += new EventHandler(DisableEmployee);
            objEmployees.txtEmployeeSearch.KeyPress += new KeyPressEventHandler(SearchEmployeeEvent);
        }

        public void LoadData (object sender, EventArgs e)
        {
            RefreshDataGridEmployees();
        }

        public void SearchEmployeeEvent(object sender, EventArgs e)
        {
            SearchEmployee();
        }

        public void SearchEmployee()
        {
            DAOEmployees daoEmployees = new DAOEmployees();
            DataSet ds = daoEmployees.EmployeeSearch(objEmployees.txtEmployeeSearch.Text.Trim());
            objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            if (objEmployees.txtEmployeeSearch.Text.Equals(""))
            {
                RefreshDataGridEmployees();
            }

        }

        public void RefreshDataGridEmployees()
        {
            DAOEmployees daoEmployees = new DAOEmployees();
            DataSet ds = daoEmployees.GetEmployees();
            //Llenando el datagridview
            objEmployees.dgvEmployees.DataSource = ds.Tables["viewEmployees"];
            objEmployees.dgvEmployees.Columns[0].DividerWidth = 1;
            objEmployees.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            objEmployees.dgvEmployees.Columns[4].Visible = false;
            objEmployees.dgvEmployees.Columns[10].Visible = false;
            objEmployees.dgvEmployees.Columns[13].Visible = false;
        }

        public void NewEmployee(object sender, EventArgs e)
        {
            //Creando objeto del formulario FrmAddEmployee
            FrmAddEmployee abrirForm = new FrmAddEmployee();
            abrirForm.ShowDialog();
            RefreshDataGridEmployees();
        }

        public void UpdateEmployee(object sender, EventArgs e) 
        {
            FrmUpdateEmployee abrirfForm = new FrmUpdateEmployee();
            abrirfForm.ShowDialog();
            RefreshDataGridEmployees();
        }

        public void DisableEmployee(object sender, EventArgs e)
        {
            //Se declara la variable row, que va a guardar el número de la fila del registro escogido para eliminar
            int row = objEmployees.dgvEmployees.CurrentRow.Index;
            #region Intento de usar la alerta personalizada :(
            ////Creamos un objeto del formulario que servirá para confirmar la accion de eliminar - Comentario
            //FrmDeleteAlert openDeleteAlert = new FrmDeleteAlert();
            ////Creamos una instancia del controlador del formulario que usaremos para confirmar la acción a partir de un valor int que este nos va enviar. - Comentario
            //ControllerDeleteAlert objControllerDeleteAlert = new ControllerDeleteAlert(openDeleteAlert);
            //openDeleteAlert.FormBorderStyle = FormBorderStyle.None;
            //openDeleteAlert.ShowDialog();
            ////Evaluamos la respuesta que nos envió el formulario despues de presionar uno de los botones -Comentario
            //if (objControllerDeleteAlert.ConfirmValue == 1)
            //{
            //    //Creamos un objeto de la clase DAOEmployees - Comentario
            //    DAOEmployees daoEmployees = new DAOEmployees();
            //    //Le damos valor al getter IdEmployee -Comentario
            //    daoEmployees.IdEmployee = int.Parse(objEmployees.dgvEmployees[0, row].Value.ToString());
            //    //Mandamos a llamar el proceso de la eliminación de empleado del DAOEmployees para evaluar el valor que el metodo nos retorna -Comentario
            //    int value = daoEmployees.DisableEmployee();
            //    if (value == 1)
            //    {
            //        openDeleteAlert.Close();
            //        MessageBox.Show("El empleado fue deshabilitado de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        openDeleteAlert.Close();
            //        MessageBox.Show("Ocurrió un error, el empleado no pudo ser deshabilitado", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            #endregion
            if (MessageBox.Show($"Esta seguro que desea eliminar a:\n {objEmployees.dgvEmployees[1, row].Value.ToString()}. \n Esta acción no puede ser revertida. ", "Confirme su acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOEmployees daoEmployees = new DAOEmployees();
                daoEmployees.IdEmployee = int.Parse(objEmployees.dgvEmployees[0, row].Value.ToString());
                int value = daoEmployees.DisableEmployee();
                if (value == 1)
                {
                    MessageBox.Show("El empleado fue deshabilitado de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error, el empleado no pudo ser deshabilitado", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            RefreshDataGridEmployees();
        }
    }
}
