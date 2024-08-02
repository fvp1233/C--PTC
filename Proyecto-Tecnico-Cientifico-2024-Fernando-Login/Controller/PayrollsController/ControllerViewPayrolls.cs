using PTC2024.Model.DAO.PayrollsDAO;
using PTC2024.View.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
            objViewPayrolls.Load += new EventHandler(LoadData);
            objViewPayrolls.btnCreatePayroll.Click += new EventHandler(CreatePayroll);
            objViewPayrolls.cmsUpdatePayroll.Click += new EventHandler(OpenUpdatePayroll);
            objViewPayrolls.cmsDeletePayroll.Click += new EventHandler(DeletePayroll);
            objViewPayrolls.cmsPayrollInformation.Click += new EventHandler(ViewInfoPayroll);
            objViewPayrolls.txtSearch.KeyPress += new KeyPressEventHandler(SearchPayrollEvent);
        }
        public void CreatePayroll(object sender, EventArgs e)
        {
            // Creamos un objeto del DaoViewPayrolls
            DAOViewPayrolls DAOInsertPayroll = new DAOViewPayrolls();
            // Accedemos a los datos de los empleados gracias al GetEmployee
            DAOInsertPayroll.GetEmployee();
            // Se crean los dataSets
            DataSet employeeDs = DAOInsertPayroll.GetEmployee();
            DataSet bonusDs = DAOInsertPayroll.GetBonus();
            DataSet userDs = DAOInsertPayroll.GetUsername();
            DataSet payrollDs = DAOInsertPayroll.GetPayroll();
            int returnValue = 0;
            // Se crea la condición en la cual establecemos que las tablas no estén vacías
            if (employeeDs != null && employeeDs.Tables.Count > 0 && bonusDs != null && bonusDs.Tables.Count > 0 && userDs != null && userDs.Tables.Count > 0)
            {
                // Creamos los dataTable
                DataTable employeeDt = employeeDs.Tables["tbEmployee"];
                DataTable bonusDt = bonusDs.Tables["tbBusinessP"];
                DataTable userDt = userDs.Tables["tbUserData"];
                DataTable payrollDt = payrollDs.Tables["tbPayroll"];
                // Verificamos que los dataTable no estén vacíos
                if (employeeDt != null && bonusDt != null && userDt != null)
                {
                    // Iteramos a través de todas las filas de la tabla employee
                    foreach (DataRow row in employeeDt.Rows)
                    {
                        int idEmployee = int.Parse(row["IdEmployee"].ToString());
                        DateTime hireDate = DateTime.Parse(row["hireDate"].ToString());
                        int startWorkYear = hireDate.Year;
                        int startWorkMonth = hireDate.Month;
                        // Año actual
                        int currentYear = DateTime.Now.Year;
                        // Iteramos desde el año de contratación hasta el siguiente año
                        for (int year = startWorkYear; year <= currentYear; year++)
                        {
                            int startMonth = (year == startWorkYear) ? startWorkMonth : 1;
                            for (int month = startMonth; month <= 12; month++)
                            {
                                DataRow[] existingPayrollRows = payrollDt.Select($"IdEmployee = {idEmployee} AND IssueDate = '{year}-{month:D2}-01'");
                                if (existingPayrollRows.Length == 0)
                                {
                                    string username = row["username"].ToString();
                                    DataRow[] userRows = userDt.Select($"username = '{username}'");
                                    if (userRows.Length > 0)
                                    {
                                        DataRow userRow = userRows[0];
                                        string businessRole = userRow["IdBusinessP"].ToString();
                                        // Buscar la fila correspondiente en la tabla roles (bonus)
                                        DataRow[] bonusRows = bonusDt.Select($"IdBusinessP = '{businessRole}'");
                                        if (bonusRows.Length > 0)
                                        {
                                            DataRow bonusRow = bonusRows[0];
                                            double roleBonus = double.Parse(bonusRow["positionBonus"].ToString());
                                            DAOInsertPayroll.BusinessBonus = float.Parse(roleBonus.ToString());
                                            double salary = double.Parse(row["salary"].ToString());
                                            double christmasBonus = GetChristmasBonus(salary, hireDate, year);
                                            double calculatedSalary = 0;

                                            if (month == 12)
                                            {
                                                if (christmasBonus > 730)
                                                {
                                                    calculatedSalary = roleBonus + salary + christmasBonus;
                                                    DAOInsertPayroll.ChristmasBonus = christmasBonus;
                                                }
                                                else
                                                {
                                                    calculatedSalary = roleBonus + salary;
                                                    DAOInsertPayroll.ChristmasBonus = christmasBonus;
                                                }
                                            }
                                            else
                                            {
                                                calculatedSalary = roleBonus + salary;
                                                DAOInsertPayroll.ChristmasBonus = 0;
                                            }

                                            DAOInsertPayroll.Username = row["username"].ToString();
                                            DAOInsertPayroll.Isss = GetISSS(calculatedSalary);
                                            DAOInsertPayroll.Afp = GetAFP(calculatedSalary);
                                            DAOInsertPayroll.Rent = GetRent(calculatedSalary);
                                            DAOInsertPayroll.NetPay = GetNetSalary(calculatedSalary);
                                            DAOInsertPayroll.IsssEmployer = GetISSSEmployeer(calculatedSalary);
                                            DAOInsertPayroll.AfpEmployer = GetAFPEmployer(calculatedSalary);
                                            DAOInsertPayroll.DiscountEmployee = GetEmployeeDiscount(calculatedSalary);
                                            DAOInsertPayroll.DiscountEmployer = GetEmployerDiscount(calculatedSalary);
                                            DAOInsertPayroll.IssueDate = new DateTime(year, month, 1);
                                            DAOInsertPayroll.IdEmployee = idEmployee;
                                            DAOInsertPayroll.IdPayrollStatus = 2;
                                            returnValue = DAOInsertPayroll.AddPayroll();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                RefreshData();
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

        //public void CreatePayroll(object sender, EventArgs e)
        //{
        //    //Creamos un objeto del DaoViewPayrolls
        //    DAOViewPayrolls DAOInsertPayroll = new DAOViewPayrolls();
        //    //Accedemos a los datos de los empleados gracias al GetEmployee
        //    DAOInsertPayroll.GetEmployee();
        //    //Se crean los dataSets
        //    DataSet employeeDs = DAOInsertPayroll.GetEmployee();
        //    DataSet bonusDs = DAOInsertPayroll.GetBonus();
        //    DataSet userDs = DAOInsertPayroll.GetUsername();
        //    DataSet payrollDs = DAOInsertPayroll.GetPayroll();
        //    int returnValue = 0;
        //    //Se crea la condicion en la cual establecemos que las tablas no esten vacias
        //    if (employeeDs != null && employeeDs.Tables.Count > 0 && bonusDs != null && bonusDs.Tables.Count > 0 && userDs != null && userDs.Tables.Count > 0)
        //    {
        //        //Creamos los dataTable
        //        DataTable employeeDt = employeeDs.Tables["tbEmployee"];
        //        DataTable bonusDt = bonusDs.Tables["tbBusinessP"];
        //        DataTable userDt = userDs.Tables["tbUserData"];
        //        DataTable payrollDt = payrollDs.Tables["tbPayroll"];
        //        //Verificamos que los datatable no esten vacias
        //        if (employeeDt != null && bonusDt != null && userDt != null)
        //        {
        //            //Iteramos a traves de todas las filas de la tabla employee
        //            foreach (DataRow row in employeeDt.Rows)
        //            {
        //                int idEmployee = int.Parse(row["IdEmployee"].ToString());
        //                DateTime hireDate = DateTime.Parse(row["hireDate"].ToString());
        //                int startWork = hireDate.Month;
        //                int month;
        //                double calculatedSalary=0;
        //                for (month = startWork; month <= 12; month++)
        //                {
        //                    DataRow[] existingPayrollRows = payrollDt.Select($"IdEmployee = {idEmployee}");
        //                    if (existingPayrollRows.Length == 0)
        //                    {
        //                        string username = row["username"].ToString();
        //                        DataRow[] userRows = userDt.Select($"username = '{username}'");
        //                        if (userRows.Length > 0)
        //                        {
        //                            DataRow userRow = userRows[0];
        //                            string businessRole = userRow["IdBusinessP"].ToString();
        //                            // Buscar la fila correspondiente en la tabla roles (bonus)
        //                            DataRow[] bonusRows = bonusDt.Select($"IdBusinessP = '{businessRole}'");
        //                            if (bonusRows.Length > 0)
        //                            {
        //                                DataRow bonusRow = bonusRows[0];
        //                                double roleBonus = double.Parse(bonusRow["positionBonus"].ToString());
        //                                DAOInsertPayroll.BusinessBonus = float.Parse(roleBonus.ToString());                                        
        //                                double salary = double.Parse(row["salary"].ToString());
        //                                double christmasBonus = GetChristmasBonus(salary,hireDate);
        //                                if (month == 12)
        //                                {                                                                                    
        //                                    if(christmasBonus > 730)
        //                                    {
        //                                        calculatedSalary = double.Parse(roleBonus.ToString()) + salary + GetChristmasBonus(salary, hireDate);
        //                                        DAOInsertPayroll.ChristmasBonus = christmasBonus;
        //                                    }
        //                                    else
        //                                    {
        //                                        DAOInsertPayroll.ChristmasBonus = christmasBonus;
        //                                    }                      
        //                                }
        //                                else
        //                                {
        //                                    calculatedSalary = double.Parse(roleBonus.ToString()) + double.Parse(row["salary"].ToString());
        //                                    DAOInsertPayroll.ChristmasBonus = 0;
        //                                }
        //                                DAOInsertPayroll.Username = row["username"].ToString();
        //                                DAOInsertPayroll.Isss = GetISSS(calculatedSalary);
        //                                DAOInsertPayroll.Afp = GetAFP(calculatedSalary);
        //                                DAOInsertPayroll.Rent = GetRent(calculatedSalary);
        //                                DAOInsertPayroll.NetPay = GetNetSalary(calculatedSalary);
        //                                DAOInsertPayroll.IsssEmployer = GetISSSEmployeer(calculatedSalary);
        //                                DAOInsertPayroll.AfpEmployer = GetAFPEmployer(calculatedSalary);
        //                                DAOInsertPayroll.DiscountEmployee = GetEmployeeDiscount(calculatedSalary);
        //                                DAOInsertPayroll.DiscountEmployer = GetEmployerDiscount(calculatedSalary);
        //                                DAOInsertPayroll.IssueDate = new DateTime(hireDate.Year, month, 1);
        //                                DAOInsertPayroll.IdEmployee = int.Parse(row["IdEmployee"].ToString());
        //                                DAOInsertPayroll.IdPayrollStatus = 2;
        //                            }
        //                        }
        //                        returnValue = DAOInsertPayroll.AddPayroll();
        //                    }
        //                }
        //            }
        //        }
        //        RefreshData();
        //    }
        //    if (returnValue == 1)
        //    {
        //        MessageBox.Show("Los datos han sido registrados exitosamente",
        //                                        "Proceso completado",
        //                                        MessageBoxButtons.OK,
        //                                        MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Los datos no pudieron ser registrados",
        //                       "Proceso interrumpido",
        //                       MessageBoxButtons.OK,
        //                       MessageBoxIcon.Error);
        //    }
        //}
        //--------------------------METODOS $$$$$$$---------------------------//

        //Metodo para obtener el AFP el cual es igual al 7.5% del salario
        public double GetAFP(double Salary)
        {
            double AFP = Salary * 0.0725;
            return AFP;
        }
        //Metodo para obtener el ISS el cual es igual al 3% del salario co un techo de $1000
        public double GetISSS(double Salary)
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
        public double GetAFPEmployer(double Salary)
        {
            double AFP = Salary * 0.0875;
            return AFP;
        }
        public double GetISSSEmployeer(double Salary)
        {
            double ISSS = Salary * 0.075; ;
            return ISSS;
        }
        //Metodo para obtener la renta la cual es igual a 0 si la persona gana $472 del salario
        //Metodo para obtener la renta la cual es igual al 10% del salario + $17.67 si la persona arriba de $472 hasta $895.24
        //Metodo para obtener la renta la cual es igual al 20% del salario + $60 si la persona arriba de $895.24 hasta $2028.11
        //Metodo para obtener la renta la cual es igual al 30% del salario + $288.57 si la persona arriba de $2028.11
        public double GetRent(double Salary)
        {
            double rent;
            double AFP_ISSS = GetAFP(Salary) + GetISSS(Salary);
            double prerent = Salary - AFP_ISSS;
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
        //Metodo para obtener el salario neto
        public double GetNetSalary(double Salary)
        {
            double netSalary = Salary - (GetISSS(Salary) + GetAFP(Salary) + GetRent(Salary));
            return netSalary;
        }
        public double GetEmployeeDiscount(double Salary)
        {
            double employeeDiscount = Salary - GetNetSalary(Salary);
            return employeeDiscount;
        }
        public double GetEmployerDiscount(double Salary)
        {
            double employerDiscount = GetAFPEmployer(Salary) + GetISSS(Salary) + GetRent(Salary);
            return employerDiscount;
        }
        public double GetChristmasBonus(double salary, DateTime hireDate, int year)
        {
            // Determinar el tiempo trabajado hasta el 15 de diciembre del año específico
            DateTime endDate = new DateTime(year, 12, 15);
            if (hireDate > endDate)
            {
                // Si la fecha de contratación es después del 15 de diciembre, el aguinaldo es 0
                return 0;
            }

            int workedYears = year - hireDate.Year;
            double christmasBonus = 0;

            if (workedYears >= 1 && workedYears < 3)
            {
                christmasBonus = (salary / 30) * 15;
            }
            else if (workedYears >= 3 && workedYears < 10)
            {
                christmasBonus = (salary / 30) * 19;
            }
            else if (workedYears >= 10)
            {
                christmasBonus = (salary / 30) * 21;
            }
            else
            {
                TimeSpan workedDays = endDate - hireDate;
                double dailyPayment = (salary / 2) / 365;
                christmasBonus = dailyPayment * workedDays.Days;
            }

            return christmasBonus;
        }
        //------------------METODOS DE LA VISTA----------------------//
        public void SearchPayrollEvent(object sender, KeyPressEventArgs e)
        {
            SearchPayroll();
        }
        void SearchPayroll()
        {
            DAOViewPayrolls objAdmin = new DAOViewPayrolls();
            DataSet ds = objAdmin.SearchPayroll(objViewPayrolls.txtSearch.Text.Trim());
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void LoadData(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            DAOViewPayrolls objRefresh = new DAOViewPayrolls();
            DataSet ds = objRefresh.GetEmployeesDgv();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            objViewPayrolls.dgvPayrolls.Columns[6].Visible = false;
            objViewPayrolls.dgvPayrolls.Columns[7].Visible = false;

        }

        //----------------------Metodos de interaccion con otros formularios---------------------------//
        public void OpenUpdatePayroll(object sender, EventArgs e)
        {
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            int affiliationNumber, nP;
            string employee, dui, possition, bankAccount, payrollStatus;
            double salary, bonus, afp, isss, rent, discountEmployee, netSalary;
            DateTime issueDate;
            nP = int.Parse(objViewPayrolls.dgvPayrolls[0, pos].Value.ToString());
            dui = objViewPayrolls.dgvPayrolls[1, pos].Value.ToString();
            employee = objViewPayrolls.dgvPayrolls[2, pos].Value.ToString();
            salary = double.Parse(objViewPayrolls.dgvPayrolls[3, pos].Value.ToString());
            possition = objViewPayrolls.dgvPayrolls[4, pos].Value.ToString();
            bonus = double.Parse(objViewPayrolls.dgvPayrolls[5, pos].Value.ToString());
            bankAccount = objViewPayrolls.dgvPayrolls[6, pos].Value.ToString();
            affiliationNumber = int.Parse(objViewPayrolls.dgvPayrolls[7, pos].Value.ToString());
            afp = double.Parse(objViewPayrolls.dgvPayrolls[8, pos].Value.ToString());
            isss = double.Parse(objViewPayrolls.dgvPayrolls[9, pos].Value.ToString());
            rent = double.Parse(objViewPayrolls.dgvPayrolls[10, pos].Value.ToString());
            netSalary = double.Parse(objViewPayrolls.dgvPayrolls[11, pos].Value.ToString());
            discountEmployee = isss + afp + rent;
            issueDate = DateTime.Parse(objViewPayrolls.dgvPayrolls[12, pos].Value.ToString());
            payrollStatus = objViewPayrolls.dgvPayrolls[13, pos].Value.ToString();
            FrmUpdatePayroll openForm = new FrmUpdatePayroll(nP, dui, employee, salary, possition, bonus, bankAccount, affiliationNumber, afp, isss, rent, netSalary, discountEmployee, issueDate, payrollStatus);
            openForm.ShowDialog();
            RefreshData();
        }
        private void DeletePayroll(object sender, EventArgs e)
        {
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            if (MessageBox.Show($"¿Esta seguro que desea elimar a:\n {objViewPayrolls.dgvPayrolls[1, pos].Value.ToString()} {objViewPayrolls.dgvPayrolls[2, pos].Value.ToString()}.\nConsidere que dicha acción no se podrá revertir.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DAOViewPayrolls daoDelete = new DAOViewPayrolls();
                daoDelete.IdPayroll = int.Parse(objViewPayrolls.dgvPayrolls[0, pos].Value.ToString());
                int values = daoDelete.DeletePayroll();
                if (values == 1)
                {
                    MessageBox.Show("Registro eliminado", "Acción completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("Registro no pudo ser eliminado, verifique que el registro no tenga datos asociados.", "Acción interrumpida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ViewInfoPayroll(object sender, EventArgs e)
        {
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            int affiliationNumber;
            string employee, dui, possition, bankAccount, payrollStatus;
            double salary, bonus, afp, isss, rent, discountEmployee, netSalary, issEmployer, afpEmployer, discountEmployer, christmasBonus;
            DateTime issueDate;
            dui = objViewPayrolls.dgvPayrolls[1, pos].Value.ToString();
            employee = objViewPayrolls.dgvPayrolls[2, pos].Value.ToString();
            salary = double.Parse(objViewPayrolls.dgvPayrolls[3, pos].Value.ToString());
            possition = objViewPayrolls.dgvPayrolls[4, pos].Value.ToString();
            bonus = double.Parse(objViewPayrolls.dgvPayrolls[5, pos].Value.ToString());
            bankAccount = objViewPayrolls.dgvPayrolls[6, pos].Value.ToString();
            affiliationNumber = int.Parse(objViewPayrolls.dgvPayrolls[7, pos].Value.ToString());
            afp = double.Parse(objViewPayrolls.dgvPayrolls[8, pos].Value.ToString());
            isss = double.Parse(objViewPayrolls.dgvPayrolls[9, pos].Value.ToString());
            rent = double.Parse(objViewPayrolls.dgvPayrolls[10, pos].Value.ToString());
            netSalary = double.Parse(objViewPayrolls.dgvPayrolls[11, pos].Value.ToString());
            discountEmployee = isss + afp + rent;
            double calculatedSalary = bonus + salary;
            issueDate = DateTime.Parse(objViewPayrolls.dgvPayrolls[12, pos].Value.ToString());
            issEmployer = GetISSSEmployeer(calculatedSalary);
            afpEmployer = GetAFPEmployer(calculatedSalary);
            discountEmployer = issEmployer + afpEmployer;
            payrollStatus = objViewPayrolls.dgvPayrolls[13, pos].Value.ToString();
            christmasBonus = double.Parse(objViewPayrolls.dgvPayrolls[14, pos].Value.ToString());
            FrmInfoPayroll openForm = new FrmInfoPayroll(dui, employee, possition, bonus, bankAccount, affiliationNumber, salary, afp, isss, rent, netSalary, discountEmployee, issueDate, christmasBonus, issEmployer, afpEmployer, discountEmployer, payrollStatus);
            openForm.ShowDialog();
            RefreshData();
        }


    }
}
