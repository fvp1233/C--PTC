using PTC2024.Model.DTO.EmployeesDTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DAO.EmployeesDAO
{
    internal class DAOUpdateEmployee : DTOUpdateEmployee
    {
        readonly SqlCommand Command = new SqlCommand();

        //public int UpdateEmployee()
        //{
        //    try
        //    {
        //        //Se crea la conexión a la base
        //        Command.Connection = getConnection();

        //        //Se crea el query para actualizar al empleado 
        //        string queryUpdateE = "UPDATE tbEmployee SET " +
        //                               "names = @param1, " +
        //                               "lastName = @param2, " +
        //                               "DUI = @param3, " +
        //                               "birthDate = @param4, " +
        //                               "email = @param5, " +
        //                               "phone = @param6, " +
        //                               "adress = @param7, " +
        //                               "salary = @param8, " +
        //                               "bankAccount = @param9, " +
        //                               ""
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}
    }
}
