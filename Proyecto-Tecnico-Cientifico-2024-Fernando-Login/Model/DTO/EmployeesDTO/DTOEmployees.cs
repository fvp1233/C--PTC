using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.EmployeesDTO
{
    internal class DTOEmployees : dbContext
    {
        private string username;
        private int idEmployee;

        public string Username { get => username; set => username = value; }
        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
    }
}
