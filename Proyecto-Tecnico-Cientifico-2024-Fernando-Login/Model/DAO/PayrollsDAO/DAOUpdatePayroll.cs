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
				string query = "UPDATE tbPayroll SET IdPayrollStatus = @param1 WHERE IdPayroll = @param2";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("@param1", IdPayrollStatus);
                cmd.Parameters.AddWithValue("@param2", IdPayroll);
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
