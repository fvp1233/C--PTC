using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.PasswordRecoverDTO
{
    internal class DTOAdminMethod : dbContext
    {
        //Atributos
        private string adminUsername;
        private string adminPassword;
        private string employeeUsername;
        private string employeePassword;
        private bool temporalPass;

        //Métodos getter y setter
        public string AdminUsername { get => adminUsername; set => adminUsername = value; }
        public string AdminPassword { get => adminPassword; set => adminPassword = value; }
        public string EmployeeUsername { get => employeeUsername; set => employeeUsername = value; }
        public string EmployeePassword { get => employeePassword; set => employeePassword = value; }
        public bool TemporalPass { get => temporalPass; set => temporalPass = value; }
    }
}
