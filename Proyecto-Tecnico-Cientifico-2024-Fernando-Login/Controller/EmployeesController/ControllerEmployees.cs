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
            objEmployees.Load += new EventHandler(CargarDataGridEmpleados);
            objEmployees.btnAgregarEmpleado.Click += new EventHandler(NuevoEmpleado);
            //Eventos de click de botones
            //objEmployees.BtnAgregarEmpleado.Click += new EventHandler(NuevoEmpleado);
        }

        public void CargarDataGridEmpleados(object sender, EventArgs e)
        {

        }

        public void NuevoEmpleado(object sender, EventArgs e)
        {
            //Creando objeto del formulario FrmAddEmployee
            FrmAddEmployee abrirForm = new FrmAddEmployee();
            abrirForm.ShowDialog();
        }
    }
}
