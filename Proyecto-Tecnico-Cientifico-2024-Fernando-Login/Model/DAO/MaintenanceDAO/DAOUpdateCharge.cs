using PTC2024.Model.DTO.MaintenanceDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.MaintenanceDAO
{
    internal class DAOUpdateCharge: DTOUpdateCharge
    {
        readonly SqlCommand Command = new SqlCommand();
        public int UpdateCharge()
        {
            try
            {
                Command.Connection = getConnection();
                string query = "UPDATE tbBusinessP SET " + "businessPosition = @param1, " + "positionBonus = @param2" + " WHERE IdBusinessP = @param3";
                SqlCommand cmd = new SqlCommand(query, Command.Connection);
                cmd.Parameters.AddWithValue("param1", NameCharge);
                cmd.Parameters.AddWithValue("param2", BonusCharge);
                cmd.Parameters.AddWithValue("param3", IdCharge);
                int answerd = cmd.ExecuteNonQuery();
                return answerd;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-118: No se pudieron actualizar los cargos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Se retorna -1 en caso que en el segmento del try haya ocurrido algún error.
                return -1;
            }
            finally
            {
                //Independientemente se haga o no el proceso cerramos la conexión
                getConnection().Close();
            }
        }
    }
}
