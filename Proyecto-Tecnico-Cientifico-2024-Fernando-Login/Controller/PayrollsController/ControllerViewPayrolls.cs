using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PTC2024.Controller.EmployeesController
{
    internal class ControllerViewPayrolls
    {
        FrmViewPayrolls objViewPayrolls;

        public ControllerViewPayrolls(FrmViewPayrolls Vista)
        {
            objViewPayrolls = Vista;
            objViewPayrolls.btnCreatePayroll.Click += new EventHandler(CreatePayroll);
        }
        public void CreatePayroll(object sender, EventArgs e)
        {
            DAOViewPayrolls DAOInsertPayroll = new DAOViewPayrolls();
            DAOInsertPayroll.GetEmployee();
            var dataSetDemo = new DAOViewPayrolls();
            DataSet employeeDs = dataSetDemo.GetEmployee();
            DataSet bonusDs = dataSetDemo.GetBonus();
            DataSet userDs = dataSetDemo.GetUsername();
            DataSet payrollDs = dataSetDemo.GetPayroll();

            int returnValue = 0;

            if (employeeDs != null && employeeDs.Tables.Count > 0 && bonusDs != null && bonusDs.Tables.Count > 0 && userDs != null && userDs.Tables.Count > 0)
            {
                DataTable employeeDt = employeeDs.Tables["tbEmployee"];
                DataTable bonusDt = bonusDs.Tables["tbBusinessP"];
                DataTable userDt = userDs.Tables["tbUserData"];
                DataTable payrollDt = payrollDs.Tables["tbPayroll"];

                if (employeeDt != null && bonusDt != null && userDt != null)
                {
                    //Iteramos a traves de todas las filas de la tabla employee
                    foreach (DataRow row in employeeDt.Rows)
                    {
                        var idEmployee = int.Parse(row["IdEmployee"].ToString());

                        DataRow[] existingPayrollRows = payrollDt.Select($"IdEmployee = {idEmployee}");
                        if (existingPayrollRows.Length == 0)
                        {
                            var username = row["username"].ToString();
                            DataRow[] userRows = userDt.Select($"username = '{username}'");
                            if (userRows.Length > 0)
                            {

                                DataRow userRow = userRows[0];
                                string businessRole = userRow["IdBusinessP"].ToString();

                                // Buscar la fila correspondiente en la tabla roles (bonuses)
                                DataRow[] bonusRows = bonusDt.Select($"IdBusinessP = '{businessRole}'");
                                if (bonusRows.Length > 0)
                                {
                                    DataRow bonusRow = bonusRows[0];
                                    var roleBonus = bonusRow["positionBonus"];
                                    DAOInsertPayroll.BusinessBonus = float.Parse(roleBonus.ToString());
                                    double calculatedSalary = double.Parse(roleBonus.ToString()) + double.Parse(row["salary"].ToString());
                                    DAOInsertPayroll.Username = row["username"].ToString();
                                    DAOInsertPayroll.Isss = GetISS(calculatedSalary);
                                    DAOInsertPayroll.Afp = GetAFP(calculatedSalary);
                                    DAOInsertPayroll.Income = GetRent(calculatedSalary);
                                    DAOInsertPayroll.NetPay = GetNetSalary(calculatedSalary);
                                    DAOInsertPayroll.IdEmployee = int.Parse(row["IdEmployee"].ToString());
                                    DAOInsertPayroll.IssueDate = DateTime.Now;
                                }
                            }
                            returnValue = DAOInsertPayroll.AddPayroll();
                        }
                    }
                }
            }
            if (returnValue == 1)
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
        public double GetAFP(double Salary)
        {
            double AFP = Salary * 0.0725;
            return AFP;
        }
        public double GetISS(double Salary)
        {
            double ISS;
            if (Salary >= 1000)
            {
                ISS = 1000 * 0.03;
            }
            else
            {
                ISS = Salary * 0.03;
            }
            return ISS;
        }
        public double GetRent(double Salary)
        {
            double rent;
            double AFP_ISS = GetAFP(Salary) + GetISS(Salary);
            double prerent = Salary - AFP_ISS;
            if (prerent > 0 && prerent < 472.01)
            {
                rent = 0;
            }
            else if (prerent > 472.01 && prerent <= 895.24)
            {
                rent = ((prerent - 472) * 0.1) + 17.67;
            }
            else if (prerent > 895.24 && prerent <= 2038.11)
            {
                rent = ((prerent - 895.24) * 0.2) + 60;
            }
            else
            {
                rent = ((prerent - 2038.10) * 0.3) + 288.57;
            }
            double retencion = rent;
            return retencion;
        }
        public double GetNetSalary(double Salary)
        {
            double netSalary = Salary - (GetISS(Salary) + GetAFP(Salary) + GetRent(Salary));
            return netSalary;
        }
        public double GetBonus(double Salary, int IdRole)
        {
            switch (IdRole)
            {
                case 1:
                    Salary = Salary + 300.00;
                    break;
                case 2:
                    Salary = Salary + 150.00;
                    break;
                default:
                    break;
            }
            return Salary;
        }
    }
}
