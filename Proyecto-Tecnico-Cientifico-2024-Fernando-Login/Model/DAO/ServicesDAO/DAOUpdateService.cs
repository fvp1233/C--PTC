﻿using PTC2024.Model.DTO.ServicesDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO.ServicesDAO
{
    internal class DAOUpdateService : DTOUpdateService
    {
        /*Se declara el comando Sql*/
        readonly SqlCommand command = new SqlCommand();

        /*Este metodo llenara los combobox*/
        public DataSet GetCategories()
        {
            try
            {
                /*Se declara y abre la conexion*/
                command.Connection = getConnection();
                /*Se declara la consulta*/
                string query = "Select * From tbCategoryS";

                /*Se declara el comando que contiene la consulta y la conexion*/
                SqlCommand cmd = new SqlCommand(query, command.Connection);

                /*Se ejecuta la consulta*/
                cmd.ExecuteNonQuery();

                /*Se guarda la respuesta del cmd*/
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                /*Se llena el DataSet*/
                adp.Fill(ds, "tbCategoryS");

                /*Se retorna el DataSet*/
                return ds;
            }
            catch (Exception)
            {
                MessageBox.Show("EC-100: No se pudo obtener las categorias de servicios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                /*En caso haiga un fallo se retornara un valor nulo*/
                return null;
            }
            finally
            {
                /*Por ultimo se cierra la conexion*/
                command.Connection.Close();
            }


        }


        /*Este metodo actualizara los servicios*/
        public int UpdateService()
        {
            try
            {
                /*Se declara y abre la conexion*/
                command.Connection = getConnection();
                /*Se declara la consulta*/
                string query = "Exec spUpdateService @Nombre, @Descripcion, @Monto, @Categoria, @Id";

                /*Se declara el comando que contiene la consulta y la conexion*/
                SqlCommand cmd = new SqlCommand(query, command.Connection);

                /*Se les asigna un valor a los parametros de la consulta*/
                cmd.Parameters.AddWithValue("@Nombre", Name);
                cmd.Parameters.AddWithValue("@Descripcion", Description);
                cmd.Parameters.AddWithValue("@Monto", Amount);
                cmd.Parameters.AddWithValue("@Categoria", Category);
                cmd.Parameters.AddWithValue("@Id", ServiceId);

                /*Se ejecuta la consulta cuyo valor se guardara en la variable respuesta*/
                int answer = cmd.ExecuteNonQuery();

                /*Se retornara la respuesta*/
                return answer;

            }
            catch (Exception)
            {
                MessageBox.Show("EC-101: No se pudo actualizar el servicios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                /*En caso ocurra un error se retornara -1*/
                return -1;
            }
            finally
            {
                /*Por ultimo se cierra la conexion*/
                command.Connection.Close();
            }

        }
    }
}


