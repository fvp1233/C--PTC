using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.AlertsDTO
{
    internal class DTOChangePassword : dbContext
    {
        //atributos
        private string username;
        private string password;

        //getters y setters
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
