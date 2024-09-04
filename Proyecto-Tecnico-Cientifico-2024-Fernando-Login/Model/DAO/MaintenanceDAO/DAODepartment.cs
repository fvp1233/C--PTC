using PTC2024.Model.DTO.MaintenanceDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.MaintenanceDAO
{
    internal class DAODepartment:DTODepartment
    {
		readonly SqlCommand Command = new SqlCommand();
        public int AddDepartment()
        {
			try
			{
				Command.Connection = getConnection();
				string query = "INSERT INTO tbDepartment (departmentName) VALUES(@departmentName)";
				SqlCommand cmd = new SqlCommand(query, Command.Connection);
				cmd.Parameters.AddWithValue("departmentName", Department);
				int answer = cmd.ExecuteNonQuery();
				return answer;

            }
			catch (Exception)
			{
                MessageBox.Show("EC-118: No se pudieron agregar los departamentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
			}
			finally
			{
				Command.Connection = getConnection();
			}
        }
		public DataSet GetDepartmentDgv()
		{
			try
			{
				Command.Connection = getConnection();
				string query = "SELECT IdDepartment, departmentName AS Departamento FROM tbDepartment;";
				SqlCommand cmd = new SqlCommand(query,Command.Connection);
				cmd.ExecuteNonQuery();
				SqlDataAdapter adp = new SqlDataAdapter(cmd);
				DataSet dsDepartment = new DataSet();
				adp.Fill(dsDepartment, "tbDepartment");
				return dsDepartment;
			}
            catch (Exception)
            {
                MessageBox.Show("EC-119: No se pudieron obtener los departamentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                getConnection().Close();
            }
        }
		public int DeleteDepartment()
		{
			try
			{
				Command.Connection = getConnection();
				string query = "DELETE tbDepartment WHERE IdDepartment = @param1";
				SqlCommand cmd = new SqlCommand(query, Command.Connection);
				cmd.Parameters.AddWithValue("param1", IdDepartment);
				int answer = cmd.ExecuteNonQuery();
				return answer;
			}
            catch (Exception)
            {
                MessageBox.Show("EC-120: No se pudieron eliminar los departamentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
            finally
            {
                getConnection().Close();
            }
        }
    }
}
