using PTC2024.Model.DTO.ServicesDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace PTC2024.Model.DAO.ServicesDAO
{
    internal class DAOAddService : DTOAddService
    {

        readonly SqlCommand command = new SqlCommand();

        
        public DataSet ObtenerCategoriasServicios()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT * FROM tbCategoryS";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();       
                /* Aca se recolecta lo que devolvio el cmd */        
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                adp.Fill(ds, "tbCategoryS");
                return ds;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-003: No se pudieron obtener las categorias de los servicios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            finally
            {
                command.Connection.Close();
            }


        }

        public int InsertService()
        {
            try
            {
                command.Connection = getConnection();
                string query2 = "Exec spInsertDataService @NombreS, @DescripcionS, @MontoS, @Categoria";
                SqlCommand cmd2 = new SqlCommand(query2, command.Connection);
                cmd2.Parameters.AddWithValue("@NombreS", Nombre);
                cmd2.Parameters.AddWithValue("@DescripcionS", Descripcion);
                cmd2.Parameters.AddWithValue("@MontoS", Monto);
                cmd2.Parameters.AddWithValue("@Categoria", Categorias);

                int answer = cmd2.ExecuteNonQuery();
                if (answer == 1)
                {
                    return answer;
                }
                else
                {
                    return 0;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
            finally
            {
                command.Connection.Close();
            }

        }
    }
}
