using PTC2024.Model.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PTC2024.Model.DAO
{
    internal class DAOAddEmployee : DTOAddEmployee
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet ObtenerEstadosCiviles()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM estadoCivil";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "estadoCivil");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-002: No se puedieron obtener los datos de los Estados Civiles");
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet ObtenerDepartamentos()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM departamentos";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "departamentos");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-003: No se puedieron obtener los datos de los Departamentos");
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet ObtenerTiposEmpleado()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM tipoEmpleado";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "tipoEmpleado");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-004: No se puedieron obtener los datos de los Tipos de Empleado");
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet ObtenerPuestosEmpleado()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM puestoEmpleado";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "puestoEmpleado");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-005: No se puedieron obtener los datos de los Puestos de empleado");
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public DataSet ObtenerEstadosEmpleado()
        {
            try
            {
                command.Connection = getConnection();
                string query = "SELECT*FROM estadoEmpleado";
                SqlCommand cmd = new SqlCommand(query, command.Connection);
                cmd.ExecuteNonQuery();

                //El adaptador recibe la info que encontró el "cmd"
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //el siguiente dataset va a ser el que el método va a devolver
                DataSet ds = new DataSet();

                //se llena el dataset "ds" con la información que recibió el adaptador "adp"
                adp.Fill(ds, "estadoEmpleado");

                //se devuelve el dataset
                return ds;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("EC-003: No se puedieron obtener los datos de los Estados de Empleado");
                return null;
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
