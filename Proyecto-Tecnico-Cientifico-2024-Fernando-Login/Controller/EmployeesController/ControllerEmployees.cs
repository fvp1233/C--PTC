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
using PTC2024.View.EmployeeViews;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            objEmployees.cmsEmployeeInformation.Click += new EventHandler(ViewEmployeeInfo);
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
            objEmployees.dgvEmployees.Columns[9].Visible = false;
            objEmployees.dgvEmployees.Columns[10].Visible = false;
            objEmployees.dgvEmployees.Columns[11].Visible = false;
            objEmployees.dgvEmployees.Columns[12].Visible = false;
            objEmployees.dgvEmployees.Columns[14].Visible = false;
            objEmployees.dgvEmployees.Columns[15].Visible = false;
            objEmployees.dgvEmployees.Columns[18].Visible = false;
        }
        public void ViewEmployeeInfo(object sender, EventArgs e)
        {
            int row = objEmployees.dgvEmployees.CurrentRow.Index;

            int affiliationNumber;
            string names, lastNames, dui, adress, phone, email, maritalStatus, typeEmployee, statusEmployee, bankAccount, username, businessP, department, bank;
            DateTime birthDate, hireDate;
            double salary;

            //Asignación de valores a la variables que se colocaran en los textbox del formulario.
            names = objEmployees.dgvEmployees[1, row].Value.ToString();
            lastNames = objEmployees.dgvEmployees[2, row].Value.ToString();
            dui = objEmployees.dgvEmployees[3, row].Value.ToString();
            birthDate = DateTime.Parse(objEmployees.dgvEmployees[4, row].Value.ToString());
            adress = objEmployees.dgvEmployees[7, row].Value.ToString();
            phone = objEmployees.dgvEmployees[6, row].Value.ToString();
            email = objEmployees.dgvEmployees[5, row].Value.ToString();
            hireDate = DateTime.Parse(objEmployees.dgvEmployees[12, row].Value.ToString());
            maritalStatus = objEmployees.dgvEmployees[15, row].Value.ToString();
            typeEmployee = objEmployees.dgvEmployees[14, row].Value.ToString();
            statusEmployee = objEmployees.dgvEmployees[16, row].Value.ToString();
            salary = double.Parse(objEmployees.dgvEmployees[8, row].Value.ToString());
            affiliationNumber = int.Parse(objEmployees.dgvEmployees[11, row].Value.ToString());
            bankAccount = objEmployees.dgvEmployees[9, row].Value.ToString();
            username = objEmployees.dgvEmployees[17, row].Value.ToString();
            businessP = objEmployees.dgvEmployees[19, row].Value.ToString();
            department = objEmployees.dgvEmployees[13, row].Value.ToString();
            bank = objEmployees.dgvEmployees[10, row].Value.ToString();

            //Se crea instancia del formulario para abrirlo
            FrmInfoEmployee openForm = new FrmInfoEmployee(names, lastNames, dui, birthDate, adress, phone, email, hireDate, maritalStatus, typeEmployee, statusEmployee, salary, affiliationNumber, bankAccount, username, businessP, department, bank);
            openForm.ShowDialog();
            RefreshDataGridEmployees();
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
            //Se crea una variable para saber la fila del empleado al que se le dio click
            int row = objEmployees.dgvEmployees.CurrentRow.Index;
            //se manda a llamar al formulario para la actualización de empleados por medio de un objeto con los parámetros necesarios.
            FrmUpdateEmployee abrirfForm = new FrmUpdateEmployee(
                int.Parse(objEmployees.dgvEmployees[0, row].Value.ToString()),
                objEmployees.dgvEmployees[1, row].Value.ToString(),
                objEmployees.dgvEmployees[2, row].Value.ToString(),
                objEmployees.dgvEmployees[3, row].Value.ToString(),
                DateTime.Parse(objEmployees.dgvEmployees[4, row].Value.ToString()),
                objEmployees.dgvEmployees[5, row].Value.ToString(),
                objEmployees.dgvEmployees[6, row].Value.ToString(),
                objEmployees.dgvEmployees[7, row].Value.ToString(),
                double.Parse(objEmployees.dgvEmployees[8, row].Value.ToString()),
                objEmployees.dgvEmployees[9, row].Value.ToString(),
                objEmployees.dgvEmployees[10, row].Value.ToString(),
                int.Parse(objEmployees.dgvEmployees[11, row].Value.ToString()),
                DateTime.Parse(objEmployees.dgvEmployees[12, row].Value.ToString()),
                objEmployees.dgvEmployees[13, row].Value.ToString(),
                objEmployees.dgvEmployees[14, row].Value.ToString(),
                objEmployees.dgvEmployees[15, row].Value.ToString(),
                objEmployees.dgvEmployees[16, row].Value.ToString(),
                objEmployees.dgvEmployees[17, row].Value.ToString(),
                objEmployees.dgvEmployees[19, row].Value.ToString()
                );
            abrirfForm.ShowDialog();
            RefreshDataGridEmployees();
        }

        public void DisableEmployee(object sender, EventArgs e)
        {
            //Se declara la variable row, que va a guardar el número de la fila del registro escogido para eliminar
            int row = objEmployees.dgvEmployees.CurrentRow.Index;

            //Creamos un objeto del formulario que servirá para confirmar la accion de eliminar - 
            FrmDeleteAlert openDeleteAlert = new FrmDeleteAlert();
            //Creamos una instancia del controlador del formulario que usaremos para confirmar la acción a partir de un valor int que este nos va enviar. 
            ControllerDeleteAlert objControllerDeleteAlert = new ControllerDeleteAlert(openDeleteAlert);
            openDeleteAlert.FormBorderStyle = FormBorderStyle.None;
            openDeleteAlert.ShowDialog();
            //Evaluamos la respuesta que nos envió el formulario despues de presionar uno de los botones 
            if (objControllerDeleteAlert.ConfirmValue == 1)
            {
                //Creamos un objeto de la clase DAOEmployees 
                DAOEmployees daoEmployees = new DAOEmployees();
                //Le damos valor al getter IdEmployee 
                daoEmployees.Username = objEmployees.dgvEmployees[17, row].Value.ToString();
                //Mandamos a llamar el proceso de la eliminación de empleado del DAOEmployees para evaluar el valor que el metodo nos retorna 
                int value = daoEmployees.DisableEmployee();
                if (value == 1)
                {
                    openDeleteAlert.Close();
                    MessageBox.Show("El empleado fue deshabilitado junto a su usuario de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    openDeleteAlert.Close();
                    MessageBox.Show("Ocurrió un error, el empleado no pudo ser deshabilitado", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #region disable con messagebox de windows
            //if (MessageBox.Show($"Esta seguro que desea eliminar a:\n {objEmployees.dgvEmployees[1, row].Value.ToString()}. \n Esta acción no puede ser revertida. ", "Confirme su acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    DAOEmployees daoEmployees = new DAOEmployees();
            //    daoEmployees.Username = objEmployees.dgvEmployees[16, row].Value.ToString();
            //    int value = daoEmployees.DisableEmployee();
            //    if (value == 1)
            //    {
            //        MessageBox.Show("El empleado fue deshabilitado de manera exitosa", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Ocurrió un error, el empleado no pudo ser deshabilitado", "Proceso fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            #endregion
            RefreshDataGridEmployees();
        }
    }
}
