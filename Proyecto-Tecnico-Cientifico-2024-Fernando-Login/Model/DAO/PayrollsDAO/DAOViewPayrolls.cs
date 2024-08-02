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
                string queryPayroll = "INSERT INTO tbPayroll VALUES (@netPay,@rent,@issueDate,@AFP, @ISSS,@ISSEmployer,@AFPEmployer,@employeeDiscount,@employerDiscount, @christmasBonus, @IdEmployee,@IdPayrollStatus)";
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
                cmdAddPayroll.Parameters.AddWithValue("@IdPayroll", IdPayroll);
                cmdAddPayroll.Parameters.AddWithValue("IdPayrollStatus", IdPayrollStatus);

                int answer = cmdAddPayroll.ExecuteNonQuery();
                if (answer == 1)
                {
                    return 1;
                }
                else { return 0; }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"EC-002: {ex.Message}", "Error Critico", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                return -1;
            }
            finally
            {
                getConnection().Close();
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
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }


    }
}
