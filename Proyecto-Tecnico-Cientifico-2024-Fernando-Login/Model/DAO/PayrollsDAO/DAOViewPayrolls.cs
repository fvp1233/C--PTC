using PTC2024.Model.DTO.PayrollDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PTC2024.Model.DAO.PayrollsDAO
{
    internal class DAOViewPayrolls : DTOViewPayrolls
    {
        readonly SqlCommand comand = new SqlCommand();

        public DataSet GetEmployee()
        {
            try
            {
                comand.Connection = getConnection();
                string queryEmployee = "SELECT * FROM tbEmployee";
                SqlCommand cmdEmployeeInfo = new SqlCommand(@queryEmployee, comand.Connection);
                cmdEmployeeInfo.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdEmployeeInfo);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbEmployee");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-045: No se pudieron obtener los datos de los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet GetUsername()
        {
            try
            {
                comand.Connection = getConnection();
                string queryUserData = "SELECT * FROM tbUserData";
                SqlCommand cmdUserData = new SqlCommand(queryUserData, comand.Connection);
                cmdUserData.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdUserData);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbUserData");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-046: No se pudieron obtener los datos de los usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet GetBonus()
        {
            try
            {
                comand.Connection = getConnection();
                string queryBonus = "SELECT * FROM tbBusinessP";
                SqlCommand cmdBonus = new SqlCommand(queryBonus, comand.Connection);
                cmdBonus.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdBonus);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbBusinessP");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-047: No se pudieron obtener los datos de las posiciones del negocio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet GetPayroll()
        {
            try
            {
                comand.Connection = getConnection();
                string queryPayroll = "SELECT * FROM tbPayroll";
                SqlCommand cmdPayroll = new SqlCommand(@queryPayroll, comand.Connection);
                cmdPayroll.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdPayroll);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbPayroll");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-048: No se pudieron obtener los datos de las planillas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public int AddPayroll()
        {
            try
            {
                GetEmployee();
                comand.Connection = getConnection();
                string queryPayroll = "INSERT INTO tbPayroll VALUES (@netPay,@rent,@issueDate,@AFP, @ISSS,@ISSEmployer,@AFPEmployer,@employeeDiscount,@employerDiscount, @christmasBonus, @IdEmployee,@IdPayrollStatus, @daysWorked, @daySalary, @grossSalary, @hoursWorked, @hourSalary, @extraHours)";
                SqlCommand cmdAddPayroll = new SqlCommand(@queryPayroll, comand.Connection);
                cmdAddPayroll.Parameters.AddWithValue("netPay", NetPay);
                cmdAddPayroll.Parameters.AddWithValue("rent", Rent);
                cmdAddPayroll.Parameters.AddWithValue("issueDate", IssueDate);
                cmdAddPayroll.Parameters.AddWithValue("AFP", Afp);
                cmdAddPayroll.Parameters.AddWithValue("ISSS", Isss);
                cmdAddPayroll.Parameters.AddWithValue("ISSEmployer", IsssEmployer);
                cmdAddPayroll.Parameters.AddWithValue("AFPEmployer", AfpEmployer);
                cmdAddPayroll.Parameters.AddWithValue("employeeDiscount", DiscountEmployee);
                cmdAddPayroll.Parameters.AddWithValue("employerDiscount", DiscountEmployer);
                cmdAddPayroll.Parameters.AddWithValue("christmasBonus", ChristmasBonus);
                cmdAddPayroll.Parameters.AddWithValue("IdEmployee", IdEmployee);
                cmdAddPayroll.Parameters.AddWithValue("IdPayrollStatus", IdPayrollStatus);
                cmdAddPayroll.Parameters.AddWithValue("daysWorked", DaysWorked);
                cmdAddPayroll.Parameters.AddWithValue("daySalary", DaySalary);
                cmdAddPayroll.Parameters.AddWithValue("grossSalary", GossSalary);
                cmdAddPayroll.Parameters.AddWithValue("hoursWorked", HoursWorked);
                cmdAddPayroll.Parameters.AddWithValue("hourSalary", HourSalary);
                cmdAddPayroll.Parameters.AddWithValue("extraHours", ExtraHours);

                int answer = cmdAddPayroll.ExecuteNonQuery();
                if (answer == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-049: No se pudieron insertar los datos de las planillas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                comand.Connection.Close();
            }
        }
        public DataSet GetEmployeesDgv()
        {
            try
            {
                //Acceder a la conexion de la base de datos
                comand.Connection = getConnection();
                string queryEmployeeDgv = "SELECT * FROM viewPayrolls";
                //Creamos el sqlCommand al cual le pasaremos la instruccion de la db
                SqlCommand cmd = new SqlCommand(queryEmployeeDgv, comand.Connection);
                cmd.ExecuteNonQuery();
                //Creamos un adaptador para llenar el dataset
                SqlDataAdapter adpEmployeeDgv = new SqlDataAdapter(cmd);
                //Creamos un objeto dataset que es done se devolveran los resultados
                DataSet dsEmployeeDgv = new DataSet();
                //Rellenamos con el adaptador el dataset y le indicamos de donde provienen los datos
                adpEmployeeDgv.Fill(dsEmployeeDgv, "viewPayrolls");
                return dsEmployeeDgv;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-050: No se pudieron obtener los datos de la vista viewPayrolls", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public int DeletePayroll()
        {
            try
            {
                comand.Connection = getConnection();
                string query = "DELETE tbPayroll WHERE IdPayroll = @param1";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                cmd.Parameters.AddWithValue("param1", IdPayroll);
                int respuesta = cmd.ExecuteNonQuery();
                return respuesta;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-051: No se pudieron eliminar las planillas de los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
            finally
            {
                getConnection().Close();
            }

        }
        public int UpdatePayroll()
        {
            try
            {
                comand.Connection = getConnection();
                string query = "UPDATE tbPayroll SET netPay = @netPay, rent = @rent, AFP = @AFP, ISSS = @ISSS, ISSSEmployer = @ISSSEmployer, AFPEmployer = @AFPEmployer, employeeDiscount = @employeeDiscount, employerDiscount = @employerDiscount, christmasBonus = @christmasBonus, grossSalary = @grossSalary , daySalary = @daySalary, hoursWorked = @hoursWorked, hourSalary = @hourSalary, extraHours = @extraHours WHERE IdPayroll = @IdPayroll AND IdPayrollStatus = 2";
                SqlCommand cmdUpdatePayroll = new SqlCommand(query, comand.Connection);

                cmdUpdatePayroll.Parameters.AddWithValue("netPay", NetPay);
                cmdUpdatePayroll.Parameters.AddWithValue("rent", Rent);
                cmdUpdatePayroll.Parameters.AddWithValue("AFP", Afp);
                cmdUpdatePayroll.Parameters.AddWithValue("ISSS", Isss);
                cmdUpdatePayroll.Parameters.AddWithValue("ISSSEmployer", IsssEmployer);
                cmdUpdatePayroll.Parameters.AddWithValue("AFPEmployer", AfpEmployer);
                cmdUpdatePayroll.Parameters.AddWithValue("employeeDiscount", DiscountEmployee);
                cmdUpdatePayroll.Parameters.AddWithValue("employerDiscount", DiscountEmployer);
                cmdUpdatePayroll.Parameters.AddWithValue("christmasBonus", ChristmasBonus);
                cmdUpdatePayroll.Parameters.AddWithValue("IdPayroll", IdPayroll);
                cmdUpdatePayroll.Parameters.AddWithValue("IdPayrollStatus", IdPayrollStatus);
                cmdUpdatePayroll.Parameters.AddWithValue("grossSalary", GossSalary);
                cmdUpdatePayroll.Parameters.AddWithValue("daySalary", DaySalary);
                cmdUpdatePayroll.Parameters.AddWithValue("hoursWorked", HoursWorked);
                cmdUpdatePayroll.Parameters.AddWithValue("hourSalary", HourSalary);
                cmdUpdatePayroll.Parameters.AddWithValue("extraHours", ExtraHours);
                int answer = cmdUpdatePayroll.ExecuteNonQuery();
                return answer;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-052: No se pudieron actualizar las planillas de los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                comand.Connection.Close();
            }
        }
        public int UpdatePayrollStatusPaid()
        {
            try
            {
                comand.Connection = getConnection();
                string query = "UPDATE tbPayroll SET IdPayrollStatus = 1 WHERE IdPayroll = @IdPayroll";
                SqlCommand cmdUpdate = new SqlCommand(query, comand.Connection);
                cmdUpdate.Parameters.AddWithValue("IdPayroll", IdPayroll);
                cmdUpdate.Parameters.AddWithValue("IdPayrollStats", IdPayrollStatus);
                int answer = cmdUpdate.ExecuteNonQuery();
                return answer;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-053: No se pudieron actualizar las planillas de los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                comand.Connection.Close();
            }
        }
        public int UpdatePayrollStatusUnPaid()
        {
            try
            {
                comand.Connection = getConnection();
                string query = "UPDATE tbPayroll SET IdPayrollStatus = 2 WHERE IdPayroll = @IdPayroll";
                SqlCommand cmdUpdate = new SqlCommand(query, comand.Connection);
                cmdUpdate.Parameters.AddWithValue("IdPayroll", IdPayroll);
                cmdUpdate.Parameters.AddWithValue("IdPayrollStats", IdPayrollStatus);
                int answer = cmdUpdate.ExecuteNonQuery();
                return answer;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-054: No se pudieron actualizar las planillas de los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            finally
            {
                comand.Connection.Close();
            }
        }

        public DataSet SearchPayroll(string valor)
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE [DUI] LIKE '%{valor}%' OR [Empleado] LIKE '%{valor}%' OR [Fecha de emisión] LIKE '%{valor}%'";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-055: No se pudieron obtener las planillas de los empleados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SerachPayrollFirstTrimester()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) BETWEEN 1 AND 3";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-056: No se pudieron obtener las planillas del primer trimestre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SerachPayrollSecondTrimester()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) BETWEEN 4 AND 6";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-057: No se pudieron obtener las planillas del segundo trimestre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SerachPayrollThirthTrimester()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) BETWEEN 7 AND 9";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-058: No se pudieron obtener las planillas del tercer trimestre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SerachPayrollFourthTrimester()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) BETWEEN 10 AND 12";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-059: No se pudieron obtener las planillas del cuarto trimestre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPayrollJanuary()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 1";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-060: No se pudieron obtener las planillas del primer mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }

        public DataSet SearchPayrollFebruary()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 2";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-061: No se pudieron obtener las planillas del segundo mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPayrollMarch()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 3";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-062: No se pudieron obtener las planillas del tercer mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPayrollApril()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 4";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-063: No se pudieron obtener las planillas del cuarto mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPayrollMay()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 5";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-064: No se pudieron obtener las planillas del quinto mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPayrollJune()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 6";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-065: No se pudieron obtener las planillas del sexto mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPayrollJuly()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 7";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-066: No se pudieron obtener las planillas del septimo mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPayrollAgust()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 8";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-067: No se pudieron obtener las planillas del octavo mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPayrollSeptember()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 8";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-068: No se pudieron obtener las planillas del noveno mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPayrollOctober()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 10";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-069: No se pudieron obtener las planillas del decimo mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPayrollNovember()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 11";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-070: No se pudieron obtener las planillas del decimoprimer mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPayrollDecember()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE MONTH([Fecha de emisión]) = 12";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-071: No se pudieron obtener las planillas del decimosegundo mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchPaidPayrols()
        {
            try
            {
                comand.Connection= getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE ([Estado]) = 'Pagada'";
                SqlCommand cmd = new SqlCommand (query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-072: No se pudieron obtener las planillas pagadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearchUnpaidPayrols()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE ([Estado]) = 'No Pagada'";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-073: No se pudieron obtener las planillas no pagadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet SearcCompensationPayrols()
        {
            try
            {
                comand.Connection = getConnection();
                string query = $"SELECT * FROM viewPayrolls WHERE ([Estado]) = 'Indemnización'";
                SqlCommand cmd = new SqlCommand(query, comand.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "viewPayrolls");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-074: No se pudieron obtener las planillas de liquidación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
        public DataSet GetBusiness()
        {
            try
            {
                comand.Connection = getConnection();
                string query = "SELECT * FROM tbBusinessInfo";
                SqlCommand cmdBonus = new SqlCommand(query, comand.Connection);
                cmdBonus.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmdBonus);
                DataSet ds = new DataSet();
                adp.Fill(ds, "tbBusinessInfo");
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-133: No se pudo obtener los datos de la empresa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }

    }
}
