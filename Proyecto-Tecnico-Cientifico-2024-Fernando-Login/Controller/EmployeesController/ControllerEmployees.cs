using PTC2024.Model.DAO.EmployeesDAO;
using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            objEmployees.cmsDeleteEmployee.Click += new EventHandler(DeleteEmployee);
        }

        public void LoadData (object sender, EventArgs e)
        {
            RefreshDataGridEmployees();
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

        public void DeleteEmployee(object sender, EventArgs e)
        {
            RefreshDataGridEmployees();
        }
    }
}
