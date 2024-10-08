﻿using PTC2024.Model.DTO.ServicesDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DAO.ServicesDAO
{
    internal class DAOAgendaService : DTOAgendaService
    {
        readonly SqlCommand command = new SqlCommand();

        public DataSet ChargeData()
        {
            try
            {
                command.Connection = getConnection();

                string query = "Select * From viewAgendaS";

                SqlCommand cmd = new SqlCommand(query, command.Connection);

                cmd.ExecuteNonQuery();

                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(ds, "viewAgendaS");

                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataSet FilterData(string value)
        {
            try
            {
                command.Connection = getConnection();

                string query = $"Select * From viewAgendaS Order By [{value}] Asc";

                SqlCommand cmd = new SqlCommand(query, command.Connection);

                cmd.ExecuteNonQuery();

                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(ds, "viewAgendaS");

                return ds;

            }
            catch (Exception)
            {

                throw;
            }
        }


        public DataSet SearchData(string value)
        {
            try
            {
                command.Connection = getConnection();

                string query = $"Select * From viewAgendaS Where Cliente Like '%{value}%' Or Descripción Like '%{value}%' Or Servicio Like '%{value}%'";

                SqlCommand cmd = new SqlCommand(query, command.Connection);

                cmd.ExecuteNonQuery();

                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(ds, "viewAgendaS");

                return ds;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
