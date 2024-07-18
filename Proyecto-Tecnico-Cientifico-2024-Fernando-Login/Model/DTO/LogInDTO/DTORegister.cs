using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTC2024.Model.DTO.LogInDTO
{
    internal class DTORegister : dbContext
    {
        //Atributos del formulario Register
        private string names;
        private string lastnames;
        private string email;
        private string user;
        private string password;
        private string confirmPassword;

        //Getter y Settersde los atributos
        public string Names { get => names; set => names = value; }
        public string Lastnames { get => lastnames; set => lastnames = value; }
        public string Email { get => email; set => email = value; }
        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
    }
}
