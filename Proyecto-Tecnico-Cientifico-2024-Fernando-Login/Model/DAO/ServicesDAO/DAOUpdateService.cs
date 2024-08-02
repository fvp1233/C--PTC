using PTC2024.Model.DTO.ServicesDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DAO.ServicesDAO
{
    internal class DAOUpdateService : DTOUpdateService
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet GetCategories()
        {
            try
            {
                command.Connection = getConnection();
                string query = "Select * From tbCategoryS";

                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();


                adp.Fill(ds, "tbCategoryS");

                return ds;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                command.Connection.Close();
            }


        }

        public int UpdateService()
        {
            try
            {
                command.Connection = getConnection();
                string query = "Exec spUpdateService @Nombre, @Descripcion, @Monto, @Categoria, @Id";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@Monto", Monto);
                cmd.Parameters.AddWithValue("@Categoria", Categoria);
                cmd.Parameters.AddWithValue("@Id", ServiceId);

                int respuesta = cmd.ExecuteNonQuery();

                return respuesta;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                command.Connection.Close();
            }

        }
    }
}


