using PTC2024.Model.DAO;
using PTC2024.Model.DAO.EmployeesDAO;
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
    internal class ControllerUpdateEmployee
    {
        FrmUpdateEmployee objUpdateEmployee;
        //CONSTRUCTOR
        public ControllerUpdateEmployee(FrmUpdateEmployee View, string names, string lastNames, string dui, DateTime birthDate, string email, string phone, string adress, double salary, string bankAccount, string bank, int affiliationNumber, DateTime hireDate, string department, string employeeType, string maritalStatus, string status, string username, string businessP)
        {
            objUpdateEmployee = View;
            objUpdateEmployee.Load += new EventHandler(ChargeInfo);
            objUpdateEmployee.BtnCancelar.Click += new EventHandler(CancelProcess);
            objUpdateEmployee.btnEmployeUpdate.Click += new EventHandler(UpdateEmployee);
            objUpdateEmployee.txtSalary.Enter += new EventHandler(EnterSalary);
            objUpdateEmployee.txtSalary.Leave += new EventHandler(LeaveSalary); 
        }

        public void ChargeInfo(object sender, EventArgs e)
        {
            ChargeValues();
        }
        public void CancelProcess(object sender, EventArgs e)
        {
            objUpdateEmployee.Close();
        }

        public void UpdateEmployee(object sender, EventArgs e)
        {

        }

        public void ChargeValues()
        {
            //creando objeto de la clase DAOAddEmployee
            DAOUpdateEmployee daoUpdateEmployee = new DAOUpdateEmployee();

            //Dropdown de Estados civiles
            DataSet dsEstadosCiviles = daoUpdateEmployee.ObtenerEstadosCiviles();
            objUpdateEmployee.comboMaritalStatus.DataSource = dsEstadosCiviles.Tables["tbmaritalStatus"];
            objUpdateEmployee.comboMaritalStatus.DisplayMember = "maritalStatus";
            objUpdateEmployee.comboMaritalStatus.ValueMember = "IdMaritalS";

            //Dropdown de Departamentos
            DataSet dsDepartamentos = daoUpdateEmployee.ObtenerDepartamentos();
            objUpdateEmployee.comboDepartment.DataSource = dsDepartamentos.Tables["tbDepartment"];
            objUpdateEmployee.comboDepartment.DisplayMember = "departmentName";
            objUpdateEmployee.comboDepartment.ValueMember = "IdDepartment";

            //Dropdown de tipos de empleado
            DataSet dsTiposEmpleado = daoUpdateEmployee.ObtenerTiposEmpleado();
            objUpdateEmployee.comboEmployeeType.DataSource = dsTiposEmpleado.Tables["tbTypeE"];
            objUpdateEmployee.comboEmployeeType.DisplayMember = "typeEmployee";
            objUpdateEmployee.comboEmployeeType.ValueMember = "IdTypeE";

            //Dropdown de puestos de empleado
            DataSet dsPuestosEmpleado = daoUpdateEmployee.ObtenerPuestosEmpleado();
            objUpdateEmployee.comboBusinessP.DataSource = dsPuestosEmpleado.Tables["tbBusinessP"];
            objUpdateEmployee.comboBusinessP.DisplayMember = "businessPosition";
            objUpdateEmployee.comboBusinessP.ValueMember = "IdBusinessP";

            //Dropdown de estado de empleado
            DataSet dsEstadosEmpleado = daoUpdateEmployee.ObtenerEstadosEmpleado();
            objUpdateEmployee.comboEmployeeStatus.DataSource = dsEstadosEmpleado.Tables["tbEmployeeStatus"];
            objUpdateEmployee.comboEmployeeStatus.DisplayMember = "employeeStatus";
            objUpdateEmployee.comboEmployeeStatus.ValueMember = "IdStatus";

            //Dropdown de Bancos
            DataSet dsBanks = daoUpdateEmployee.ObtainBanks();
            objUpdateEmployee.comboBanks.DataSource = dsBanks.Tables["tbBanks"];
            objUpdateEmployee.comboBanks.DisplayMember = "BankName";
            objUpdateEmployee.comboBanks.ValueMember = "IdBank";
        }

        public void EnterSalary(object sender, EventArgs e)
        {
            if (objUpdateEmployee.txtSalary.Text.Trim().Equals("Ingrese con dos decimales"))
            {
                objUpdateEmployee.txtSalary.Text = "";
            }
        }
        public void LeaveSalary(object sender, EventArgs e)
        {
            if (objUpdateEmployee.txtSalary.Text.Trim().Equals(""))
            {
                objUpdateEmployee.txtSalary.Text = "Ingrese con dos decimales";
            }
        }
    }
}
