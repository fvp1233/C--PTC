using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DTO.ServicesDTO;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.ServicesDAO
{
    internal class DAOServices : DTOServices
    {

        readonly SqlCommand command = new SqlCommand();

        public DataSet GetDataTable()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM viewServices";

                SqlCommand cmd = new SqlCommand(query, command.Connection);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                adp.Fill(ds, "tbServices");
                return ds;

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public int DeleteService()
        {
            try
            {
                command.Connection = getConnection();
                string query = "Exec spDeleteService @Id";

                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@Id", IdService1);

                int respuesta = cmd.ExecuteNonQuery();

                return respuesta;

            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet SearchData(string consulta)
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM viewServices WHERE [Nombre servicio] LIKE @consulta OR [Descripción] LIKE @consulta";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@consulta", "%" + consulta + "%");
                cmd.ExecuteNonQuery();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                adp.Fill(ds, "viewServices");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
            finally 
            {
                command.Connection.Close();
            }
        }

        public DataSet SearchDataCb(string categoria)
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM viewServices Where [Categoría] = @categoria";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@categoria", categoria);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                adp.Fill(ds, "viewServices");
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                command.Connection.Close(); 
            }
        }
    }

}


