using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< Updated upstream
using PTC2024.View.Clientes;
using PTC2024.View.Empleados;

namespace PTC2024.Controller.CustomersController
{ }
    /*internal class ControllerCustomers
    {
        FrmCustomers objCustomers;
    

         public ControllerCustomers(FrmCustomers Vista)
        {
            objCustomers = Vista;
            //Cargar el datagridview
            objCustomers.Load += new EventHandler(LoadData);
            //eventos al hacer click
            objCustomers.BtnAddCustomer.Click += new EventHandler(NewCustomer);
            objCustomers.cmsCustomers.Click += new EventHandler(UpdateCustomer);

        }

        public void LoadData(object sender, EventArgs e)
        {
            RefreshDataGridEmployees();
        }

        public void NewCustomer(object sender, EventArgs e)
        {
            //Creando objeto del formulario FrmAddEmployee
            FrmAddCustomers abrirForm = new FrmAddCustomers();
            abrirForm.ShowDialog();
            RefreshDataGridEmployees();
        }

        public void UpdateCustomer(object sender, EventArgs e)
        {
            //Se crea una variable para saber la fila del empleado al que se le dio click
            int row = objCustomers.dtgCustomers.CurrentRow.Index;
            //se manda a llamar al formulario para la actualización de empleados por medio de un objeto con los parámetros necesarios.
            FrmUploadCustomers abrirfForm = new FrmUploadCustomers(
                int.Parse(objCustomers.dtgCustomers[0, row].Value.ToString()),
                objCustomers.dtgCustomers[1, row].Value.ToString(),
                objCustomers.dtgCustomers[2, row].Value.ToString(),
                objCustomers.dtgCustomers[3, row].Value.ToString(),
                DateTime.Parse(objCustomers.dtgCustomers[4, row].Value.ToString()),
                objCustomers.dtgCustomers[5, row].Value.ToString(),
                objCustomers.dtgCustomers[6, row].Value.ToString(),
                objCustomers.dtgCustomers[7, row].Value.ToString(),
                double.Parse(objCustomers.dtgCustomers[8, row].Value.ToString()),
                
                );
            abrirfForm.ShowDialog();
            RefreshDataGridEmployees();
        }
    }
}
        */
=======

namespace PTC2024.Controller.CustomersController
{
    internal class ControllerCustomers
    {
    }
}
>>>>>>> Stashed changes
