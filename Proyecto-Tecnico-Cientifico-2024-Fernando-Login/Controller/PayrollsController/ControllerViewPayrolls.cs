using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Controller.EmployeesController
{
    internal class ControllerViewPayrolls
    {
        FrmViewPayrolls objViewPayrolls;

        public ControllerViewPayrolls(FrmViewPayrolls Vista)
        {
            objViewPayrolls = Vista;
            //objViewPayrolls.btnAddPayroll.Click += new EventHandler(AddEmployee);
        }      
        public void AddEmployee(object sender, EventArgs e)
        {
            //Creamos el objeto del formulario addPayrroll
            FrmAddPayroll openForm = new FrmAddPayroll();
            openForm.ShowDialog();
        }
        public void AFP()
        {
            DAOViewPayrolls objGetDataAfp = new DAOViewPayrolls();
            double AFP = objGetDataAfp.Afp;

        }

    }
}
