using PTC2024.Model.DTO.PayrollDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.PayrollsDAO
{
    internal class DAOUpdatePayroll:DTOUpdatePayroll
    {
		readonly SqlCommand Command = new SqlCommand();
		public int UpdatePayroll()
		{
			try
			{
				//Creamos la conexion para garantizar que este conectado a la base
				Command.Connection = getConnection();
				//Creamos el query
				string query = "UPDATE tbPayroll SET daysWorked = @param1, daySalary = @param2, hoursWorked = @param3, hourSalary = @param4, extraHours = @param5 WHERE IdPayroll = @param6";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
				cmd.Parameters.AddWithValue("@param1", DaysWorked);
				cmd.Parameters.AddWithValue("@param2", DaySalary);
				cmd.Parameters.AddWithValue("@param3", HoursWorked);
				cmd.Parameters.AddWithValue("@param4", HoursSalary);
                cmd.Parameters.AddWithValue("@param5", ExtraHours);
				cmd.Parameters.AddWithValue("@param6", IdPayroll);
				int answer = cmd.ExecuteNonQuery();
				return answer;

			}
			catch (Exception e)
			{
				MessageBox.Show($"Excepcion{e}");
				return -1;
			}
			finally 
			{
				getConnection().Close(); 
			}
		}
		public DataSet FillStatus()
		{
			try
			{
				Command.Connection= getConnection();
				string query = "SELECT * FROM tbPayrollStatus";
				SqlCommand cmd = new SqlCommand(query, Command.Connection);
				cmd.ExecuteNonQuery();
				SqlDataAdapter adp = new SqlDataAdapter(cmd);
				DataSet ds = new DataSet();
				adp.Fill(ds,"tbPayrollStatus");
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
