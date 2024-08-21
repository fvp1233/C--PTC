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
    internal class DAOCategories : DTOCategories
    {
        readonly SqlCommand command = new SqlCommand();

        public int AddCategorie()
        {
            try
            {
                command.Connection = getConnection();
                string query = "INSERT INTO tbCategoryS(categoryName) VALUES (@param1)";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("param1", Category);
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int DeleteCategorie()
        {
            try
            {
                command.Connection = getConnection();
                string query = "DELETE FROM tbCategoryS WHERE IdCategory = @param1";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("param1", IdCategory);
                int answer = cmd.ExecuteNonQuery();
                return answer;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return -1;

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error");
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet GetCategories()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM viewCategories";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet dsCategory = new DataSet();
                adp.Fill(dsCategory, "viewCategories");
                return dsCategory;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
