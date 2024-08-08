using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.LogInDTO
{
    internal class DTORecoverPassword : dbContext
    {
        private string user;
        private string email;
        private string password;
        private int idEmployee;

        public string User { get => user; set => user = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int IdEmployee { get => idEmployee; set => idEmployee = value; }
    }
}
