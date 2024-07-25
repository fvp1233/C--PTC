using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Controller.EmployeesController
{
    internal class ControllerAddPayroll
    {
        FrmAddPayroll objAddPayroll;
        public ControllerAddPayroll(FrmAddPayroll Vista)
        {
            objAddPayroll = Vista;
            objAddPayroll.Load += new EventHandler(fillDropDownEmployee);
            objAddPayroll.btnCancelar.Click += new EventHandler(CloseForm);
        }
        public void fillDropDownEmployee(object sender, EventArgs e)
        {
            //Se crea el objeto de la clase DaoAddPayroll
            DAOAddPayroll daoAFillDropdown = new DAOAddPayroll();
            //Dropdown Empleados
            DataSet dsEmloyeeName = daoAFillDropdown.GetEmployeeName();
            objAddPayroll.comboEmployee.DataSource = dsEmloyeeName.Tables["tbEmployee"];
            //objAddPayroll.dropEmployee.DisplayMember = "name";
            objAddPayroll.comboEmployee.DisplayMember = "fullEmployeeInfo";
            objAddPayroll.comboEmployee.ValueMember = "fullEmployeeInfo";
            objAddPayroll.comboEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
            objAddPayroll.comboEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        //public int AddNewPayroll(object sender, EventArgs e)
        //{
        //    DAOAddPayroll daoAddPayroll = new DAOAddPayroll();
        //    daoAddPayroll.
        //}
        public void CloseForm(object sender, EventArgs e)
        {
            objAddPayroll.Close();
        }
    }
}
