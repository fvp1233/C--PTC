using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTC2024.Model.DTO.ServicesDTO;

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

        public DataSet SearchData (string consulta)
        { 
            command.Connection = getConnection();
            string query = $"Select * From viewServices Where [Nombre servicio] Like '%{consulta}' Or [Descripción] Like '%{consulta}%'";
            SqlCommand cmd = new SqlCommand (query, command.Connection);
            cmd.ExecuteNonQuery();

            SqlDataAdapter adp =new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            adp.Fill(ds, "viewServices");
            return ds;
        }
    }

}
