using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
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
            objEmployees.Load += new EventHandler(LoadDataGridEmployees);
            objEmployees.BtnAddEmployee.Click += new EventHandler(NewEmployee);
            objEmployees.cmsUpdateEmployee.Click += new EventHandler(UpdateEmployee);
            //Eventos de click de botones
            //objEmployees.BtnAgregarEmpleado.Click += new EventHandler(NuevoEmpleado);
        }

        public void LoadDataGridEmployees(object sender, EventArgs e)
        {

        }

        public void NewEmployee(object sender, EventArgs e)
        {
            //Creando objeto del formulario FrmAddEmployee
            FrmAddEmployee abrirForm = new FrmAddEmployee();
            abrirForm.ShowDialog();
        }

        public void UpdateEmployee(object sender, EventArgs e) 
        {
            FrmUpdateEmployee abrirfForm = new FrmUpdateEmployee();
            abrirfForm.ShowDialog();
        }
    }
}
