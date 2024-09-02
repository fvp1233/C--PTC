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
            objViewPayrolls.picNotification.Click += new EventHandler(ChangeStatus);
            objViewPayrolls.btnAll.Click += new EventHandler(SearchAll);
            objViewPayrolls.btnFirstT.Click += new EventHandler(SearchByFirstTrimester);
            objViewPayrolls.btnSecondT.Click += new EventHandler(SearchBySecondTrimester);
            objViewPayrolls.btnThirtht.Click += new EventHandler(SearchByThirthTrimester);
            objViewPayrolls.btnFourth.Click += new EventHandler(SearchByFourthTrimester);
            objViewPayrolls.ch1.Click += new EventHandler(SearchByMonth1);
            objViewPayrolls.ch2.Click += new EventHandler(SearchByMonth2);
            objViewPayrolls.ch3.Click += new EventHandler(SearchByMonth3);
            objViewPayrolls.ch4.Click += new EventHandler(SearchByMonth4);
            objViewPayrolls.ch5.Click += new EventHandler(SearchByMonth5);
            objViewPayrolls.ch6.Click += new EventHandler(SearchByMonth6);
            objViewPayrolls.ch7.Click += new EventHandler(SearchByMonth7);
            objViewPayrolls.ch8.Click += new EventHandler(SearchByMonth8);
            objViewPayrolls.ch9.Click += new EventHandler(SearchByMonth9);
            objViewPayrolls.ch10.Click += new EventHandler(SearchByMonth10);
            objViewPayrolls.ch11.Click += new EventHandler(SearchByMonth11);
            objViewPayrolls.ch12.Click += new EventHandler(SearchByMonth12);
            objViewPayrolls.chPaid.Click += new EventHandler(SearchByPaid);
            objViewPayrolls.chuUnpaid.Click += new EventHandler(SearchByUnpaid);
            objViewPayrolls.chCompensation.Click += new EventHandler(SearchByCompensation);
            objViewPayrolls.btnCreatePayroll.Click += new EventHandler(CreatePayroll);
            objViewPayrolls.btnCompensation.Click += new EventHandler(CreateCompensationPayroll);
            objViewPayrolls.btnActualizarPlanillas.Click += new EventHandler(RefreshData);
            objViewPayrolls.cmsUpdatePayroll.Click += new EventHandler(OpenUpdatePayroll);
            objViewPayrolls.btnDeletePayrolls.Click += new EventHandler(DeletePayrolls);
            objViewPayrolls.dgvPayrolls.Click += new EventHandler(Disable);
            objViewPayrolls.cmsPayPayroll.Click += new EventHandler(UpdatePayrollPaid);
            objViewPayrolls.cmsUpdateUnpaid.Click += new EventHandler(UpdatePayrollToUnpaid);
            objViewPayrolls.cmsPayrollInformation.Click += new EventHandler(ViewInfoPayroll);
            objViewPayrolls.txtSearch.KeyPress += new KeyPressEventHandler(SearchPayrollEvent);
        }

        private void ChangeStatus(object sender, EventArgs e)
        {
            DAOViewPayrolls DAOUpdatePayroll = new DAOViewPayrolls();
            DataSet employeeDs = DAOUpdatePayroll.GetEmployee();

            if (employeeDs != null)
            {
                DataTable employeeDt = employeeDs.Tables["tbEmployee"];

                foreach (DataRow row in employeeDt.Rows)
                {
                    int status = int.Parse(row["IdStatus"].ToString());
                    if (status == 3) // Maternidad
                    {
                        // Obtener el nombre del empleado
                        string employeeName = row["DUI"].ToString(); // Asegúrate de que "EmployeeName" es el nombre de la columna

                        // Usar la fecha actual como la fecha de cambio de estado
                        DateTime statusChangeDate = DateTime.Now;
                        DateTime returnDate = statusChangeDate.AddDays(112);

                        string message = $"El estado de la empleada {employeeName} cambió a maternidad hoy, {statusChangeDate.ToShortDateString()}.\n" +
                                         $"Se espera su regreso el {returnDate.ToShortDateString()}.";

                        MessageBox.Show(message, "Información de Maternidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        public double TruncateToTwoDecimals(double value)
        {
            return Math.Round(value, 2);
        }
        public void CreatePayroll(object sender, EventArgs e)
        {
            DAOViewPayrolls DAOInsertPayroll = new DAOViewPayrolls();
            DataSet employeeDs = DAOInsertPayroll.GetEmployee();
            DataSet bonusDs = DAOInsertPayroll.GetBonus();
            DataSet userDs = DAOInsertPayroll.GetUsername();
            DataSet payrollDs = DAOInsertPayroll.GetPayroll();
            int returnValue = 0;

            if (employeeDs != null && employeeDs.Tables.Count > 0 &&
                bonusDs != null && bonusDs.Tables.Count > 0 &&
                userDs != null && userDs.Tables.Count > 0)
            {
                DataTable employeeDt = employeeDs.Tables["tbEmployee"];
                DataTable bonusDt = bonusDs.Tables["tbBusinessP"];
                DataTable userDt = userDs.Tables["tbUserData"];
                DataTable payrollDt = payrollDs.Tables["tbPayroll"];

                if (employeeDt != null && bonusDt != null && userDt != null)
                {
                    foreach (DataRow row in employeeDt.Rows)
                    {
                        int status = int.Parse(row["IdStatus"].ToString());
                        int idEmployee = int.Parse(row["IdEmployee"].ToString());
                        DateTime hireDate = DateTime.Parse(row["hireDate"].ToString());
                        int startWorkYear = hireDate.Year;
                        int startWorkMonth = hireDate.Month;
                        int currentYear = DateTime.Now.Year;
                        double salary = double.Parse(row["salary"].ToString());
                        int daysWorked = 0;
                        double daySalary = 0;
                        double hourSalary = 0;
                        int hoursWorked = 240;

                        if (status != 2)
                        {
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
                                            DataRow[] bonusRows = bonusDt.Select($"IdBusinessP = '{businessRole}'");
                                            if (bonusRows.Length > 0)
                                            {
                                                DataRow bonusRow = bonusRows[0];
                                                double roleBonus = double.Parse(bonusRow["positionBonus"].ToString());

                                                // Calcular días trabajados, salario diario y salario por hora
                                                if (year == startWorkYear && month == startWorkMonth)
                                                {
                                                    daysWorked = 30;
                                                    daySalary = salary / daysWorked;
                                                    hourSalary = daySalary / 8;
                                                }
                                                else
                                                {
                                                    daysWorked = 30;
                                                    daySalary = salary / daysWorked;
                                                    hourSalary = daySalary / 8;
                                                }

                                                // Calcular salario total basado en horas trabajadas
                                                double calculatedSalaryByHours = TruncateToTwoDecimals(hoursWorked * hourSalary);
                                                double calculatedSalary = TruncateToTwoDecimals( calculatedSalaryByHours + roleBonus);

                                                DAOInsertPayroll = new DAOViewPayrolls
                                                {
                                                    BusinessBonus = float.Parse(roleBonus.ToString()),
                                                    ChristmasBonus = 0,
                                                    Username = row["username"].ToString(),
                                                    Isss = GetISSS(calculatedSalary),
                                                    Afp = GetAFP(calculatedSalary),
                                                    Rent = GetRent(calculatedSalary),
                                                    NetPay = GetNetSalary(calculatedSalary),
                                                    IsssEmployer = GetISSSEmployeer(calculatedSalary),
                                                    AfpEmployer = GetAFPEmployer(calculatedSalary),
                                                    DiscountEmployee = GetEmployeeDiscount(calculatedSalary),
                                                    DiscountEmployer = GetEmployerDiscount(calculatedSalary),
                                                    IssueDate = new DateTime(year, month, 1),
                                                    IdEmployee = idEmployee,
                                                    IdPayrollStatus = 2,
                                                    DaysWorked = daysWorked,
                                                    DaySalary = TruncateToTwoDecimals(daySalary),
                                                    GossSalary = TruncateToTwoDecimals(calculatedSalary),
                                                    HoursWorked = hoursWorked,
                                                    HourSalary = TruncateToTwoDecimals(hourSalary),
                                                    ExtraHours = 0
                                                };

                                                if (month == 12)
                                                {
                                                    double christmasBonus = GetChristmasBonus(salary, hireDate, year);
                                                    if (christmasBonus > 1500)
                                                    {
                                                        christmasBonus = GetChristmasBonusRent(christmasBonus);
                                                        DAOInsertPayroll.ChristmasBonus = christmasBonus;
                                                    }
                                                    else
                                                    {
                                                        DAOInsertPayroll.ChristmasBonus = christmasBonus;
                                                    }
                                                }

                                                returnValue = DAOInsertPayroll.AddPayroll();
                                            }
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
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"Los datos fueron ingresados de manera exitosa.", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
            }
            else
            {
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"No hay empleados a los cuales generar planillas", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
            }
        }


        public void RefreshData(object sender, EventArgs e)
        {
            DAOViewPayrolls DAOUpdatePayroll = new DAOViewPayrolls();
            DataSet employeeDs = DAOUpdatePayroll.GetEmployee();
            DataSet bonusDs = DAOUpdatePayroll.GetBonus();
            DataSet userDs = DAOUpdatePayroll.GetUsername();
            DataSet payrollDs = DAOUpdatePayroll.GetPayroll();
            int totalRowsAffected = 0;

            if (employeeDs != null && payrollDs != null && bonusDs != null && userDs != null)
            {
                DataTable employeeDt = employeeDs.Tables["tbEmployee"];
                DataTable payrollDt = payrollDs.Tables["tbPayroll"];
                DataTable bonusDt = bonusDs.Tables["tbBusinessP"];
                DataTable userDt = userDs.Tables["tbUserData"];

                foreach (DataRow row in employeeDt.Rows)
                {
                    int status = int.Parse(row["IdStatus"].ToString());
                    int idEmployee = int.Parse(row["IdEmployee"].ToString());
                    DateTime hireDate = DateTime.Parse(row["hireDate"].ToString());
                    double salary = double.Parse(row["salary"].ToString());

                    if (status != 2)
                    {
                        DataRow[] unpaidPayrolls = payrollDt.Select($"IdEmployee = {idEmployee} AND IdPayrollStatus = 2");
                        foreach (DataRow payrollRow in unpaidPayrolls)
                        {
                            int idPayroll = int.Parse(payrollRow["IdPayroll"].ToString());
                            DateTime issueDate = DateTime.Parse(payrollRow["issueDate"].ToString());
                            int daysWorked = int.Parse(payrollRow["daysWorked"].ToString());

                            // Recuperar daySalary y hourSalary de la base de datos
                            double daySalary = salary / 30; // Consistencia en el cálculo
                            double hourSalary = daySalary / 8; // Consistencia en el cálculo
                            int hoursWorked = int.Parse(payrollRow["hoursWorked"].ToString());
                            int extraHours = int.Parse(payrollRow["extraHours"].ToString());

                            // Bonus del rol de negocio
                            double roleBonus = 0;
                            DataRow[] userRows = userDt.Select($"username = '{row["username"]}'");
                            if (userRows.Length > 0)
                            {
                                DataRow userRow = userRows[0];
                                string businessRole = userRow["IdBusinessP"].ToString();
                                DataRow[] bonusRows = bonusDt.Select($"IdBusinessP = '{businessRole}'");
                                if (bonusRows.Length > 0)
                                {
                                    DataRow bonusRow = bonusRows[0];
                                    roleBonus = double.Parse(bonusRow["positionBonus"].ToString());
                                }
                            }

                            // Calculando el salario bruto y neto con los valores recuperados
                            double calculatedSalaryByHours = (hoursWorked + extraHours) * hourSalary;
                            double calculatedSalary = TruncateToTwoDecimals(calculatedSalaryByHours + roleBonus);

                            // Aplicar los descuentos igual que en CreatePayroll
                            double rent = GetRent(calculatedSalary);
                            double isss = GetISSS(calculatedSalary);
                            double afp = GetAFP(calculatedSalary);
                            double christmasBonus = 0;

                            if (issueDate.Month == 12)
                            {
                                christmasBonus = TruncateToTwoDecimals(GetChristmasBonus(salary, hireDate, issueDate.Year));
                                if (christmasBonus > 1500)
                                {
                                    christmasBonus = TruncateToTwoDecimals(GetChristmasBonusRent(christmasBonus));
                                }
                            }

                            double netPay = TruncateToTwoDecimals(calculatedSalary - isss - afp - rent);

                            // Asignar los valores actualizados en el DAO para la actualización
                            DAOUpdatePayroll.IdPayroll = idPayroll;
                            DAOUpdatePayroll.NetPay = netPay;
                            DAOUpdatePayroll.Rent = rent;
                            DAOUpdatePayroll.Afp = afp;
                            DAOUpdatePayroll.Isss = isss;
                            DAOUpdatePayroll.IsssEmployer = TruncateToTwoDecimals(GetISSSEmployeer(calculatedSalary));
                            DAOUpdatePayroll.AfpEmployer = TruncateToTwoDecimals(GetAFPEmployer(calculatedSalary));
                            DAOUpdatePayroll.DiscountEmployee = TruncateToTwoDecimals(GetEmployeeDiscount(calculatedSalary));
                            DAOUpdatePayroll.DiscountEmployer = TruncateToTwoDecimals(GetEmployerDiscount(calculatedSalary));
                            DAOUpdatePayroll.ChristmasBonus = christmasBonus;
                            DAOUpdatePayroll.GossSalary = calculatedSalary;
                            DAOUpdatePayroll.DaySalary = daySalary;
                            DAOUpdatePayroll.DaysWorked = daysWorked;
                            DAOUpdatePayroll.HourSalary = hourSalary;
                            DAOUpdatePayroll.HoursWorked = hoursWorked;
                            DAOUpdatePayroll.ExtraHours = extraHours;
                            DAOUpdatePayroll.IdPayrollStatus = 2;

                            // Actualizar en la base de datos
                            totalRowsAffected += DAOUpdatePayroll.UpdatePayroll();
                        }
                    }
                }
                RefreshData();
            }

            if (totalRowsAffected > 0)
            {
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"Los datos fueron fueron refrescados exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);

            }
            else
            {
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"Los datos no pudieron ser registrados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);

            }
        } 
        public void CreateCompensationPayroll(object sender, EventArgs e)
        {
            // Creamos un objeto del DaoViewPayrolls
            DAOViewPayrolls DAOInsertPayroll = new DAOViewPayrolls();
            // Accedemos a los datos de los empleados
            DAOInsertPayroll.GetEmployee();
            // Se crean los dataSets
            DataSet employeeDs = DAOInsertPayroll.GetEmployee();
            DataSet payrollDs = DAOInsertPayroll.GetPayroll();
            int returnValue = 0;

            // Se crea la condición en la cual establecemos que los data set no estén vacios
            if (employeeDs != null && employeeDs.Tables.Count > 0 &&
                payrollDs != null && payrollDs.Tables.Count > 0)
            {
                // Creamos los dataTable
                DataTable employeeDt = employeeDs.Tables["tbEmployee"];
                DataTable payrollDt = payrollDs.Tables["tbPayroll"];

                // Verificamos que los dataTable no estén vacíos
                if (employeeDt != null && payrollDt != null)
                {
                    // Iteramos a través de todas las filas de la tabla employee
                    foreach (DataRow row in employeeDt.Rows)
                    {
                        // Verificar el estado del empleado
                        int status = int.Parse(row["IdStatus"].ToString());
                        int idEmployee = int.Parse(row["IdEmployee"].ToString());
                        DateTime hireDate = DateTime.Parse(row["hireDate"].ToString());
                        double salary = double.Parse(row["salary"].ToString());
                        DateTime now = DateTime.Now;
                        // Generacion de planillas para empleados inactivos
                        int totalMonthsWorked = ((now.Year - hireDate.Year) * 12) + now.Month - hireDate.Month;
                        double monthlyCompensation = salary / 12;
                        double compensation = 0.0;

                        if (status == 2)
                        {
                            if (totalMonthsWorked > 12)
                            {
                                // Caso de empleados que han trabajado un año o más
                                double totalYearsWorked = now.Year - hireDate.Year;
                                compensation = salary * totalYearsWorked;
                            }
                            else
                            {
                                // Caso de empleados que se van antes de un año
                                compensation = monthlyCompensation * totalMonthsWorked;
                            }

                            // Comprobar si ya existe una planilla de liquidación para el empleado
                            DataRow[] existingCompensationPayroll = payrollDt.Select($"IdEmployee = {idEmployee} AND IdPayrollStatus = 3");
                            if (existingCompensationPayroll.Length == 0)
                            {
                                // Calcular la renta aplicable a la indemnización (si corresponde)
                                double netPay = compensation;

                                // Crear y llenar un nuevo objeto DAOViewPayrolls para la planilla de liquidación
                                DAOInsertPayroll = new DAOViewPayrolls
                                {
                                    //En las liquidaciones se tienen que tener ciertos parámetros
                                    Username = row["username"].ToString(),
                                    Isss = 0.00,
                                    Afp = 0.00,
                                    Rent = 0.00,
                                    NetPay = netPay,
                                    IsssEmployer = 0.00,
                                    AfpEmployer = 0.00,
                                    DiscountEmployee = 0.00,
                                    DiscountEmployer = 0.00,
                                    IssueDate = DateTime.Now,
                                    IdEmployee = idEmployee,
                                    IdPayrollStatus = 3,
                                    ChristmasBonus = 0.00
                                };
                                returnValue = DAOInsertPayroll.AddPayroll();
                            }
                        }
                    }
                }
                RefreshData();
            }

            if (returnValue == 1)
            {
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"Las planillas de liquidación fueron ingresadas correctamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);

            }
            else
            {
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"Los datos no pudieron ser registrados", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);

            }
        }
        public void UpdatePayrollPaid(object sender, EventArgs e)
        {
            DAOViewPayrolls daoUpdate = new DAOViewPayrolls();
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            daoUpdate.IdPayroll = int.Parse(objViewPayrolls.dgvPayrolls[0, pos].Value.ToString());
            daoUpdate.IdPayrollStatus = 1;
            int returnedValues = daoUpdate.UpdatePayrollStatusPaid();
            if (returnedValues == 1)
            {
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"La planilla fue pagada exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);
            }
            else
            {
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"La planilla no pudo ser pagada", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);

            }
            RefreshData();
        }
        public void UpdatePayrollToUnpaid(object sender, EventArgs e)
        {
            DAOViewPayrolls daoUpdate = new DAOViewPayrolls();
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            daoUpdate.IdPayroll = int.Parse(objViewPayrolls.dgvPayrolls[0, pos].Value.ToString());
            daoUpdate.IdPayrollStatus = 2;
            int returnedValues = daoUpdate.UpdatePayrollStatusUnPaid();
            if (returnedValues == 1)
            {
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"El pago fue revertido exitosamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);

            }
            else
            {
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"El pago no pudo ser revertido", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);

            }
            RefreshData();
        }
        public void DeletePayrolls(object sender, EventArgs e)
        {
            // Creamos un objeto del DaoViewPayrolls
            DAOViewPayrolls DAOInsertPayroll = new DAOViewPayrolls();
            // Accedemos a los datos de los empleados y planillas
            DataSet employeeDs = DAOInsertPayroll.GetEmployee();
            DataSet payrollDs = DAOInsertPayroll.GetPayroll();
            int returnValue = 0;
            DataTable employeeDt = employeeDs.Tables["tbEmployee"];
            DataTable payrollDt = payrollDs.Tables["tbPayroll"];

            foreach (DataRow row in employeeDt.Rows)
            {
                // Verificar el estado del empleado (inactivo en este caso)
                int employeeStatus = int.Parse(row["IdStatus"].ToString());
                if (employeeStatus == 2)
                {
                    int idEmployee = int.Parse(row["IdEmployee"].ToString());
                    // Seleccionar todas las planillas no
                    // s de este empleado
                    DataRow[] unpaidPayrolls = payrollDt.Select($"IdEmployee = {idEmployee} AND IdPayrollStatus = 2");

                    // Eliminar cada planilla no pagada encontrada
                    foreach (DataRow payrollRow in unpaidPayrolls)
                    {
                        int idPayroll = int.Parse(payrollRow["IdPayroll"].ToString());
                        // Asignar el ID de la planilla a eliminar
                        DAOInsertPayroll.IdPayroll = idPayroll;
                        // Eliminar la planilla
                        returnValue = DAOInsertPayroll.DeletePayroll();
                    }
                }
            }
            // Refrescar los datos después de la eliminación
            RefreshData();
            if (returnValue == 1)
            {
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"Las planillas se eliminaron correctamente", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.BottomRight);

            }
            else
            {
                objViewPayrolls.bunifuSnackbar1.Show(objViewPayrolls, $"No hay empleados a los cuales eliminar planillas", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 5000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);

            }
        }
        #region Aca estan los metodos $$$$$$
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
            if (prerent >= 0 && prerent < 472.01)
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
        public double GetChristmasBonusRent(double Salary)
        {
            double rent;
            if (Salary > 1500 && Salary < 2038.11)
            {
                rent = ((Salary - 895.24) * 0.2) + 60;
            }
            else if (Salary > 2028.11)
            {
                rent = ((Salary - 2038.10) * 0.3) + 288.57;
            }
            else
            {
                rent = 0;
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
            DateTime endDate = new DateTime(year, 12, 12);
            if (hireDate > endDate)
            {
                // Si la fecha de contratación es después del 15 de diciembre, el aguinaldo es 0
                return 0;
            }
            int workedYears = year - hireDate.Year;
            double christmasBonus;

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
        #endregion
        //------------------Busqueda----------------------//
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
            objViewPayrolls.dgvPayrolls.Columns[7].Visible = false;
            objViewPayrolls.dgvPayrolls.Columns[8].Visible = false;

        }
        public void Disable(object sender, EventArgs e)
        {
            DAOViewPayrolls objDisable = new DAOViewPayrolls();
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            if (objViewPayrolls.dgvPayrolls[14, pos].Value.ToString() == "Pagada" /*&& objDisable.StatusPayroll == 1*/)
            {
                objViewPayrolls.cmsUpdateUnpaid.Visible = true;
                objViewPayrolls.cmsPayPayroll.Visible = false;
                objViewPayrolls.cmsUpdatePayroll.Visible = false;
            }
            else
            {
                objViewPayrolls.cmsUpdateUnpaid.Visible = false;
                objViewPayrolls.cmsPayPayroll.Visible = true;
                objViewPayrolls.cmsUpdatePayroll.Visible = true;

            }
        }

        //----------------------Metodos de interaccion con otros formularios---------------------------//
        public void OpenUpdatePayroll(object sender, EventArgs e)
        {
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            int  nP, daysWorked, hoursWorked, extraHours;
            string employee, dui, possition, bankAccount, affiliationNumber;
            double salary, bonus, afp, isss, rent, discountEmployee, netSalary, daySalary, grossPay, hourSalary;
            DateTime issueDate;
            nP = int.Parse(objViewPayrolls.dgvPayrolls[0, pos].Value.ToString());
            dui = objViewPayrolls.dgvPayrolls[1, pos].Value.ToString();
            employee = objViewPayrolls.dgvPayrolls[2, pos].Value.ToString();
            salary = double.Parse(objViewPayrolls.dgvPayrolls[3, pos].Value.ToString());
            bonus = double.Parse(objViewPayrolls.dgvPayrolls[4, pos].Value.ToString());
            grossPay = double.Parse(objViewPayrolls.dgvPayrolls[5, pos].Value.ToString());
            possition = objViewPayrolls.dgvPayrolls[6, pos].Value.ToString();
            bankAccount = objViewPayrolls.dgvPayrolls[7, pos].Value.ToString();
            affiliationNumber = objViewPayrolls.dgvPayrolls[8, pos].Value.ToString();
            afp = double.Parse(objViewPayrolls.dgvPayrolls[9, pos].Value.ToString());
            isss = double.Parse(objViewPayrolls.dgvPayrolls[10, pos].Value.ToString());
            rent = double.Parse(objViewPayrolls.dgvPayrolls[11, pos].Value.ToString());
            netSalary = double.Parse(objViewPayrolls.dgvPayrolls[12, pos].Value.ToString());
            discountEmployee = isss + afp + rent;
            issueDate = DateTime.Parse(objViewPayrolls.dgvPayrolls[13, pos].Value.ToString());
            daysWorked = int.Parse(objViewPayrolls.dgvPayrolls[16,pos].Value.ToString());
            daySalary = double.Parse(objViewPayrolls.dgvPayrolls[17, pos].Value.ToString());
            hoursWorked = int.Parse(objViewPayrolls.dgvPayrolls[18, pos].Value.ToString());
            hourSalary = double.Parse(objViewPayrolls.dgvPayrolls[19,pos].Value.ToString());
            extraHours = int.Parse(objViewPayrolls.dgvPayrolls[20, pos].Value.ToString());
            FrmUpdatePayroll openForm = new FrmUpdatePayroll(nP, dui, employee, salary, possition, bonus, bankAccount, affiliationNumber, afp, isss, rent, netSalary, discountEmployee, issueDate, daysWorked, daySalary, grossPay, hoursWorked, hourSalary, extraHours);
            openForm.ShowDialog();
            RefreshData();
        }

        private void ViewInfoPayroll(object sender, EventArgs e)
        {
            int pos = objViewPayrolls.dgvPayrolls.CurrentRow.Index;
            int daysWorked;
            string employee, dui, possition, bankAccount, payrollStatus, affiliationNumber;
            double salary, bonus, afp, isss, rent, discountEmployee, netSalary, issEmployer, afpEmployer, discountEmployer, christmasBonus, grossPay, daySalary;
            DateTime issueDate;
            dui = objViewPayrolls.dgvPayrolls[1, pos].Value.ToString();
            employee = objViewPayrolls.dgvPayrolls[2, pos].Value.ToString();
            salary = double.Parse(objViewPayrolls.dgvPayrolls[3, pos].Value.ToString());
            bonus = double.Parse(objViewPayrolls.dgvPayrolls[4, pos].Value.ToString());
            grossPay = double.Parse(objViewPayrolls.dgvPayrolls[5, pos].Value.ToString());
            possition = objViewPayrolls.dgvPayrolls[6, pos].Value.ToString();
            bankAccount = objViewPayrolls.dgvPayrolls[7, pos].Value.ToString();
            affiliationNumber = objViewPayrolls.dgvPayrolls[8, pos].Value.ToString();
            afp = double.Parse(objViewPayrolls.dgvPayrolls[9, pos].Value.ToString());
            isss = double.Parse(objViewPayrolls.dgvPayrolls[10, pos].Value.ToString());
            rent = double.Parse(objViewPayrolls.dgvPayrolls[11, pos].Value.ToString());
            netSalary = double.Parse(objViewPayrolls.dgvPayrolls[12, pos].Value.ToString());
            discountEmployee = isss + afp + rent;
            double calculatedSalary = bonus + salary;
            issueDate = DateTime.Parse(objViewPayrolls.dgvPayrolls[13, pos].Value.ToString());
            issEmployer = GetISSSEmployeer(calculatedSalary);
            afpEmployer = GetAFPEmployer(calculatedSalary);
            discountEmployer = issEmployer + afpEmployer;
            payrollStatus = objViewPayrolls.dgvPayrolls[14, pos].Value.ToString();
            christmasBonus = double.Parse(objViewPayrolls.dgvPayrolls[15, pos].Value.ToString());
            daysWorked = int.Parse(objViewPayrolls.dgvPayrolls[16, pos].Value.ToString());
            daySalary = double.Parse(objViewPayrolls.dgvPayrolls[17, pos].Value.ToString());
            FrmInfoPayroll openForm = new FrmInfoPayroll(dui, employee, possition, bonus, bankAccount, affiliationNumber, salary, grossPay, afp, isss, rent, netSalary, discountEmployee, issueDate, christmasBonus, issEmployer, afpEmployer, discountEmployer, payrollStatus, daysWorked,daySalary);
            openForm.ShowDialog();
            RefreshData();
        }
        #region Aca estan los metodos para los checkbox
        public void SearchAll(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.GetEmployeesDgv();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void SearchByFirstTrimester(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SerachPayrollFirstTrimester();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void SearchBySecondTrimester(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SerachPayrollSecondTrimester();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void SearchByThirthTrimester(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SerachPayrollThirthTrimester();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void SearchByFourthTrimester(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SerachPayrollFourthTrimester();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
        }
        public void SearchByMonth1(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollJanuary();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch1.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByMonth2(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollFebruary();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch2.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByMonth3(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollMarch();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch3.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByMonth4(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollApril();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch4.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByMonth5(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollMay();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch5.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByMonth6(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollJune();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch6.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByMonth7(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollJuly();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch7.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByMonth8(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollAgust();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch8.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByMonth9(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollSeptember();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch9.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByMonth10(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollOctober();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch10.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByMonth11(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollNovember();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch11.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByMonth12(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPayrollDecember();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.ch12.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByPaid(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchPaidPayrols();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.chPaid.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByUnpaid(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearchUnpaidPayrols();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.chuUnpaid.Checked == false)
            {
                RefreshData();
            }
        }
        public void SearchByCompensation(object sender, EventArgs e)
        {
            DAOViewPayrolls objSearch = new DAOViewPayrolls();
            DataSet ds = objSearch.SearcCompensationPayrols();
            objViewPayrolls.dgvPayrolls.DataSource = ds.Tables["viewPayrolls"];
            if (objViewPayrolls.chCompensation.Checked == false)
            {
                RefreshData();
            }
        }
        #endregion
    }
}
